using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class StreamConfiguration
{
    private readonly IntPtr _confPtr;

    internal StreamConfiguration(IntPtr confPtr)
    {
        _confPtr = confPtr;
    }

    public PixelFormat PixelFormat
    {
        get => LibcameraNative.StreamConfigurationGetPixelFormat(_confPtr);
        set => LibcameraNative.StreamConfigurationSetPixelFormat(_confPtr, value);
    }
}