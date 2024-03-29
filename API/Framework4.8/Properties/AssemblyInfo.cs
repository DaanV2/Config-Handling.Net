﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

#if X64
[assembly: AssemblyTitle("ConfigHandling.Net X64")]
[assembly: AssemblyDescription("ConfigHandling.Net x64 takes care of all your config or options objects. It takes care of saving, loading, and persistence of objects in memory. Config objects are saved in a centralized location.")]
#else
#if AnyCpu
[assembly: AssemblyTitle("ConfigHandling.Net AnyCpu")]
[assembly: AssemblyDescription("ConfigHandling.Net AnyCpu takes care of all your config or options objects. It takes care of saving, loading, and persistence of objects in memory. Config objects are saved in a centralized location.")]
#else
[assembly: AssemblyTitle("ConfigHandling.Net x32")]
[assembly: AssemblyDescription("ConfigHandling.Net x32 takes care of all your config or options objects. It takes care of saving, loading, and persistence of objects in memory. Config objects are saved in a centralized location.")]
#endif
#endif

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
    [assembly: AssemblyConfiguration("RELEASE")]
#endif

//[assembly: AssemblyTitle("ConfigHandling.Net")]
//[assembly: AssemblyDescription("ConfigHandling.Net takes care of all your config or options objects. It takes care of saving, loading, and persistence of objects in memory. Config objects are saved in a centralized location.")]
[assembly: AssemblyCompany("Daan Verstraten")]
[assembly: AssemblyProduct("ConfigHandling.Net")]
[assembly: AssemblyCopyright("Copyright © Daan Verstraten 2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9b91c88f-52ff-42a9-83b6-2aed5d94249c")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.2.0.0")]
[assembly: AssemblyFileVersion("1.2.0.0")]
