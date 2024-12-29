namespace Bld.LibcameraNet;

public class Camera
{
    private readonly IntPtr _cameraPtr;

    internal Camera(IntPtr cameraPtr)
    {
        _cameraPtr = cameraPtr;
    }
}