using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class ImgHighGuiTest : Test
    {
        [TestMethod]
        public void imshow()
        {
            var img = cv2.imread(imgSolar);
			// cv2.imshow("solar", img);
			// cv2.waitKey(0);
			var dv = GetData(img);
        }

		public (byte,long[],byte[]) GetData(object target)
		{
			byte size = 0;
			long[] dims = new long[0];
			byte[] data = new byte[0];

			if (target is SharpCV.Mat mat)
			{
				dims = mat.shape.dims;
				size = (byte)dims.Length;
				data = mat.data.ToByteArray();
			}

			return (size, dims, data);

		}

	}
}
