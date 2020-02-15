# SharpCV

A image library combines [OpenCV](https://github.com/opencv/opencv) and [NumSharp](https://github.com/SciSharp/NumSharp.Lite) together. `SharpCV` returns `Mat` object with `NDArray` supported, which makes it easier to do data manipulation like slicing.

[![Join the chat at https://gitter.im/publiclab/publiclab](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/sci-sharp/community) [![NuGet](https://img.shields.io/nuget/dt/SharpCV.svg)](https://www.nuget.org/packages/SharpCV)

### How to use

Install OpenCV prebuild binary

```powershell
PM> Install-Package SharpCV
PM> Install-Package OpenCvSharp4.runtime.win
```
Import SharpCV and OpenCV library
```csharp
using SharpCV;
using static SharpCV.Binding;
```
Interact with `NDArray`

```csharp
NDArray kernel = new float[,]
{
    { 0, -1, 0 },
    { -1, 5, -1 },
    { 0, -1, 0 }
};

var mat = new Mat(kernel);

Assert.AreEqual((3, 3), mat.shape);
Assert.AreEqual(kernel[0], mat.data[0]); // { 0, -1, 0 }
Assert.AreEqual(kernel[1], mat.data[1]); // { -1, 5, -1 }
Assert.AreEqual(kernel[2], mat.data[2]); // { 0, -1, 0 }
```

Convert to black and white image

```csharp
var img = cv2.imread("solar.jpg");
var gray = cv2.cvtColor(img, ColorConversionCodes.COLOR_RGB2GRAY);
var (ret, binary) = cv2.threshold(gray, 0, 255, ThresholdTypes.THRESH_BINARY | ThresholdTypes.THRESH_TRIANGLE);
cv2.imshow("black and white", binary);
cv2.waitKey(0);
```
Video capture from file or camera
```csharp
var vid = cv2.VideoCapture("road.mp4");
var (loaded, frame) = vid.read();
while (loaded)
{
    (loaded, frame) = vid.read();
    cv2.imshow("video", frame);
}
```

If you want to learn more about the API implementation, please refer to the official [documentation](https://docs.opencv.org/).

