using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tensorflow;
using Tensorflow.NumPy;

namespace SharpCV
{
    public partial class Mat : DisposableObject
    {
        NDArray _nd;
        public NDArray data
        {
            get
            {
                if (_nd is null)
                    _nd = GetData();

                return _nd;
            }
        }

        int _ndim;
        public int ndim
        {
            get
            {
                cv2_native_api.core_Mat_dims(_handle, out _ndim);
                return _ndim + (Channels > 1 ? 1 : 0);
            }
        }

        public TF_DataType dtype { get; set; } = np.@byte;

        MatType _matType = MatType.Unknown;
        public MatType MatType
        {
            get
            {
                if (_matType != MatType.Unknown)
                    return _matType;

                cv2_native_api.core_Mat_type(_handle, out _matType);
                return _matType;
            }
        }

        int[] _dims;
        Shape _shape;
        /// <summary>
        /// HWC
        /// height * width * channel
        /// </summary>
        public Shape shape
        {
            get
            {
                if(_dims != null)
                    return _shape;

                _dims = new int[ndim];
                cv2_native_api.core_Mat_dims(_handle, out _ndim);
                
                for (int i = 0; i < _ndim; i++)
                    cv2_native_api.core_Mat_sizeAt(_handle, i, out _dims[i]);

                if(Channels > 1)
                    _dims[_ndim] = Channels;

                _shape = new Shape(_dims);
                return _shape;
            }
        }

        public long size => shape.size;

        IntPtr _intputArray;
        public IntPtr InputArray
        {
            get
            {
                if(_intputArray == IntPtr.Zero)
                    cv2_native_api.core_InputArray_new_byMat(_handle, out _intputArray);
                return _intputArray;
            }
        }

        IntPtr _outputArray;
        public IntPtr OutputArray
        {
            get
            {
                if(_outputArray == IntPtr.Zero)
                    cv2_native_api.core_OutputArray_new_byMat(_handle, out _outputArray);
                return _outputArray;
            }
        }

        int _channels = -1;
        public int Channels
        {
            get
            {
                if (_channels > -1)
                    return _channels;

                cv2_native_api.core_Mat_channels(_handle, out _channels);
                return _channels;
            }
        }

        public unsafe NDArray GetData()
        {
            // we pass donothing as it keeps reference to src preventing its disposal by GC
            switch (MatType)
            {
                case MatType.CV_32SC1:
                case MatType.CV_32SC2:
                    {
                        cv2_native_api.core_Mat_data(_handle, out int* dataPtr);
                        dtype = TF_DataType.TF_INT32;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
                case MatType.CV_32FC1:
                    {
                        cv2_native_api.core_Mat_data(_handle, out float* dataPtr);
                        dtype = TF_DataType.TF_FLOAT;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
                case MatType.CV_8UC1:
                case MatType.CV_8UC3:
                    {
                        cv2_native_api.core_Mat_data(_handle, out byte* dataPtr);
                        dtype = TF_DataType.TF_UINT8;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
                default:
                    throw new NotImplementedException($"Can't find type: {_matType}");
            }
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private void DoNothing(IntPtr ptr)
        {
            var p = ptr;
        }

        public NDArray astype(Type type)
            => data.astype(type);

        protected override void FreeHandle()
        {
            cv2_native_api.core_Mat_delete(_handle);
        }

        public override string ToString()
        {
            return $"{shape} {MatType}";
        }

        public MatType FromType(Type type)
            => Type.GetTypeCode(type) switch
            {
                TypeCode.Int32 => MatType.CV_32SC1,
                TypeCode.Single => MatType.CV_32FC1,
                TypeCode.Double => MatType.CV_64FC1,
                _ => MatType.CV_8UC1
            };

        public MatType FromType(TF_DataType dtype)
            => dtype switch
            {
                TF_DataType.TF_INT32 => MatType.CV_32SC1,
                TF_DataType.TF_FLOAT => MatType.CV_32FC1,
                TF_DataType.TF_DOUBLE => MatType.CV_64FC1,
                _ => MatType.CV_8UC1
            };

        #region ImEncode / ToBytes

        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ImEncode(string ext = ".png", int[]? prms = null)
        {
            //ThrowIfDisposed();
            SharpCV.cv_api.ImEncode(ext, this, out var buf, prms);
            return buf;
        }

        ///// <summary>
        ///// Encodes an image into a memory buffer.
        ///// </summary>
        ///// <param name="ext">Encodes an image into a memory buffer.</param>
        ///// <param name="prms">Format-specific parameters.</param>
        ///// <returns></returns>
        //public byte[] ImEncode(string ext = ".png", params ImageEncodingParam[] prms)
        //{
        //    //ThrowIfDisposed();
        //    SharpCV.cv_api.ImEncode(ext, this, out var buf, prms);
        //    return buf;
        //}

        #endregion

        #region Static Initializers

        /// <summary>
        /// Creates the Mat instance from System.IO.Stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Mat FromStream(System.IO.Stream stream, IMREAD_COLOR mode = IMREAD_COLOR.IMREAD_COLOR)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (stream.Length > int.MaxValue)
                throw new ArgumentException("Not supported stream (too long)");

            using var memoryStream = new System.IO.MemoryStream();
            stream.CopyTo(memoryStream);

            return FromImageData(memoryStream.ToArray(), mode);
        }

        /// <summary>
        /// Creates the Mat instance from image data (using cv::decode) 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Mat ImDecode(byte[] imageBytes, IMREAD_COLOR mode = IMREAD_COLOR.IMREAD_COLOR)
        {
            if (imageBytes == null)
                throw new ArgumentNullException(nameof(imageBytes));
            return cv_api.ImDecode(imageBytes, mode);
        }

        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="span">The input slice of bytes.</param>
        /// <param name="mode">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat ImDecode(ReadOnlySpan<byte> span, IMREAD_COLOR mode = IMREAD_COLOR.IMREAD_COLOR)
        {
            return cv_api.ImDecode(span, mode);
        }

        /// <summary>
        /// Creates the Mat instance from image data (using cv::decode) 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Mat FromImageData(byte[] imageBytes, IMREAD_COLOR mode = IMREAD_COLOR.IMREAD_COLOR)
        {
            return ImDecode(imageBytes, mode);
        }

        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="span">The input slice of bytes.</param>
        /// <param name="mode">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat FromImageData(ReadOnlySpan<byte> span, IMREAD_COLOR mode = IMREAD_COLOR.IMREAD_COLOR)
        {
            return cv_api.ImDecode(span, mode);
        }

        #endregion


    }
}
