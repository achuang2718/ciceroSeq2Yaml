# ciceroSeq2Yaml

## Purpose
Translate Cicero .seq binaries into (mostly) human readable .yaml, which can then be parsed in your favorite language.

## Usage
Run the executable from command line with two command line args:
```
>>> cd CiceroParser\CiceroParser\bin\Release\netcoreapp3.1
>>> CiceroParser.exe MYSEQFILEPATH MYYAMLPATH
```

This will take a Cicero .seq file at `MYSEQFILEPATH` and output a .yaml file at `MYYAMLPATH`.

Solution source files are included for modification and manual builds in Visual Studio.

## Dependencies
Uses YamlDotNet library from NuGet, as well as the pre-built DataStructures.dll and dotMath.dll from https://akeshet.github.io/Cicero-Word-Generator/.
