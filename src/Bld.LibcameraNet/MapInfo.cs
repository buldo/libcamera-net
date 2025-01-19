namespace Bld.LibcameraNet;

internal class MapInfo
{
    /// Maximum offset used by data planes
    public UInt64 mapped_len { get; set; }

    /// Total file descriptor size
    public UInt64 total_len { get; set; }
}