namespace Bld.LibcameraNet.Interop;

public class CameraColorFilterArrangement : IProperty<CameraColorFilterArrangement>
{
    public static PropertyId Id => PropertyId.COLOR_FILTER_ARRANGEMENT;
    public static CameraColorFilterArrangement Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}