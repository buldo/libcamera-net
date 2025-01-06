using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class Camera
{
    private readonly IntPtr _cameraPtr;

    internal Camera(IntPtr cameraPtr)
    {
        _cameraPtr = cameraPtr;
        Properties = new PropertyList(LibcameraNative.CameraProperties(_cameraPtr));
    }

    public PropertyList Properties { get; }

    public int Acquire()
    {
        return (int)LibcameraNative.CameraAcquire(_cameraPtr);
    }

    public int Release()
    {
        return (int)LibcameraNative.CameraRelease(_cameraPtr);
    }

    public CameraConfiguration GenerateConfiguration(StreamRole[] streamRoles)
    {
        var cfg = LibcameraNative.CameraGenerateConfiguration(_cameraPtr, streamRoles, streamRoles.Length);
        return new CameraConfiguration(cfg);
    }
}