cmake_minimum_required(VERSION 3.14)

project(
    camera-shim
    VERSION 0.3.2
    DESCRIPTION "Shim for libcamera"
    HOMEPAGE_URL "https://github.com/buldo/libcamera-net"
    LANGUAGES CXX
)
set(BUILD_SHARED_LIBS ON)
#option(BUILD_SHARED_LIBS "Build shared libs." ON)
add_library(camera-shim)
add_library(camera-shim::camera-shim ALIAS camera-shim)

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

target_link_libraries(camera-shim ${LIBCAMERA_LINK_LIBRARIES})
#----------------------------------------------------------------------------------------------------------------------
# end dependencies
#----------------------------------------------------------------------------------------------------------------------


#----------------------------------------------------------------------------------------------------------------------
# sources
#----------------------------------------------------------------------------------------------------------------------
target_include_directories(camera-shim
    PUBLIC
        ${PROJECT_SOURCE_DIR}/include
)

set(sources
    "include/camera.h"
    "include/camera_manager.h"
    "include/controls.h"
    "include/framebuffer_allocator.h"
    "include/framebuffer.h"
    "include/geometry.h"
    "include/libcamera_ids.hpp"
    "include/logging.h"
    "include/pixel_format.h"
    "include/request.h"
    "include/signal.h"
    "include/stream.h"
    "include/version.h"
    "source/camera.cpp"
    "source/camera_manager.cpp"
    "source/controls.cpp"
    "source/framebuffer.cpp"
    "source/framebuffer_allocator.cpp"
    "source/geometry.cpp"
    "source/logging.cpp"
    "source/pixel_format.cpp"
    "source/request.cpp"
    "source/stream.cpp"
    )

source_group(TREE "${CMAKE_CURRENT_SOURCE_DIR}" FILES ${sources})

target_sources(camera-shim PRIVATE ${sources})
#----------------------------------------------------------------------------------------------------------------------
# sources end
#----------------------------------------------------------------------------------------------------------------------

set_target_properties(
    camera-shim PROPERTIES
# lets say this is OK
#    CXX_VISIBILITY_PRESET hidden
#    VISIBILITY_INLINES_HIDDEN YES
    VERSION "${PROJECT_VERSION}"
    SOVERSION "${PROJECT_VERSION_MAJOR}"
    EXPORT_NAME camera-shim
    OUTPUT_NAME camera-shim
)

target_compile_features(camera-shim PUBLIC cxx_std_17)
