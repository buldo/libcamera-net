# libcamera-net
LibcameraNet

# About enum marshaling
I hope that this is true:
```
The Procedure Call Standard for the ARM 64-bit Architecture states that the size of enumeration types must be at least 32 bits.
The default is -fno-short-enums.
That is, the size of an enumeration type is at least 32 bits regardless of the size of the enumerator values.
```