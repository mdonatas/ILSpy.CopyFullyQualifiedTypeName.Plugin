# CopyFullyQualifiedTypeName plugin for ILSpy

This plugin adds two context menu entries for type definitions in type explorer tree. Just right click on a class or interface definition and you will get an option to copy fully qualified type name to clipboard.

![CopyFullyQualifiedTypeName plugin context menu][3]

## Install notes

To install plugins for ILSpy you need to copy *.Plugin.dll file next to ILSpy.exe.

Already compiled plugin is provided in [Plugin][1] folder. [[direct link]][2]

## Compiling

To compile plugin you will need to add references to these files

 - ILSpy.exe
 - ICSharpCode.TreeView.dll
 - Mono.Cecil.dll

  [1]: ILSpy.CopyFullyQualifiedTypeName.Plugin/tree/master/Plugin
  [2]: ILSpy.CopyFullyQualifiedTypeName.Plugin/raw/master/Plugin/ILSpy.CopyFullyQualifiedTypeName.Plugin.dll
  [3]: ILSpy.CopyFullyQualifiedTypeName.Plugin/readme/context_menu.png