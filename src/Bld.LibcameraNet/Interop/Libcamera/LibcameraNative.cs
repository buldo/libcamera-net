using System.Runtime.InteropServices;

namespace Bld.LibcameraNet.Interop.Libcamera;

public static partial class LibcameraNative
{
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_manager_create")]
    internal static partial IntPtr CameraManagerCreate();

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_manager_destroy")]
    internal static partial void CameraManagerDestroy(IntPtr mgr);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_manager_start")]
    internal static partial nint CameraManagerStart(IntPtr mgr);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_manager_stop")]
    internal static partial void CameraManagerStop(IntPtr mgr);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_manager_cameras")]
    internal static partial IntPtr CameraManagerCameras(IntPtr mgr);

    #region CameraList
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_list_destroy")]
    internal static partial void CameraListDestroy(IntPtr list);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_list_size")]
    internal static partial nint CameraListSize(IntPtr list);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_list_get")]
    internal static partial IntPtr CameraListGet(IntPtr list, nint index);
    #endregion

    #region CameraProperties

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_properties")]
    internal static partial IntPtr CameraProperties(IntPtr cam);

    #endregion

    #region ControlsList

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_list_get")]
    internal static partial IntPtr ControlListGet(IntPtr cam, int id);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_list_iter")]
    internal static partial IntPtr ControlListIter(IntPtr list);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_list_iter_destroy")]
    internal static partial void ControlListIterDestroy(IntPtr iter);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_list_iter_end")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool ControlListIterEnd(IntPtr iter);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_list_iter_next")]
    internal static partial void ControlListIterNext(IntPtr iter);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_list_iter_id")]
    internal static partial nuint ControlListIterId(IntPtr iter);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_list_iter_value")]
    internal static partial IntPtr ControlListIterValue(IntPtr iter);

    #endregion

    #region Controls
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_value_type")]
    internal static partial ControlType ControlValueType(IntPtr ctrl);


    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_value_num_elements")]
    internal static partial nint ControlValueNumElements(IntPtr ctrl);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_control_value_get")]
    internal static partial IntPtr ControlValueGet(IntPtr ctrl);
    #endregion

    #region Camera
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_release")]
    internal static partial nint CameraRelease(IntPtr camera);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_acquire")]
    internal static partial nint CameraAcquire(IntPtr camera);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_generate_configuration")]
    internal static partial IntPtr CameraGenerateConfiguration(IntPtr cam, [In] StreamRole[] roles, nint roleCount);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_configure")]
    internal static partial int CameraConfigure(IntPtr cam, IntPtr config);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_create_request")]
    internal static partial IntPtr CameraCreateRequest(IntPtr cam, UInt64 cookie);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_start")]
    internal static partial int CameraStart(IntPtr cam, IntPtr controls);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_queue_request")]
    internal static partial int CameraQueueRequest(IntPtr cam, IntPtr request);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void RequestCompletedCb(IntPtr data, IntPtr requestPtr);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_request_completed_connect")]
    internal static partial IntPtr CameraRequestCompletedConnect(
        IntPtr cam,
        RequestCompletedCb callback,
        IntPtr data);
    #endregion

    #region CameraConfiguration
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_configuration_destroy")]
    internal static partial void CameraConfigurationDestroy(IntPtr config);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_configuration_at")]
    internal static partial IntPtr CameraConfigurationAt(IntPtr config, nint index);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_camera_configuration_validate")]
    internal static partial CameraConfigurationStatus CameraConfigurationValidate(IntPtr config);
    #endregion

    #region StreamConfiguration
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_configuration_get_pixel_format")]
    internal static partial PixelFormat StreamConfigurationGetPixelFormat(IntPtr config);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_configuration_set_pixel_format")]
    internal static partial void StreamConfigurationSetPixelFormat(IntPtr config, PixelFormat format);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_configuration_get_size")]
    internal static partial LibcameraSize StreamConfigurationGetSize(IntPtr config);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_configuration_set_size")]
    internal static partial void StreamConfigurationSetSize(IntPtr config, LibcameraSize format);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_configuration_formats")]
    internal static partial IntPtr StreamConfigurationFormats(IntPtr config);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_configuration_stream")]
    internal static partial IntPtr StreamConfigurationStream(IntPtr config);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_allocator_allocate")]
    internal static partial int FramebufferAllocatorAllocate(IntPtr alloc, IntPtr stream);
    #endregion

    #region StreamFormats
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_formats_pixel_formats")]
    internal static partial IntPtr StreamFormatsPixelFormats(IntPtr formats);
    #endregion

    #region PixelFormats
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_pixel_formats_size")]
    internal static partial int PixelFormatsSize(IntPtr formats);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_pixel_formats_get")]
    internal static partial PixelFormat PixelFormatsGet(IntPtr formats, nint index);
    #endregion

    #region FrameBufferAllocator
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_allocator_create")]
    internal static partial IntPtr FramebufferAllocatorCreate(IntPtr cam);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_allocator_buffers")]
    internal static partial IntPtr FramebufferAllocatorBuffers(IntPtr alloc, IntPtr stream);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_list_size")]
    internal static partial nuint FramebufferListSize(IntPtr list);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_list_get")]
    internal static partial IntPtr FramebufferListGet(IntPtr list, nuint index);
    #endregion

    #region Request

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_request_add_buffer")]
    internal static partial int RequestAddBuffer(IntPtr request, IntPtr stream, IntPtr buffer);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_request_cookie")]
    internal static partial UInt64 RequestCookie(IntPtr request);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_request_status")]
    internal static partial RequestStatus RequestStatus(IntPtr request);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_request_sequence")]
    internal static partial UInt32 RequestSequence(IntPtr request);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_request_metadata")]
    internal static partial IntPtr RequestMetadata(IntPtr request);
    #endregion

    #region Framebuffer
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_planes")]
    internal static partial IntPtr FramebufferPlanes(IntPtr framebuffer);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_planes_size")]
    internal static partial nuint FramebufferPlanesSize(IntPtr planes);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_planes_at")]
    internal static partial IntPtr FramebufferPlanesAt(IntPtr planes, nuint index);
    #endregion

    #region FramBufferPlane
    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_plane_fd")]
    internal static partial int FramebufferPlaneFd(IntPtr plane);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_plane_offset")]
    internal static partial nuint FramebufferPlaneOffset(IntPtr plane);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_plane_offset_valid")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool FramebufferPlaneOffsetValid(IntPtr plane);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_framebuffer_plane_length")]
    internal static partial nuint FramebufferPlaneLength(IntPtr plane);
    #endregion
}