using Bld.LibcameraNet.Interop.Libcamera;
using LibcameraNative = Bld.LibcameraNet.Interop.Libcamera.LibcameraNative;

namespace Bld.LibcameraNet;

public class StreamConfiguration
{
    private readonly IntPtr _confPtr;

    internal StreamConfiguration(IntPtr confPtr)
    {
        _confPtr = confPtr;
        var formatsPtr = LibcameraNative.StreamConfigurationFormats(_confPtr);
        StreamFormats = new StreamFormats(formatsPtr);
    }

    public PixelFormat PixelFormat
    {
        get => LibcameraNative.StreamConfigurationGetPixelFormat(_confPtr);
        set => LibcameraNative.StreamConfigurationSetPixelFormat(_confPtr, value);
    }

    public LibcameraSize Size
    {
        get => LibcameraNative.StreamConfigurationGetSize(_confPtr);
        set => LibcameraNative.StreamConfigurationSetSize(_confPtr, value);
    }

    public ColorSpace? ColorSpace
    {
        get
        {
            var shimValue = LibcameraNative.StreamConfigurationGetColorSpace(_confPtr);
            return ColorSpace.FromShimValue(shimValue);
        }
    }

    public StreamFormats StreamFormats { get; }

    public LibcameraStream GetStream()
    {
        var streamPtr = LibcameraNative.StreamConfigurationStream(_confPtr);
        return new LibcameraStream(streamPtr);
    }
}