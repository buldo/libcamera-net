cmake_minimum_required(VERSION 3.14)

project(
    libcamera-shim
    VERSION 0.3.2
    DESCRIPTION "Shim for libcamera"
    HOMEPAGE_URL "https://github.com/buldo/libcamera-net"
    LANGUAGES CXX
)

include(cmake/project-is-top-level.cmake)
include(cmake/variables.cmake)
option(BUILD_SHARED_LIBS "Build shared libs." ON)

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

#----------------------------------------------------------------------------------------------------------------------
# dependencies
#----------------------------------------------------------------------------------------------------------------------
find_package(PkgConfig REQUIRED)

pkg_check_modules(LIBCAMERA REQUIRED libcamera)
message(STATUS "libcamera library found:")
message(STATUS "    version: ${LIBCAMERA_VERSION}")
message(STATUS "    libraries: ${LIBCAMERA_LINK_LIBRARIES}")
message(STATUS "    include path: ${LIBCAMERA_INCLUDE_DIRS}")
include_directories(${CMAKE_SOURCE_DIR} ${LIBCAMERA_INCLUDE_DIRS})

target_link_libraries(libcamera-shim_libcamera-shim ${LIBCAMERA_LINK_LIBRARIES})
#----------------------------------------------------------------------------------------------------------------------
# end dependencies
#----------------------------------------------------------------------------------------------------------------------

target_compile_definitions(libcamera-shim_libcamera-shim PUBLIC LIBCAMERA_SHIM_STATIC_DEFINE)

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
