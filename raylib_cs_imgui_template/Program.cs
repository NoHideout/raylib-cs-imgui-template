using System.Numerics;
using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

namespace raylib_cs_imgui_template;

internal static class Program
{
    private static readonly Vector2 WindowSize = new Vector2(800, 600);
    private const string WindowTitle = "raylib_cs_imgui_template";

    // STAThread is required if you deploy using NativeAOT on Windows
    // See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]
    public static void Main()
    {
        // Set Config flags before initializing the window via:
        Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.ResizableWindow);
        
        // Initialize the window and ImGui
        Raylib.InitWindow((int)WindowSize.X, (int)WindowSize.Y, WindowTitle);
        Raylib.SetWindowMinSize(320, 240);
        rlImGui.Setup(true);
        
        // Cap the FPS if Vsync isn't used
        //Raylib.SetTargetFPS(60);
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            
            // Draw the entire screen in one singular color
            Raylib.ClearBackground(Color.Black);
            
            // Add text in the upper left corner
            Raylib.DrawText("Hello, world!", 12, 12, 20, Color.White);
            
            // ImGui rendering must be run between BeginDrawing and EndDrawing
            rlImGui.Begin();
            ImGui.ShowDemoWindow();
            rlImGui.End();
            
            Raylib.EndDrawing();
        }
        // ImGui needs to be disposed before Raylib closes the window
        rlImGui.Shutdown();
        Raylib.CloseWindow();
    }
}