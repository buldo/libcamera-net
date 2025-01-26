using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Interop;

public class CameraSystemDevices : IProperty<CameraSystemDevices>
{
    public static PropertyId Id => PropertyId.SYSTEM_DEVICES;
    public static CameraSystemDevices Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}