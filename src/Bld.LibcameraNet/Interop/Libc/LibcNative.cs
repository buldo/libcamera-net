using System.Runtime.InteropServices;

namespace Bld.LibcameraNet.Interop.Libc;

public static partial class LibcNative
{
    private const string LibName = "libc";

    [LibraryImport(
        LibName,
        EntryPoint = "lseek64",
        SetLastError = true)]
    internal static partial UInt64 Lseek64(int fd, long offset, WhenceFlags whence);

    [LibraryImport(
        LibName,
        EntryPoint = "mmap64",
        SetLastError = true)]
    internal static partial IntPtr Mmap64(
        IntPtr start,
        UIntPtr length,
        MmapProts prot,
        MmapFlags flags,
        int fd,
        long offset);
}