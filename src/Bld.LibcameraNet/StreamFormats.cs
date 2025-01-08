using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class StreamFormats
{
    private readonly IntPtr _formatsPtr;

    internal StreamFormats(IntPtr formatsPtr)
    {
        _formatsPtr = formatsPtr;
        var pixelFormatsPtr = LibcameraNative.StreamFormatsPixelFormats(_formatsPtr);
        PixelFormats = new PixelFormats(pixelFormatsPtr);
    }

    public PixelFormats PixelFormats { get; }
}