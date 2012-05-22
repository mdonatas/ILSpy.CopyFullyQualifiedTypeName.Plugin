# CopyFullyQualifiedTypeName plugin for ILSpy

This plugin adds two context menu entries for type definitions in type explorer tree. Just right click on a class or interface definition and you will get an option to copy fully qualified type name.

## Install notes

To install plugins for ILSpy you need to copy *.Plugin.dll file next to ILSpy.exe.

Already compiled plugin is provided in [Plugin][1] folder.

## Compiling

To compile plugin you will need to add references to these files

 - ILSpy.exe
 - ICSharpCode.TreeView.dll
 - Mono.Cecil.dll

  [1]: tree/master/Plugin