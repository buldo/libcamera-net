using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Interop;

public class CameraUnitCellSize : IProperty<CameraUnitCellSize>
{
    public static PropertyId Id => PropertyId.UNIT_CELL_SIZE;

    public static CameraUnitCellSize Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}