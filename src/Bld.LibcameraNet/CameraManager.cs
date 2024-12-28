using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class CameraManager
{
    private readonly IntPtr _nativeCameraManager;

    public CameraManager()
    {
        _nativeCameraManager = LibcameraNative.CameraManagerCreate();
    }
}