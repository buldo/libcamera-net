using System.Runtime.InteropServices;

namespace Bld.LibcameraNet.Interop;

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
}