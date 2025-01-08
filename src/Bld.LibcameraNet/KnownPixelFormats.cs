using System.Text;
using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public static class KnownPixelFormats
{
    public static PixelFormat MJpeg { get; } = Create('M', 'J', 'P', 'G', 0, 0);

    public static string ToFourccString(this PixelFormat format)
    {
        var fourcc = format.Fourcc;
        return Encoding.ASCII.GetString(
        [
            (byte)fourcc,
            (byte)(fourcc >> 8),
            (byte)(fourcc >> 16),
            (byte)(fourcc >> 24)
        ]);
    }

    private static PixelFormat Create(char a, char b, char c, char d, UInt32 vendor, UInt32 mod)
    {
        UInt32 fourcc = (uint)(((UInt64)(Encoding.ASCII.GetBytes([a])[0]) <<  0) |
                               ((UInt64)(Encoding.ASCII.GetBytes([b])[0]) <<  8) |
                               ((UInt64)(Encoding.ASCII.GetBytes([c])[0]) << 16) |
                               ((UInt64)(Encoding.ASCII.GetBytes([d])[0]) << 24));

        // UInt32 fourcc = (uint)(((UInt64)(a) <<  0) |
        //                        ((UInt64)(b) <<  8) |
        //                        ((UInt64)(c) << 16) |
        //                        ((UInt64)(d) << 24));

        UInt64 modVal = ((UInt64)(vendor) << 56) |
                        ((UInt64)(mod) << 0);

        return new() { Fourcc = fourcc, Modifier = modVal };
    }
}