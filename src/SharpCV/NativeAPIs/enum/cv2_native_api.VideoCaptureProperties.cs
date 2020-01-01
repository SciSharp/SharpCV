using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// modules\videoio\include\opencv2\videoio.hpp
    /// </summary>
    public enum VideoCaptureProperties
    {
        CAP_PROP_POS_MSEC = 0, //!< Current position of the video file in milliseconds.
        CAP_PROP_POS_FRAMES = 1, //!< 0-based index of the frame to be decoded/captured next.
        CAP_PROP_POS_AVI_RATIO = 2, //!< Relative position of the video file: 0=start of the film, 1=end of the film.
        CAP_PROP_FRAME_WIDTH = 3, //!< Width of the frames in the video stream.
        CAP_PROP_FRAME_HEIGHT = 4, //!< Height of the frames in the video stream.
        CAP_PROP_FPS = 5, //!< Frame rate.
        CAP_PROP_FOURCC = 6, //!< 4-character code of codec. see VideoWriter::fourcc .
        CAP_PROP_FRAME_COUNT = 7, //!< Number of frames in the video file.
        CAP_PROP_FORMAT = 8, //!< Format of the %Mat objects (see Mat::type()) returned by VideoCapture::retrieve().
                             //!< Set value -1 to fetch undecoded RAW video streams (as Mat 8UC1).
        CAP_PROP_MODE = 9, //!< Backend-specific value indicating the current capture mode.
        CAP_PROP_BRIGHTNESS = 10, //!< Brightness of the image (only for those cameras that support).
        CAP_PROP_CONTRAST = 11, //!< Contrast of the image (only for cameras).
        CAP_PROP_SATURATION = 12, //!< Saturation of the image (only for cameras).
        CAP_PROP_HUE = 13, //!< Hue of the image (only for cameras).
        CAP_PROP_GAIN = 14, //!< Gain of the image (only for those cameras that support).
        CAP_PROP_EXPOSURE = 15, //!< Exposure (only for those cameras that support).
        CAP_PROP_CONVERT_RGB = 16, //!< Boolean flags indicating whether images should be converted to RGB.
        CAP_PROP_WHITE_BALANCE_BLUE_U = 17, //!< Currently unsupported.
        CAP_PROP_RECTIFICATION = 18, //!< Rectification flag for stereo cameras (note: only supported by DC1394 v 2.x backend currently).
        CAP_PROP_MONOCHROME = 19,
        CAP_PROP_SHARPNESS = 20,
        CAP_PROP_AUTO_EXPOSURE = 21, //!< DC1394: exposure control done by camera, user can adjust reference level using this feature.
        CAP_PROP_GAMMA = 22,
        CAP_PROP_TEMPERATURE = 23,
        CAP_PROP_TRIGGER = 24,
        CAP_PROP_TRIGGER_DELAY = 25,
        CAP_PROP_WHITE_BALANCE_RED_V = 26,
        CAP_PROP_ZOOM = 27,
        CAP_PROP_FOCUS = 28,
        CAP_PROP_GUID = 29,
        CAP_PROP_ISO_SPEED = 30,
        CAP_PROP_BACKLIGHT = 32,
        CAP_PROP_PAN = 33,
        CAP_PROP_TILT = 34,
        CAP_PROP_ROLL = 35,
        CAP_PROP_IRIS = 36,
        CAP_PROP_SETTINGS = 37, //!< Pop up video/camera filter dialog (note: only supported by DSHOW backend currently. The property value is ignored)
        CAP_PROP_BUFFERSIZE = 38,
        CAP_PROP_AUTOFOCUS = 39,
        CAP_PROP_SAR_NUM = 40, //!< Sample aspect ratio: num/den (num)
        CAP_PROP_SAR_DEN = 41, //!< Sample aspect ratio: num/den (den)
        CAP_PROP_BACKEND = 42, //!< Current backend (enum VideoCaptureAPIs). Read-only property
        CAP_PROP_CHANNEL = 43, //!< Video input or Channel Number (only for those cameras that support)
        CAP_PROP_AUTO_WB = 44, //!< enable/ disable auto white-balance
        CAP_PROP_WB_TEMPERATURE = 45, //!< white-balance color temperature
        CAP_PROP_CODEC_PIXEL_FORMAT = 46,    //!< (read-only) codec's pixel format. 4-character code - see VideoWriter::fourcc . Subset of [AV_PIX_FMT_*](https://github.com/FFmpeg/FFmpeg/blob/master/libavcodec/raw.c) or -1 if unknown
    };
}
