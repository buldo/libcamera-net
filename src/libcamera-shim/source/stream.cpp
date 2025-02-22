#include "stream.h"

#include <libcamera/libcamera.h>
#include <libcamera/formats.h>

extern "C" {

libcamera_pixel_formats_t *libcamera_stream_formats_pixel_formats(const libcamera_stream_formats_t* formats) {
    return new libcamera_pixel_formats_t(std::move(formats->pixelformats()));
}

libcamera_sizes_t *libcamera_stream_formats_sizes(const libcamera_stream_formats_t* formats, const libcamera_pixel_format_t *pixel_format) {
    return new libcamera_sizes_t(std::move(formats->sizes(*pixel_format)));
}

libcamera_size_range_t libcamera_stream_formats_range(const libcamera_stream_formats_t* formats, const libcamera_pixel_format_t *pixel_format) {
    return formats->range(*pixel_format);
}

const libcamera_stream_formats_t *libcamera_stream_configuration_formats(const libcamera_stream_configuration_t *config) {
    return &config->formats();
}

libcamera_stream_t *libcamera_stream_configuration_stream(const libcamera_stream_configuration_t *config) {
    return config->stream();
}

libcamera_pixel_format_t libcamera_stream_configuration_get_pixel_format(
    const libcamera_stream_configuration_t* config)
{
  return config->pixelFormat;
}

void libcamera_stream_configuration_set_pixel_format(
    libcamera_stream_configuration_t* config,
    libcamera_pixel_format_t format)
{
  config->pixelFormat =
      libcamera::PixelFormat(format.fourcc(), format.modifier());
}

libcamera_size_fixed libcamera_stream_configuration_get_size(
    const libcamera_stream_configuration_t* config)
{
  return libcamera_size_fixed {config->size.width, config->size.height};
}

void libcamera_stream_configuration_set_size(
    libcamera_stream_configuration_t* config,
    libcamera_size_fixed format)
{
  config->size.width = format.width;
  config->size.height = format.height;
}

libcamera_stream_configuration_t* libcamera_stream_get_configuration(
    libcamera_stream_t* stream)
{
  return const_cast<libcamera_stream_configuration_t*>(
      &stream->configuration());
}

uint8_t libcamera_stream_configuration_get_color_space(
    const libcamera_stream_configuration_t* config)
{
  if (!config->colorSpace.has_value()) {
    return 0;
  }

  if (config->colorSpace == libcamera::ColorSpace::Raw)
  {
    return 1;
  }

  if (config->colorSpace == libcamera::ColorSpace::Srgb) {
    return 2;
  }

  if (config->colorSpace == libcamera::ColorSpace::Sycc) {
    return 3;
  }

  if (config->colorSpace == libcamera::ColorSpace::Smpte170m) {
    return 4;
  }

  if (config->colorSpace == libcamera::ColorSpace::Rec709) {
    return 5;
  }

  if (config->colorSpace == libcamera::ColorSpace::Rec2020) {
    return 6;
  }

  return 255;
}

}
