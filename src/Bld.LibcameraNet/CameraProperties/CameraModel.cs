namespace Bld.LibcameraNet.Interop;

public class CameraModel : IProperty<CameraModel>
{
    public static PropertyId Id => PropertyId.MODEL;
    public static CameraModel Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}