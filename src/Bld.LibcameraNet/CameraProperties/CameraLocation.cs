namespace Bld.LibcameraNet.Interop;

public class CameraLocation : IProperty<CameraLocation>
{
    public static PropertyId Id => PropertyId.LOCATION;
    public static CameraLocation Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}