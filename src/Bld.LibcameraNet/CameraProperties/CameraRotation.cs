namespace Bld.LibcameraNet.Interop;

public class CameraRotation : IProperty<CameraRotation>
{
    public static PropertyId Id => PropertyId.ROTATION;
    public static CameraRotation Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}