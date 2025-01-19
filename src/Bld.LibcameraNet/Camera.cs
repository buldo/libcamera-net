using System.Runtime.InteropServices;
using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class Camera
{
    private readonly IntPtr _cameraPtr;
    private readonly Dictionary<IntPtr, Request> _requests = new();
    private Action<Request>? _onRequestCompleted;
    private IntPtr _requestCompletedHandle;

    internal Camera(IntPtr cameraPtr)
    {
        _cameraPtr = cameraPtr;
        Properties = new PropertyList(LibcameraNative.CameraProperties(_cameraPtr));
    }

    public PropertyList Properties { get; }

    public void Acquire()
    {
        var ret = LibcameraNative.CameraAcquire(_cameraPtr);
        if (ret < 0)
        {
            throw new Exception("Not able to acquire camera");
        }

        _requestCompletedHandle =
            LibcameraNative.CameraRequestCompletedConnect(
                _cameraPtr,
                delegate(IntPtr data, IntPtr requestPtr)
                {
                    try
                    {
                        var request = _requests[requestPtr];
                        _onRequestCompleted?.Invoke(request);
                    }
                    catch (Exception ex)
                    {
                    }
                },
                IntPtr.Zero);
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

    public int Configure(CameraConfiguration configuration)
    {
        return LibcameraNative.CameraConfigure(_cameraPtr, configuration.GetPtr());
    }

    internal IntPtr GetPtr()
    {
        return _cameraPtr;
    }

    public Request CreateRequest(UInt64 cookie = 0)
    {
        var reqPtr = LibcameraNative.CameraCreateRequest(_cameraPtr, cookie);
        var request = new Request(reqPtr);
        _requests.Add(reqPtr, request);
        return request;
    }

    public void OnRequestCompleted(Action<Request> func)
    {
        _onRequestCompleted = func;
    }

    public void Start(ControlList? controls = null)
    {
        var ctrlPtr = controls?.GetPtr() ?? IntPtr.Zero;
        var ret = LibcameraNative.CameraStart(_cameraPtr, ctrlPtr);
        if (ret < 0)
        {
            throw new Exception();
            //Err(io::Error::from_raw_os_error(ret))
        }
    }

    public void QueueRequest(Request request)
    {
        //self.state.lock ().unwrap().requests.insert(ptr, req);
        var ret = LibcameraNative.CameraQueueRequest(_cameraPtr, request.GetPtr());
        if (ret < 0)
        {
            //Err(io::Error::from_raw_os_error(ret))
        }
    }
}