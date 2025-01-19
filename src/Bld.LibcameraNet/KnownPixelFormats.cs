using System.Text;
using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public static class KnownPixelFormats
{
    /* color index */
    public static PixelFormat DRM_FORMAT_C1 = fourcc_code('C', '1', ' ', ' '); /* [7:0] C0:C1:C2:C3:C4:C5:C6:C7 1:1:1:1:1:1:1:1 eight pixels/byte */
    public static PixelFormat DRM_FORMAT_C2 = fourcc_code('C', '2', ' ', ' '); /* [7:0] C0:C1:C2:C3 2:2:2:2 four pixels/byte */
    public static PixelFormat DRM_FORMAT_C4 = fourcc_code('C', '4', ' ', ' '); /* [7:0] C0:C1 4:4 two pixels/byte */
    public static PixelFormat DRM_FORMAT_C8 = fourcc_code('C', '8', ' ', ' '); /* [7:0] C */

    /* 1 bpp Darkness (inverse relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_D1 = fourcc_code('D', '1', ' ', ' '); /* [7:0] D0:D1:D2:D3:D4:D5:D6:D7 1:1:1:1:1:1:1:1 eight pixels/byte */

    /* 2 bpp Darkness (inverse relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_D2 = fourcc_code('D', '2', ' ', ' '); /* [7:0] D0:D1:D2:D3 2:2:2:2 four pixels/byte */

    /* 4 bpp Darkness (inverse relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_D4 = fourcc_code('D', '4', ' ', ' '); /* [7:0] D0:D1 4:4 two pixels/byte */

    /* 8 bpp Darkness (inverse relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_D8 = fourcc_code('D', '8', ' ', ' '); /* [7:0] D */

    /* 1 bpp Red (direct relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_R1 = fourcc_code('R', '1', ' ', ' '); /* [7:0] R0:R1:R2:R3:R4:R5:R6:R7 1:1:1:1:1:1:1:1 eight pixels/byte */

    /* 2 bpp Red (direct relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_R2 = fourcc_code('R', '2', ' ', ' '); /* [7:0] R0:R1:R2:R3 2:2:2:2 four pixels/byte */

    /* 4 bpp Red (direct relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_R4 = fourcc_code('R', '4', ' ', ' '); /* [7:0] R0:R1 4:4 two pixels/byte */

    /* 8 bpp Red (direct relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_R8 = fourcc_code('R', '8', ' ', ' '); /* [7:0] R */

    /* 10 bpp Red (direct relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_R10 = fourcc_code('R', '1', '0', ' '); /* [15:0] x:R 6:10 little endian */

    /* 12 bpp Red (direct relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_R12 = fourcc_code('R', '1', '2', ' '); /* [15:0] x:R 4:12 little endian */

    /* 16 bpp Red (direct relationship between channel value and brightness) */
    public static PixelFormat DRM_FORMAT_R16 = fourcc_code('R', '1', '6', ' '); /* [15:0] R little endian */

    /* 16 bpp RG */
    public static PixelFormat DRM_FORMAT_RG88 = fourcc_code('R', 'G', '8', '8'); /* [15:0] R:G 8:8 little endian */
    public static PixelFormat DRM_FORMAT_GR88 = fourcc_code('G', 'R', '8', '8'); /* [15:0] G:R 8:8 little endian */

    /* 32 bpp RG */
    public static PixelFormat DRM_FORMAT_RG1616 = fourcc_code('R', 'G', '3', '2'); /* [31:0] R:G 16:16 little endian */
    public static PixelFormat DRM_FORMAT_GR1616 = fourcc_code('G', 'R', '3', '2'); /* [31:0] G:R 16:16 little endian */

    /* 8 bpp RGB */
    public static PixelFormat DRM_FORMAT_RGB332 = fourcc_code('R', 'G', 'B', '8'); /* [7:0] R:G:B 3:3:2 */
    public static PixelFormat DRM_FORMAT_BGR233 = fourcc_code('B', 'G', 'R', '8'); /* [7:0] B:G:R 2:3:3 */

    /* 16 bpp RGB */
    public static PixelFormat DRM_FORMAT_XRGB4444 = fourcc_code('X', 'R', '1', '2'); /* [15:0] x:R:G:B 4:4:4:4 little endian */
    public static PixelFormat DRM_FORMAT_XBGR4444 = fourcc_code('X', 'B', '1', '2'); /* [15:0] x:B:G:R 4:4:4:4 little endian */
    public static PixelFormat DRM_FORMAT_RGBX4444 = fourcc_code('R', 'X', '1', '2'); /* [15:0] R:G:B:x 4:4:4:4 little endian */
    public static PixelFormat DRM_FORMAT_BGRX4444 = fourcc_code('B', 'X', '1', '2'); /* [15:0] B:G:R:x 4:4:4:4 little endian */

    public static PixelFormat DRM_FORMAT_ARGB4444 = fourcc_code('A', 'R', '1', '2'); /* [15:0] A:R:G:B 4:4:4:4 little endian */
    public static PixelFormat DRM_FORMAT_ABGR4444 = fourcc_code('A', 'B', '1', '2'); /* [15:0] A:B:G:R 4:4:4:4 little endian */
    public static PixelFormat DRM_FORMAT_RGBA4444 = fourcc_code('R', 'A', '1', '2'); /* [15:0] R:G:B:A 4:4:4:4 little endian */
    public static PixelFormat DRM_FORMAT_BGRA4444 = fourcc_code('B', 'A', '1', '2'); /* [15:0] B:G:R:A 4:4:4:4 little endian */

    public static PixelFormat DRM_FORMAT_XRGB1555 = fourcc_code('X', 'R', '1', '5'); /* [15:0] x:R:G:B 1:5:5:5 little endian */
    public static PixelFormat DRM_FORMAT_XBGR1555 = fourcc_code('X', 'B', '1', '5'); /* [15:0] x:B:G:R 1:5:5:5 little endian */
    public static PixelFormat DRM_FORMAT_RGBX5551 = fourcc_code('R', 'X', '1', '5'); /* [15:0] R:G:B:x 5:5:5:1 little endian */
    public static PixelFormat DRM_FORMAT_BGRX5551 = fourcc_code('B', 'X', '1', '5'); /* [15:0] B:G:R:x 5:5:5:1 little endian */

    public static PixelFormat DRM_FORMAT_ARGB1555 = fourcc_code('A', 'R', '1', '5'); /* [15:0] A:R:G:B 1:5:5:5 little endian */
    public static PixelFormat DRM_FORMAT_ABGR1555 = fourcc_code('A', 'B', '1', '5'); /* [15:0] A:B:G:R 1:5:5:5 little endian */
    public static PixelFormat DRM_FORMAT_RGBA5551 = fourcc_code('R', 'A', '1', '5'); /* [15:0] R:G:B:A 5:5:5:1 little endian */
    public static PixelFormat DRM_FORMAT_BGRA5551 = fourcc_code('B', 'A', '1', '5'); /* [15:0] B:G:R:A 5:5:5:1 little endian */

    public static PixelFormat DRM_FORMAT_RGB565 = fourcc_code('R', 'G', '1', '6'); /* [15:0] R:G:B 5:6:5 little endian */
    public static PixelFormat DRM_FORMAT_BGR565 = fourcc_code('B', 'G', '1', '6'); /* [15:0] B:G:R 5:6:5 little endian */

    /* 24 bpp RGB */
    public static PixelFormat DRM_FORMAT_RGB888 = fourcc_code('R', 'G', '2', '4'); /* [23:0] R:G:B little endian */
    public static PixelFormat DRM_FORMAT_BGR888 = fourcc_code('B', 'G', '2', '4'); /* [23:0] B:G:R little endian */

    /* 32 bpp RGB */
    public static PixelFormat DRM_FORMAT_XRGB8888 = fourcc_code('X', 'R', '2', '4'); /* [31:0] x:R:G:B 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_XBGR8888 = fourcc_code('X', 'B', '2', '4'); /* [31:0] x:B:G:R 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_RGBX8888 = fourcc_code('R', 'X', '2', '4'); /* [31:0] R:G:B:x 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_BGRX8888 = fourcc_code('B', 'X', '2', '4'); /* [31:0] B:G:R:x 8:8:8:8 little endian */

    public static PixelFormat DRM_FORMAT_ARGB8888 = fourcc_code('A', 'R', '2', '4'); /* [31:0] A:R:G:B 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_ABGR8888 = fourcc_code('A', 'B', '2', '4'); /* [31:0] A:B:G:R 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_RGBA8888 = fourcc_code('R', 'A', '2', '4'); /* [31:0] R:G:B:A 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_BGRA8888 = fourcc_code('B', 'A', '2', '4'); /* [31:0] B:G:R:A 8:8:8:8 little endian */

    public static PixelFormat DRM_FORMAT_XRGB2101010 = fourcc_code('X', 'R', '3', '0'); /* [31:0] x:R:G:B 2:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_XBGR2101010 = fourcc_code('X', 'B', '3', '0'); /* [31:0] x:B:G:R 2:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_RGBX1010102 = fourcc_code('R', 'X', '3', '0'); /* [31:0] R:G:B:x 10:10:10:2 little endian */
    public static PixelFormat DRM_FORMAT_BGRX1010102 = fourcc_code('B', 'X', '3', '0'); /* [31:0] B:G:R:x 10:10:10:2 little endian */

    public static PixelFormat DRM_FORMAT_ARGB2101010 = fourcc_code('A', 'R', '3', '0'); /* [31:0] A:R:G:B 2:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_ABGR2101010 = fourcc_code('A', 'B', '3', '0'); /* [31:0] A:B:G:R 2:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_RGBA1010102 = fourcc_code('R', 'A', '3', '0'); /* [31:0] R:G:B:A 10:10:10:2 little endian */
    public static PixelFormat DRM_FORMAT_BGRA1010102 = fourcc_code('B', 'A', '3', '0'); /* [31:0] B:G:R:A 10:10:10:2 little endian */

    /* 64 bpp RGB */
    public static PixelFormat DRM_FORMAT_XRGB16161616 = fourcc_code('X', 'R', '4', '8'); /* [63:0] x:R:G:B 16:16:16:16 little endian */
    public static PixelFormat DRM_FORMAT_XBGR16161616 = fourcc_code('X', 'B', '4', '8'); /* [63:0] x:B:G:R 16:16:16:16 little endian */

    public static PixelFormat DRM_FORMAT_ARGB16161616 = fourcc_code('A', 'R', '4', '8'); /* [63:0] A:R:G:B 16:16:16:16 little endian */
    public static PixelFormat DRM_FORMAT_ABGR16161616 = fourcc_code('A', 'B', '4', '8'); /* [63:0] A:B:G:R 16:16:16:16 little endian */

    /*
     * Floating point 64bpp RGB
     * IEEE 754-2008 binary16 half-precision float
     * [15:0] sign:exponent:mantissa 1:5:10
     */
    public static PixelFormat DRM_FORMAT_XRGB16161616F = fourcc_code('X', 'R', '4', 'H'); /* [63:0] x:R:G:B 16:16:16:16 little endian */
    public static PixelFormat DRM_FORMAT_XBGR16161616F = fourcc_code('X', 'B', '4', 'H'); /* [63:0] x:B:G:R 16:16:16:16 little endian */

    public static PixelFormat DRM_FORMAT_ARGB16161616F = fourcc_code('A', 'R', '4', 'H'); /* [63:0] A:R:G:B 16:16:16:16 little endian */
    public static PixelFormat DRM_FORMAT_ABGR16161616F = fourcc_code('A', 'B', '4', 'H'); /* [63:0] A:B:G:R 16:16:16:16 little endian */

    /*
     * RGBA format with 10-bit components packed in 64-bit per pixel, with 6 bits
     * of unused padding per component:
     */
    public static PixelFormat DRM_FORMAT_AXBXGXRX106106106106 = fourcc_code('A', 'B', '1', '0'); /* [63:0] A:x:B:x:G:x:R:x 10:6:10:6:10:6:10:6 little endian */

    /* packed YCbCr */
    public static PixelFormat DRM_FORMAT_YUYV = fourcc_code('Y', 'U', 'Y', 'V'); /* [31:0] Cr0:Y1:Cb0:Y0 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_YVYU = fourcc_code('Y', 'V', 'Y', 'U'); /* [31:0] Cb0:Y1:Cr0:Y0 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_UYVY = fourcc_code('U', 'Y', 'V', 'Y'); /* [31:0] Y1:Cr0:Y0:Cb0 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_VYUY = fourcc_code('V', 'Y', 'U', 'Y'); /* [31:0] Y1:Cb0:Y0:Cr0 8:8:8:8 little endian */

    public static PixelFormat DRM_FORMAT_AYUV = fourcc_code('A', 'Y', 'U', 'V'); /* [31:0] A:Y:Cb:Cr 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_AVUY8888 = fourcc_code('A', 'V', 'U', 'Y'); /* [31:0] A:Cr:Cb:Y 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_XYUV8888 = fourcc_code('X', 'Y', 'U', 'V'); /* [31:0] X:Y:Cb:Cr 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_XVUY8888 = fourcc_code('X', 'V', 'U', 'Y'); /* [31:0] X:Cr:Cb:Y 8:8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_VUY888 = fourcc_code('V', 'U', '2', '4'); /* [23:0] Cr:Cb:Y 8:8:8 little endian */
    public static PixelFormat DRM_FORMAT_VUY101010 = fourcc_code('V', 'U', '3', '0'); /* Y followed by U then V, 10:10:10. Non-linear modifier only */

    /*
     * packed Y2xx indicate for each component, xx valid data occupy msb
     * 16-xx padding occupy lsb
     */
    public static PixelFormat DRM_FORMAT_Y210 = fourcc_code('Y', '2', '1', '0'); /* [63:0] Cr0:0:Y1:0:Cb0:0:Y0:0 10:6:10:6:10:6:10:6 little endian per 2 Y pixels */
    public static PixelFormat DRM_FORMAT_Y212 = fourcc_code('Y', '2', '1', '2'); /* [63:0] Cr0:0:Y1:0:Cb0:0:Y0:0 12:4:12:4:12:4:12:4 little endian per 2 Y pixels */
    public static PixelFormat DRM_FORMAT_Y216 = fourcc_code('Y', '2', '1', '6'); /* [63:0] Cr0:Y1:Cb0:Y0 16:16:16:16 little endian per 2 Y pixels */

    /*
     * packed Y4xx indicate for each component, xx valid data occupy msb
     * 16-xx padding occupy lsb except Y410
     */
    public static PixelFormat DRM_FORMAT_Y410 = fourcc_code('Y', '4', '1', '0'); /* [31:0] A:Cr:Y:Cb 2:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_Y412 = fourcc_code('Y', '4', '1', '2'); /* [63:0] A:0:Cr:0:Y:0:Cb:0 12:4:12:4:12:4:12:4 little endian */
    public static PixelFormat DRM_FORMAT_Y416 = fourcc_code('Y', '4', '1', '6'); /* [63:0] A:Cr:Y:Cb 16:16:16:16 little endian */

    public static PixelFormat DRM_FORMAT_XVYU2101010 = fourcc_code('X', 'V', '3', '0'); /* [31:0] X:Cr:Y:Cb 2:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_XVYU12_16161616 = fourcc_code('X', 'V', '3', '6'); /* [63:0] X:0:Cr:0:Y:0:Cb:0 12:4:12:4:12:4:12:4 little endian */
    public static PixelFormat DRM_FORMAT_XVYU16161616 = fourcc_code('X', 'V', '4', '8'); /* [63:0] X:Cr:Y:Cb 16:16:16:16 little endian */

    /*
     * packed YCbCr420 2x2 tiled formats
     * first 64 bits will contain Y,Cb,Cr components for a 2x2 tile
     */
    /* [63:0]   A3:A2:Y3:0:Cr0:0:Y2:0:A1:A0:Y1:0:Cb0:0:Y0:0  1:1:8:2:8:2:8:2:1:1:8:2:8:2:8:2 little endian */
    public static PixelFormat DRM_FORMAT_Y0L0 = fourcc_code('Y', '0', 'L', '0');
    /* [63:0]   X3:X2:Y3:0:Cr0:0:Y2:0:X1:X0:Y1:0:Cb0:0:Y0:0  1:1:8:2:8:2:8:2:1:1:8:2:8:2:8:2 little endian */
    public static PixelFormat DRM_FORMAT_X0L0 = fourcc_code('X', '0', 'L', '0');

    /* [63:0]   A3:A2:Y3:Cr0:Y2:A1:A0:Y1:Cb0:Y0  1:1:10:10:10:1:1:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_Y0L2 = fourcc_code('Y', '0', 'L', '2');
    /* [63:0]   X3:X2:Y3:Cr0:Y2:X1:X0:Y1:Cb0:Y0  1:1:10:10:10:1:1:10:10:10 little endian */
    public static PixelFormat DRM_FORMAT_X0L2 = fourcc_code('X', '0', 'L', '2');

    /*
     * 1-plane YUV 4:2:0
     * In these formats, the component ordering is specified (Y, followed by U
     * then V), but the exact Linear layout is undefined.
     * These formats can only be used with a non-Linear modifier.
     */
    public static PixelFormat DRM_FORMAT_YUV420_8BIT = fourcc_code('Y', 'U', '0', '8');
    public static PixelFormat DRM_FORMAT_YUV420_10BIT = fourcc_code('Y', 'U', '1', '0');

    /*
     * 2 plane RGB + A
     * index 0 = RGB plane, same format as the corresponding non _A8 format has
     * index 1 = A plane, [7:0] A
     */
    public static PixelFormat DRM_FORMAT_XRGB8888_A8 = fourcc_code('X', 'R', 'A', '8');
    public static PixelFormat DRM_FORMAT_XBGR8888_A8 = fourcc_code('X', 'B', 'A', '8');
    public static PixelFormat DRM_FORMAT_RGBX8888_A8 = fourcc_code('R', 'X', 'A', '8');
    public static PixelFormat DRM_FORMAT_BGRX8888_A8 = fourcc_code('B', 'X', 'A', '8');
    public static PixelFormat DRM_FORMAT_RGB888_A8 = fourcc_code('R', '8', 'A', '8');
    public static PixelFormat DRM_FORMAT_BGR888_A8 = fourcc_code('B', '8', 'A', '8');
    public static PixelFormat DRM_FORMAT_RGB565_A8 = fourcc_code('R', '5', 'A', '8');
    public static PixelFormat DRM_FORMAT_BGR565_A8 = fourcc_code('B', '5', 'A', '8');

    /*
     * 2 plane YCbCr
     * index 0 = Y plane, [7:0] Y
     * index 1 = Cr:Cb plane, [15:0] Cr:Cb little endian
     * or
     * index 1 = Cb:Cr plane, [15:0] Cb:Cr little endian
     */
    public static PixelFormat DRM_FORMAT_NV12 = fourcc_code('N', 'V', '1', '2'); /* 2x2 subsampled Cr:Cb plane */
    public static PixelFormat DRM_FORMAT_NV21 = fourcc_code('N', 'V', '2', '1'); /* 2x2 subsampled Cb:Cr plane */
    public static PixelFormat DRM_FORMAT_NV16 = fourcc_code('N', 'V', '1', '6'); /* 2x1 subsampled Cr:Cb plane */
    public static PixelFormat DRM_FORMAT_NV61 = fourcc_code('N', 'V', '6', '1'); /* 2x1 subsampled Cb:Cr plane */
    public static PixelFormat DRM_FORMAT_NV24 = fourcc_code('N', 'V', '2', '4'); /* non-subsampled Cr:Cb plane */

    public static PixelFormat DRM_FORMAT_NV42 = fourcc_code('N', 'V', '4', '2'); /* non-subsampled Cb:Cr plane */
    /*
     * 2 plane YCbCr
     * index 0 = Y plane, [39:0] Y3:Y2:Y1:Y0 little endian
     * index 1 = Cr:Cb plane, [39:0] Cr1:Cb1:Cr0:Cb0 little endian
     */
    public static PixelFormat DRM_FORMAT_NV15 = fourcc_code('N', 'V', '1', '5'); /* 2x2 subsampled Cr:Cb plane */

    /*
     * 2 plane YCbCr MSB aligned
     * index 0 = Y plane, [15:0] Y:x [10:6] little endian
     * index 1 = Cr:Cb plane, [31:0] Cr:x:Cb:x [10:6:10:6] little endian
     */
    public static PixelFormat DRM_FORMAT_P210 = fourcc_code('P', '2', '1', '0'); /* 2x1 subsampled Cr:Cb plane, 10 bit per channel */

    /*
     * 2 plane YCbCr MSB aligned
     * index 0 = Y plane, [15:0] Y:x [10:6] little endian
     * index 1 = Cr:Cb plane, [31:0] Cr:x:Cb:x [10:6:10:6] little endian
     */
    public static PixelFormat DRM_FORMAT_P010 = fourcc_code('P', '0', '1', '0'); /* 2x2 subsampled Cr:Cb plane 10 bits per channel */

    /*
     * 2 plane YCbCr MSB aligned
     * index 0 = Y plane, [15:0] Y:x [12:4] little endian
     * index 1 = Cr:Cb plane, [31:0] Cr:x:Cb:x [12:4:12:4] little endian
     */
    public static PixelFormat DRM_FORMAT_P012 = fourcc_code('P', '0', '1', '2'); /* 2x2 subsampled Cr:Cb plane 12 bits per channel */

    /*
     * 2 plane YCbCr MSB aligned
     * index 0 = Y plane, [15:0] Y little endian
     * index 1 = Cr:Cb plane, [31:0] Cr:Cb [16:16] little endian
     */
    public static PixelFormat DRM_FORMAT_P016 = fourcc_code('P', '0', '1', '6'); /* 2x2 subsampled Cr:Cb plane 16 bits per channel */

    /* 2 plane YCbCr420.
     * 3 10 bit components and 2 padding bits packed into 4 bytes.
     * index 0 = Y plane, [31:0] x:Y2:Y1:Y0 2:10:10:10 little endian
     * index 1 = Cr:Cb plane, [63:0] x:Cr2:Cb2:Cr1:x:Cb1:Cr0:Cb0 [2:10:10:10:2:10:10:10] little endian
     */
    public static PixelFormat DRM_FORMAT_P030 = fourcc_code('P', '0', '3', '0'); /* 2x2 subsampled Cr:Cb plane 10 bits per channel packed */

    /* 3 plane non-subsampled (444) YCbCr
     * 16 bits per component, but only 10 bits are used and 6 bits are padded
     * index 0: Y plane, [15:0] Y:x [10:6] little endian
     * index 1: Cb plane, [15:0] Cb:x [10:6] little endian
     * index 2: Cr plane, [15:0] Cr:x [10:6] little endian
     */
    public static PixelFormat DRM_FORMAT_Q410 = fourcc_code('Q', '4', '1', '0');

    /* 3 plane non-subsampled (444) YCrCb
     * 16 bits per component, but only 10 bits are used and 6 bits are padded
     * index 0: Y plane, [15:0] Y:x [10:6] little endian
     * index 1: Cr plane, [15:0] Cr:x [10:6] little endian
     * index 2: Cb plane, [15:0] Cb:x [10:6] little endian
     */
    public static PixelFormat DRM_FORMAT_Q401 = fourcc_code('Q', '4', '0', '1');

    /*
     * 3 plane YCbCr
     * index 0: Y plane, [7:0] Y
     * index 1: Cb plane, [7:0] Cb
     * index 2: Cr plane, [7:0] Cr
     * or
     * index 1: Cr plane, [7:0] Cr
     * index 2: Cb plane, [7:0] Cb
     */
    public static PixelFormat DRM_FORMAT_YUV410 = fourcc_code('Y', 'U', 'V', '9'); /* 4x4 subsampled Cb (1) and Cr (2) planes */
    public static PixelFormat DRM_FORMAT_YVU410 = fourcc_code('Y', 'V', 'U', '9'); /* 4x4 subsampled Cr (1) and Cb (2) planes */
    public static PixelFormat DRM_FORMAT_YUV411 = fourcc_code('Y', 'U', '1', '1'); /* 4x1 subsampled Cb (1) and Cr (2) planes */
    public static PixelFormat DRM_FORMAT_YVU411 = fourcc_code('Y', 'V', '1', '1'); /* 4x1 subsampled Cr (1) and Cb (2) planes */
    public static PixelFormat DRM_FORMAT_YUV420 = fourcc_code('Y', 'U', '1', '2'); /* 2x2 subsampled Cb (1) and Cr (2) planes */
    public static PixelFormat DRM_FORMAT_YVU420 = fourcc_code('Y', 'V', '1', '2'); /* 2x2 subsampled Cr (1) and Cb (2) planes */
    public static PixelFormat DRM_FORMAT_YUV422 = fourcc_code('Y', 'U', '1', '6'); /* 2x1 subsampled Cb (1) and Cr (2) planes */
    public static PixelFormat DRM_FORMAT_YVU422 = fourcc_code('Y', 'V', '1', '6'); /* 2x1 subsampled Cr (1) and Cb (2) planes */
    public static PixelFormat DRM_FORMAT_YUV444 = fourcc_code('Y', 'U', '2', '4'); /* non-subsampled Cb (1) and Cr (2) planes */
    public static PixelFormat DRM_FORMAT_YVU444 = fourcc_code('Y', 'V', '2', '4'); /* non-subsampled Cr (1) and Cb (2) planes */

    private static Dictionary<PixelFormat, string> _pixelFormatNames = new()
    {
        [DRM_FORMAT_C1] = nameof(DRM_FORMAT_C1),
        [DRM_FORMAT_C2] = nameof(DRM_FORMAT_C2),
        [DRM_FORMAT_C4] = nameof(DRM_FORMAT_C4),
        [DRM_FORMAT_C8] = nameof(DRM_FORMAT_C8),
        [DRM_FORMAT_D1] = nameof(DRM_FORMAT_D1),
        [DRM_FORMAT_D2] = nameof(DRM_FORMAT_D2),
        [DRM_FORMAT_D4] = nameof(DRM_FORMAT_D4),
        [DRM_FORMAT_D8] = nameof(DRM_FORMAT_D8),
        [DRM_FORMAT_R1] = nameof(DRM_FORMAT_R1),
        [DRM_FORMAT_R2] = nameof(DRM_FORMAT_R2),
        [DRM_FORMAT_R4] = nameof(DRM_FORMAT_R4),
        [DRM_FORMAT_R8] = nameof(DRM_FORMAT_R8),
        [DRM_FORMAT_R10] = nameof(DRM_FORMAT_R10),
        [DRM_FORMAT_R12] = nameof(DRM_FORMAT_R12),
        [DRM_FORMAT_R16] = nameof(DRM_FORMAT_R16),
        [DRM_FORMAT_RG88] = nameof(DRM_FORMAT_RG88),
        [DRM_FORMAT_GR88] = nameof(DRM_FORMAT_GR88),
        [DRM_FORMAT_RG1616] = nameof(DRM_FORMAT_RG1616),
        [DRM_FORMAT_GR1616] = nameof(DRM_FORMAT_GR1616),
        [DRM_FORMAT_RGB332] = nameof(DRM_FORMAT_RGB332),
        [DRM_FORMAT_BGR233] = nameof(DRM_FORMAT_BGR233),
        [DRM_FORMAT_XRGB4444] = nameof(DRM_FORMAT_XRGB4444),
        [DRM_FORMAT_XBGR4444] = nameof(DRM_FORMAT_XBGR4444),
        [DRM_FORMAT_RGBX4444] = nameof(DRM_FORMAT_RGBX4444),
        [DRM_FORMAT_BGRX4444] = nameof(DRM_FORMAT_BGRX4444),
        [DRM_FORMAT_ARGB4444] = nameof(DRM_FORMAT_ARGB4444),
        [DRM_FORMAT_ABGR4444] = nameof(DRM_FORMAT_ABGR4444),
        [DRM_FORMAT_RGBA4444] = nameof(DRM_FORMAT_RGBA4444),
        [DRM_FORMAT_BGRA4444] = nameof(DRM_FORMAT_BGRA4444),
        [DRM_FORMAT_XRGB1555] = nameof(DRM_FORMAT_XRGB1555),
        [DRM_FORMAT_XBGR1555] = nameof(DRM_FORMAT_XBGR1555),
        [DRM_FORMAT_RGBX5551] = nameof(DRM_FORMAT_RGBX5551),
        [DRM_FORMAT_BGRX5551] = nameof(DRM_FORMAT_BGRX5551),
        [DRM_FORMAT_ARGB1555] = nameof(DRM_FORMAT_ARGB1555),
        [DRM_FORMAT_ABGR1555] = nameof(DRM_FORMAT_ABGR1555),
        [DRM_FORMAT_RGBA5551] = nameof(DRM_FORMAT_RGBA5551),
        [DRM_FORMAT_BGRA5551] = nameof(DRM_FORMAT_BGRA5551),
        [DRM_FORMAT_RGB565] = nameof(DRM_FORMAT_RGB565),
        [DRM_FORMAT_BGR565] = nameof(DRM_FORMAT_BGR565),
        [DRM_FORMAT_RGB888] = nameof(DRM_FORMAT_RGB888),
        [DRM_FORMAT_BGR888] = nameof(DRM_FORMAT_BGR888),
        [DRM_FORMAT_XRGB8888] = nameof(DRM_FORMAT_XRGB8888),
        [DRM_FORMAT_XBGR8888] = nameof(DRM_FORMAT_XBGR8888),
        [DRM_FORMAT_RGBX8888] = nameof(DRM_FORMAT_RGBX8888),
        [DRM_FORMAT_BGRX8888] = nameof(DRM_FORMAT_BGRX8888),
        [DRM_FORMAT_ARGB8888] = nameof(DRM_FORMAT_ARGB8888),
        [DRM_FORMAT_ABGR8888] = nameof(DRM_FORMAT_ABGR8888),
        [DRM_FORMAT_RGBA8888] = nameof(DRM_FORMAT_RGBA8888),
        [DRM_FORMAT_BGRA8888] = nameof(DRM_FORMAT_BGRA8888),
        [DRM_FORMAT_XRGB2101010] = nameof(DRM_FORMAT_XRGB2101010),
        [DRM_FORMAT_XBGR2101010] = nameof(DRM_FORMAT_XBGR2101010),
        [DRM_FORMAT_RGBX1010102] = nameof(DRM_FORMAT_RGBX1010102),
        [DRM_FORMAT_BGRX1010102] = nameof(DRM_FORMAT_BGRX1010102),
        [DRM_FORMAT_ARGB2101010] = nameof(DRM_FORMAT_ARGB2101010),
        [DRM_FORMAT_ABGR2101010] = nameof(DRM_FORMAT_ABGR2101010),
        [DRM_FORMAT_RGBA1010102] = nameof(DRM_FORMAT_RGBA1010102),
        [DRM_FORMAT_BGRA1010102] = nameof(DRM_FORMAT_BGRA1010102),
        [DRM_FORMAT_XRGB16161616] = nameof(DRM_FORMAT_XRGB16161616),
        [DRM_FORMAT_XBGR16161616] = nameof(DRM_FORMAT_XBGR16161616),
        [DRM_FORMAT_ARGB16161616] = nameof(DRM_FORMAT_ARGB16161616),
        [DRM_FORMAT_ABGR16161616] = nameof(DRM_FORMAT_ABGR16161616),
        [DRM_FORMAT_XRGB16161616F] = nameof(DRM_FORMAT_XRGB16161616F),
        [DRM_FORMAT_XBGR16161616F] = nameof(DRM_FORMAT_XBGR16161616F),
        [DRM_FORMAT_ARGB16161616F] = nameof(DRM_FORMAT_ARGB16161616F),
        [DRM_FORMAT_ABGR16161616F] = nameof(DRM_FORMAT_ABGR16161616F),
        [DRM_FORMAT_AXBXGXRX106106106106] = nameof(DRM_FORMAT_AXBXGXRX106106106106),
        [DRM_FORMAT_YUYV] = nameof(DRM_FORMAT_YUYV),
        [DRM_FORMAT_YVYU] = nameof(DRM_FORMAT_YVYU),
        [DRM_FORMAT_UYVY] = nameof(DRM_FORMAT_UYVY),
        [DRM_FORMAT_VYUY] = nameof(DRM_FORMAT_VYUY),
        [DRM_FORMAT_AYUV] = nameof(DRM_FORMAT_AYUV),
        [DRM_FORMAT_AVUY8888] = nameof(DRM_FORMAT_AVUY8888),
        [DRM_FORMAT_XYUV8888] = nameof(DRM_FORMAT_XYUV8888),
        [DRM_FORMAT_XVUY8888] = nameof(DRM_FORMAT_XVUY8888),
        [DRM_FORMAT_VUY888] = nameof(DRM_FORMAT_VUY888),
        [DRM_FORMAT_VUY101010] = nameof(DRM_FORMAT_VUY101010),
        [DRM_FORMAT_Y210] = nameof(DRM_FORMAT_Y210),
        [DRM_FORMAT_Y212] = nameof(DRM_FORMAT_Y212),
        [DRM_FORMAT_Y216] = nameof(DRM_FORMAT_Y216),
        [DRM_FORMAT_Y410] = nameof(DRM_FORMAT_Y410),
        [DRM_FORMAT_Y412] = nameof(DRM_FORMAT_Y412),
        [DRM_FORMAT_Y416] = nameof(DRM_FORMAT_Y416),
        [DRM_FORMAT_XVYU2101010] = nameof(DRM_FORMAT_XVYU2101010),
        [DRM_FORMAT_XVYU12_16161616] = nameof(DRM_FORMAT_XVYU12_16161616),
        [DRM_FORMAT_XVYU16161616] = nameof(DRM_FORMAT_XVYU16161616),
        [DRM_FORMAT_Y0L0] = nameof(DRM_FORMAT_Y0L0),
        [DRM_FORMAT_X0L0] = nameof(DRM_FORMAT_X0L0),
        [DRM_FORMAT_Y0L2] = nameof(DRM_FORMAT_Y0L2),
        [DRM_FORMAT_X0L2] = nameof(DRM_FORMAT_X0L2),
        [DRM_FORMAT_YUV420_8BIT] = nameof(DRM_FORMAT_YUV420_8BIT),
        [DRM_FORMAT_YUV420_10BIT] = nameof(DRM_FORMAT_YUV420_10BIT),
        [DRM_FORMAT_XRGB8888_A8] = nameof(DRM_FORMAT_XRGB8888_A8),
        [DRM_FORMAT_XBGR8888_A8] = nameof(DRM_FORMAT_XBGR8888_A8),
        [DRM_FORMAT_RGBX8888_A8] = nameof(DRM_FORMAT_RGBX8888_A8),
        [DRM_FORMAT_BGRX8888_A8] = nameof(DRM_FORMAT_BGRX8888_A8),
        [DRM_FORMAT_RGB888_A8] = nameof(DRM_FORMAT_RGB888_A8),
        [DRM_FORMAT_BGR888_A8] = nameof(DRM_FORMAT_BGR888_A8),
        [DRM_FORMAT_RGB565_A8] = nameof(DRM_FORMAT_RGB565_A8),
        [DRM_FORMAT_BGR565_A8] = nameof(DRM_FORMAT_BGR565_A8),
        [DRM_FORMAT_NV12] = nameof(DRM_FORMAT_NV12),
        [DRM_FORMAT_NV21] = nameof(DRM_FORMAT_NV21),
        [DRM_FORMAT_NV16] = nameof(DRM_FORMAT_NV16),
        [DRM_FORMAT_NV61] = nameof(DRM_FORMAT_NV61),
        [DRM_FORMAT_NV24] = nameof(DRM_FORMAT_NV24),
        [DRM_FORMAT_NV42] = nameof(DRM_FORMAT_NV42),
        [DRM_FORMAT_NV15] = nameof(DRM_FORMAT_NV15),
        [DRM_FORMAT_P210] = nameof(DRM_FORMAT_P210),
        [DRM_FORMAT_P010] = nameof(DRM_FORMAT_P010),
        [DRM_FORMAT_P012] = nameof(DRM_FORMAT_P012),
        [DRM_FORMAT_P016] = nameof(DRM_FORMAT_P016),
        [DRM_FORMAT_P030] = nameof(DRM_FORMAT_P030),
        [DRM_FORMAT_Q410] = nameof(DRM_FORMAT_Q410),
        [DRM_FORMAT_Q401] = nameof(DRM_FORMAT_Q401),
        [DRM_FORMAT_YUV410] = nameof(DRM_FORMAT_YUV410),
        [DRM_FORMAT_YVU410] = nameof(DRM_FORMAT_YVU410),
        [DRM_FORMAT_YUV411] = nameof(DRM_FORMAT_YUV411),
        [DRM_FORMAT_YVU411] = nameof(DRM_FORMAT_YVU411),
        [DRM_FORMAT_YUV420] = nameof(DRM_FORMAT_YUV420),
        [DRM_FORMAT_YVU420] = nameof(DRM_FORMAT_YVU420),
        [DRM_FORMAT_YUV422] = nameof(DRM_FORMAT_YUV422),
        [DRM_FORMAT_YVU422] = nameof(DRM_FORMAT_YVU422),
        [DRM_FORMAT_YUV444] = nameof(DRM_FORMAT_YUV444),
        [DRM_FORMAT_YVU444] = nameof(DRM_FORMAT_YVU444),
    };

    private static string ToFourccString(this PixelFormat format)
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

    private static PixelFormat fourcc_code(char a, char b, char c, char d)
    {
        return Create(a, b, c, d, 0, 0);
    }

    public static string GetName(this PixelFormat format)
    {
        if (_pixelFormatNames.TryGetValue(format, out var value))
        {
            return value;
        }

        return ToFourccString(format);
    }
}