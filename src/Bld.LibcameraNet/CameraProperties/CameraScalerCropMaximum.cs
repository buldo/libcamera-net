namespace Bld.LibcameraNet.Interop;

public class CameraScalerCropMaximum : IProperty<CameraScalerCropMaximum>
{
    public static PropertyId Id => PropertyId.SCALER_CROP_MAXIMUM;
    public static CameraScalerCropMaximum Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        throw new NotImplementedException();
    }
}