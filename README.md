# raylib-cs-imgui-template
Simple starter template for Raylib-cs and rlImGui-cs.

## Project Structure
* `Program.cs` contains all of the code that you need to get started with Raylib and ImGui.
* `assets/` and its contents are automatically copied to the output directory during the build process using `PreserveNewest`.

## Usage
There are two ways to use this template.

### Option 1: Local Installation
This uses the .NET template system, which automatically replaces project name and namespaces.
```bash
git clone https://github.com/NoHideout/raylib-cs-imgui-template
dotnet new install ./raylib-cs-imgui-template
dotnet new raylib-imgui -n MyGame
```
To remove the template from your .NET Cli:
```bash
dotnet new uninstall raylib-cs-imgui-template
```
Note: If the above command fails, run `dotnet new uninstall` without any arguments to see the exact folder path you need to remove.

### Option 2: GitHub Template
Alternatively, you can use this repository as a starting point directly on GitHub by clicking the "Use this template" button at the top of the page to generate a new repository.

**Note: If you use this method, you will need to do a little manual cleanup:**
1. Manually rename the `.csproj` file, the `.sln` file, directories and the internal namespaces in `Program.cs` to match your new project.
2. Delete the `.template.config` folder, as your new project is a standalone app and no longer needs to act as a template.

## Dependencies
* [Raylib-cs](https://github.com/raylib-cs/raylib-cs) - C# bindings for [Raylib](https://github.com/raysan5/raylib)
* [rlImgui-cs](https://github.com/raylib-extras/rlImGui-cs) - C# integration for [Dear ImGui](https://github.com/ocornut/imgui)
