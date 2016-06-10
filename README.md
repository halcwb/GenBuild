# GenBuild
Generic build and doc generating scripts.

## Build Status

Mono | .NET | 
---- | ---- | 
[![Mono CI Build Status](https://img.shields.io/travis/halcwb/GenBuild/master.svg)](https://travis-ci.org/halcwb/GenBuild) | 
[![.NET Build Status](https://img.shields.io/appveyor/ci/halcwb/GenBuild/master.svg)](https://ci.appveyor.com/project/halcwb/GenBuild)


# Background
Enables a generic build setup using a specific `settings.fsx` script to provide build specific details.

# Design
This repository uses an explicit opt-in `.gignore` strategy, meaning that all files are excluded unless specifically included via the `.gitignore` file.
