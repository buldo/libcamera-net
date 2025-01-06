namespace Bld.LibcameraNet.Interop;

public class CameraPixelArrayActiveAreas : IProperty<CameraPixelArrayActiveAreas>
{
    public static PropertyId Id => PropertyId.PIXEL_ARRAY_ACTIVE_AREAS;
    public static CameraPixelArrayActiveAreas Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}