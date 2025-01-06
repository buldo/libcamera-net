namespace Bld.LibcameraNet.Interop;

public enum CameraConfigurationStatus : uint
{
    /// Camera configuration was validated without issues.
    Valid,
    /// Camera configuration is valid, but some of the fields were adjusted by libcamera.
    Adjusted,
    /// Camera configuration is invalid.
    Invalid,
}