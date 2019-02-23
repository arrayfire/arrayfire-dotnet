# ArrayFire Binding in .NET Standard



[![NuGet](https://img.shields.io/nuget/dt/ArrayFire.svg)](https://www.nuget.org/packages/ArrayFire)
[![Documentation Status](https://readthedocs.org/projects/arrayfirenet/badge/?version=latest)](https://arrayfirenet.readthedocs.io/en/latest/?badge=latest)
[![Build status](https://ci.appveyor.com/api/projects/status/gn6tppgryu0axd1p?svg=true)](https://ci.appveyor.com/project/Haiping-Chen/arrayfire-dotnet)

[ArrayFire](https://github.com/arrayfire/arrayfire) is a high performance library for parallel computing with an easy-to-use API. It enables users to write scientific computing code that is portable across CUDA, OpenCL and CPU devices. This project provides .NET bindings for the ArrayFire library. It conforms to .NET Standard 2.x, so it can be used from any .net Language such as C# or F#

### Prerequisites

- The latest version of ArrayFire. You can get ArrayFire using one of the following:
    - [Download binary installers](http://www.arrayfire.com/download)
    - [Build from source](https://github.com/arrayfire/arrayfire)

- .NET Core 2.x or .NET Framework 4.x SDK:

    - [.NET Downloads](https://dotnet.microsoft.com/download)

- Visual Studio 2015 or above.

    - [Download Visual Studio 2017 Community Free](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx)

    


### Contents

- `Wrapper/`: Contains the C# source code for the .net ArrayFire wrapper library. This is the library that you need to reference from your project.

- `AutoGenTool/`: Contains the F# source code for a tool that automatically generates part of the library code. Not meant to be used by consumers of the library.

- `Examples/`: contains a few examples demonstrating the usage from both C# and F#

### Usage

1. Install from NuGet

   `PM> Install-Package ArrayFire`

- Refer to the Examples folder.

- Or run in command line

  `dotnet "HelloWorld (CSharp).dll"`

Documentation
---------------

- Refer [here](https://readthedocs.org/projects/arrayfirenet).

