namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("GenBuild")>]
[<assembly: AssemblyProductAttribute("GenBuild")>]
[<assembly: AssemblyCompanyAttribute("halcwb")>]
[<assembly: AssemblyDescriptionAttribute("A dummy library to test a generic build script")>]
[<assembly: AssemblyVersionAttribute("0.1.0")>]
[<assembly: AssemblyFileVersionAttribute("0.1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.0"
    let [<Literal>] InformationalVersion = "0.1.0"
