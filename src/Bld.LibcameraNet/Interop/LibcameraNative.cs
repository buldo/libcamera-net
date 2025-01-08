using System;
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
        EntryPoint = "libcamera_stream_configuration_get_pixel_format")]
    internal static partial void StreamConfigurationSetPixelFormat(IntPtr config, PixelFormat format);

    [LibraryImport(
        LibcameraConsts.LibName,
        EntryPoint = "libcamera_stream_configuration_formats")]
    internal static partial IntPtr StreamConfigurationFormats(IntPtr config);
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
}