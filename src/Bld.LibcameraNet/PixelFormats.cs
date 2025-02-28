using Bld.LibcameraNet.Interop;
using Bld.LibcameraNet.Interop.Libcamera;
using LibcameraNative = Bld.LibcameraNet.Interop.Libcamera.LibcameraNative;

namespace Bld.LibcameraNet;

// TODO: Add PixelFormatsDestroy
public class PixelFormats
{
    private readonly IntPtr _pixelFormatsPtr;

    internal PixelFormats(IntPtr pixelFormatsPtr)
    {
        _pixelFormatsPtr = pixelFormatsPtr;
        Count = LibcameraNative.PixelFormatsSize(_pixelFormatsPtr);
    }

    public int Count { get; }

    public PixelFormat this[int index]
    {
        get
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return LibcameraNative.PixelFormatsGet(_pixelFormatsPtr, index);
        }
    }
}