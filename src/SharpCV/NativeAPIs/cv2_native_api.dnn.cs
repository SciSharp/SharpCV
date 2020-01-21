using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_readNetFromDarknet(string cfgFile, string darknetModel, out IntPtr returnValue);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_Net_new(out IntPtr net);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_readNetFromTensorflow(string model, string config, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_readNetFromTorch(string model, bool isBinary, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_readNetFromONNX(string model, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_readTensorFromONNX(string path, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_Net_delete(IntPtr net);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_blobFromImage(IntPtr image, double scalefactor, Size size, Scalar mean, bool swapRB, bool crop, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_Net_setInput(IntPtr net, IntPtr input, string name);
        [DllImport(OpenCvDllName)]
        internal static extern void dnn_Net_forward1(IntPtr net, string outputName, out IntPtr output);
    }
}
