cmake_minimum_required(VERSION 3.14)

include(cmake/prelude.cmake)

project(
    libcamera-shim
    VERSION 0.1.0
    DESCRIPTION "Shim for libcamera"
    HOMEPAGE_URL "https://example.com/"
    LANGUAGES CXX
)

include(cmake/project-is-top-level.cmake)
include(cmake/variables.cmake)

# ---- Declare library ----

add_library(
    libcamera-shim_libcamera-shim
    source/camera.cpp
    source/camera_manager.cpp
    source/controls.cpp
    source/framebuffer.cpp
    source/framebuffer_allocator.cpp
    source/geometry.cpp
    source/logging.cpp
    source/pixel_format.cpp
    source/request.cpp
    source/stream.cpp
)
add_library(libcamera-shim::libcamera-shim ALIAS libcamera-shim_libcamera-shim)

include(GenerateExportHeader)
generate_export_header(
    libcamera-shim_libcamera-shim
    BASE_NAME libcamera-shim
    EXPORT_FILE_NAME export/libcamera-shim/libcamera-shim_export.hpp
    CUSTOM_CONTENT_FROM_VARIABLE pragma_suppress_c4251
)

if(NOT BUILD_SHARED_LIBS)
  target_compile_definitions(libcamera-shim_libcamera-shim PUBLIC LIBCAMERA_SHIM_STATIC_DEFINE)
endif()

set_target_properties(
    libcamera-shim_libcamera-shim PROPERTIES
    CXX_VISIBILITY_PRESET hidden
    VISIBILITY_INLINES_HIDDEN YES
    VERSION "${PROJECT_VERSION}"
    SOVERSION "${PROJECT_VERSION_MAJOR}"
    EXPORT_NAME libcamera-shim
    OUTPUT_NAME libcamera-shim
)

target_include_directories(
    libcamera-shim_libcamera-shim ${warning_guard}
    PUBLIC
    "\$<BUILD_INTERFACE:${PROJECT_SOURCE_DIR}/include>"
)

target_include_directories(
    libcamera-shim_libcamera-shim SYSTEM
    PUBLIC
    "\$<BUILD_INTERFACE:${PROJECT_BINARY_DIR}/export>"
)

target_compile_features(libcamera-shim_libcamera-shim PUBLIC cxx_std_17)

# ---- Install rules ----

if(NOT CMAKE_SKIP_INSTALL_RULES)
  include(cmake/install-rules.cmake)
endif()

# ---- Examples ----

if(PROJECT_IS_TOP_LEVEL)
  option(BUILD_EXAMPLES "Build examples tree." "${libcamera-shim_DEVELOPER_MODE}")
  if(BUILD_EXAMPLES)
    add_subdirectory(example)
  endif()
endif()

# ---- Developer mode ----

if(NOT libcamera-shim_DEVELOPER_MODE)
  return()
elseif(NOT PROJECT_IS_TOP_LEVEL)
  message(
      AUTHOR_WARNING
      "Developer mode is intended for developers of libcamera-shim"
  )
endif()

include(cmake/dev-mode.cmake)
