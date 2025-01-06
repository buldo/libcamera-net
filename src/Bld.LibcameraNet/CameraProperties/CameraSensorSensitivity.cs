namespace Bld.LibcameraNet.Interop;

public class CameraSensorSensitivity : IProperty<CameraSensorSensitivity>
{
    public static PropertyId Id => PropertyId.SENSOR_SENSITIVITY;

    public static CameraSensorSensitivity Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}