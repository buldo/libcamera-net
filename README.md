# libcamera-net
LibcameraNet is .NET8 binding to libcamera.  
Package based on `libcamera-rs` C wrapper.  
If prebuilt wrapper in package not working with your libcamera, you need to rebuild wrapper.  
Tested on 64bit RaspberryPi OS.  

# Packages
LibcameraNet version coupled with libcamera versions in RaspberryPi OS.  

## Install:
```
dotnet add package Bld.LibcameraNet
```

## Dev and prerelease versions of packages:
Feed:
```
https://f.feedz.io/bld/beta/nuget/index.json
```


# About enum marshaling
I hope that this is true:
```
The Procedure Call Standard for the ARM 64-bit Architecture states that the size of enumeration types must be at least 32 bits.
The default is -fno-short-enums.
That is, the size of an enumeration type is at least 32 bits regardless of the size of the enumerator values.
```