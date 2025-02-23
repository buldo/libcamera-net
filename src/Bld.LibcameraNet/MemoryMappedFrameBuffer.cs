using Bld.LibcameraNet.Interop.Libc;
using LibcNative = Bld.LibcameraNet.Interop.Libc.LibcNative;
using System.Runtime.InteropServices;

namespace Bld.LibcameraNet;

public class MemoryMappedFrameBuffer : IAsFrameBuffer
{
    private readonly LibcameraFrameBuffer _frameBuffer;
    private readonly List<MappedPlane> _planes = new List<MappedPlane>();
    private readonly Dictionary<int, (IntPtr pointer, UInt64 len)> _mapped = new();

    public MemoryMappedFrameBuffer(LibcameraFrameBuffer frameBuffer)
    {
        _frameBuffer = frameBuffer;

        var map_info =  new Dictionary<int, MapInfo>();

        //for (index, plane) in .into_iter().enumerate()
        foreach (var plane in _frameBuffer.GetPlanes())
        {
            var fd = plane.Fd;
            var offset = plane.Offset;
            var len = plane.Length;

            // TODO: What to do if offset is not valid?
            _planes.Add(new MappedPlane { fd = fd, offset = offset.Value, len = len });

            // Find total FD length if not known yet
            var total_len = LibcNative.Lseek64(fd, 0, WhenceFlags.SEEK_END);
            var info = new MapInfo
            {
                mapped_len = 0,
                total_len = total_len
            };
            map_info[fd] = info;

            if (offset + len > info.total_len)
            {
                throw new Exception("PlaneOutOfBounds");
                //    return Err(MemoryMappedFrameBufferError::PlaneOutOfBounds {
                //        index,
                //            offset,
                //            len,
                //            fd_len: info.total_len,
                //        });
            }

            info.mapped_len = (UInt64)(offset + len)!;
        }

        foreach (var (fd, info) in map_info)
        {

            var addr = LibcNative.Mmap64(
                IntPtr.Zero,
                (nuint)info.mapped_len,
                MmapProts.PROT_READ,
                MmapFlags.MAP_SHARED,
                fd,
                0
            );
            unsafe
            {
                var virtualAlloc = (byte*)addr;
                if (virtualAlloc == (byte*)-1)
                {
                    var err = Marshal.GetLastWin32Error();
                    throw new InvalidOperationException("Failed to mmap");
                }
            }

            _mapped[fd] = (addr, info.mapped_len);
        }
    }

    public byte[] GetData()
    {
        UInt64 fullLen = 0;
        foreach (var plane in _planes)
        {
            fullLen += plane.len;
        }

        var data = new byte[fullLen];
        var targetOffset = 0;
        foreach (var plane in _planes)
        {
            var mmap_ptr = _mapped[plane.fd].pointer;

            unsafe
            {
                fixed (byte* pTarget = data)
                {
                    byte* pSource = (byte*)mmap_ptr;

                    // Copy the specified number of bytes from source to target.
                    for (int i = 0; i < (int)plane.len; i++)
                    {
                        pTarget[targetOffset + i] = pSource[plane.offset + (ulong)i];
                    }
                }
            }

            targetOffset += (int)plane.len;
        }

        return data;
    }

    public LibcameraFrameBuffer AsFrameBuffer()
    {
        return _frameBuffer;
    }
}