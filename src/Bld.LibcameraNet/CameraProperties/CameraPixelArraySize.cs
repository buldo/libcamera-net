using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Interop;

public class CameraPixelArraySize : IProperty<CameraPixelArraySize>
{
    public static PropertyId Id => PropertyId.PIXEL_ARRAY_SIZE;
    public static CameraPixelArraySize Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}