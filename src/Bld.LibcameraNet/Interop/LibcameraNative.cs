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
}