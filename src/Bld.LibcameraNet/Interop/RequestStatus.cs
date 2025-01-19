namespace Bld.LibcameraNet.Interop;

public enum RequestStatus
{
    /// Request is ready to be executed by [ActiveCamera::queue_request()](crate::camera::ActiveCamera::queue_request)
    Pending,
    /// Request was executed successfully
    Complete,
    /// Request was cancelled, most likely due to call to [ActiveCamera::stop()](crate::camera::ActiveCamera::stop)
    Cancelled,
}