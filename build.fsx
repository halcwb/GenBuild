// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------
System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

#load "paket-files/halcwb/GenBuild/scripts/targets.fsx"

// --------------------------------------------------------------------------------------
// Run all targets by default. Invoke 'build <Target>' to override


open Fake
#if MONO
#else
open SourceLink
#endif


Target "All" DoNothing

open System
open Fake.Testing
let testAssemblies = Settings.testAssemblies

Target "NUnit3" <| fun _ ->
    match !! testAssemblies with
    | tests when tests |> Seq.length > 0 ->
        Console.ForegroundColor <- ConsoleColor.Cyan
        tests
        |> NUnit3 (fun p ->
            { p with
                ShadowCopy = false
                TimeOut = TimeSpan.FromMinutes 20. })
        Console.ForegroundColor <- ConsoleColor.White
    | _ -> ()



"Clean"
  ==> "AssemblyInfo"
  ==> "Build"
  ==> "CopyBinaries"
  ==> "RunTests"
  ==> "GenerateReferenceDocs"
  ==> "GenerateDocs"
  ==> "All"
  =?> ("ReleaseDocs",isLocalBuild)

"All" 
#if MONO
#else
  =?> ("SourceLink", Pdbstr.tryFind().IsSome )
#endif
  ==> "NuGet"
  ==> "BuildPackage"

"CleanDocs"
  ==> "GenerateHelp"
  ==> "GenerateReferenceDocs"
  ==> "GenerateDocs"

"CleanDocs"
  ==> "GenerateHelpDebug"

"GenerateHelp"
  ==> "KeepRunning"
    
"ReleaseDocs"
  ==> "Release"

"BuildPackage"
  ==> "PublishNuget"
  ==> "Release"


RunTargetOrDefault "All"

