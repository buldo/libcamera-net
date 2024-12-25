if(PROJECT_IS_TOP_LEVEL)
  set(
      CMAKE_INSTALL_INCLUDEDIR "include/libcamera-shim-${PROJECT_VERSION}"
      CACHE STRING ""
  )
  set_property(CACHE CMAKE_INSTALL_INCLUDEDIR PROPERTY TYPE PATH)
endif()

include(CMakePackageConfigHelpers)
include(GNUInstallDirs)

# find_package(<package>) call for consumers to find this project
set(package libcamera-shim)

install(
    DIRECTORY
    include/
    "${PROJECT_BINARY_DIR}/export/"
    DESTINATION "${CMAKE_INSTALL_INCLUDEDIR}"
    COMPONENT libcamera-shim_Development
)

install(
    TARGETS libcamera-shim_libcamera-shim
    EXPORT libcamera-shimTargets
    RUNTIME #
    COMPONENT libcamera-shim_Runtime
    LIBRARY #
    COMPONENT libcamera-shim_Runtime
    NAMELINK_COMPONENT libcamera-shim_Development
    ARCHIVE #
    COMPONENT libcamera-shim_Development
    INCLUDES #
    DESTINATION "${CMAKE_INSTALL_INCLUDEDIR}"
)

write_basic_package_version_file(
    "${package}ConfigVersion.cmake"
    COMPATIBILITY SameMajorVersion
)

# Allow package maintainers to freely override the path for the configs
set(
    libcamera-shim_INSTALL_CMAKEDIR "${CMAKE_INSTALL_LIBDIR}/cmake/${package}"
    CACHE STRING "CMake package config location relative to the install prefix"
)
set_property(CACHE libcamera-shim_INSTALL_CMAKEDIR PROPERTY TYPE PATH)
mark_as_advanced(libcamera-shim_INSTALL_CMAKEDIR)

install(
    FILES cmake/install-config.cmake
    DESTINATION "${libcamera-shim_INSTALL_CMAKEDIR}"
    RENAME "${package}Config.cmake"
    COMPONENT libcamera-shim_Development
)

install(
    FILES "${PROJECT_BINARY_DIR}/${package}ConfigVersion.cmake"
    DESTINATION "${libcamera-shim_INSTALL_CMAKEDIR}"
    COMPONENT libcamera-shim_Development
)

install(
    EXPORT libcamera-shimTargets
    NAMESPACE libcamera-shim::
    DESTINATION "${libcamera-shim_INSTALL_CMAKEDIR}"
    COMPONENT libcamera-shim_Development
)

if(PROJECT_IS_TOP_LEVEL)
  include(CPack)
endif()
