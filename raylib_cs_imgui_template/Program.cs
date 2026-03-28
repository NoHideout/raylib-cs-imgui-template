using System.Numerics;
using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

namespace raylib_cs_imgui_template;

internal static class Program
{
    private static readonly Vector2 WindowSize = new Vector2(800, 600);
    private static readonly Vector2 WindowMinSize = new Vector2(320, 240);
    private static readonly Vector2 WindowMaxSize = new Vector2(1920, 1080);
    private const string WindowTitle = "raylib_cs_imgui_template";

    private static Camera2D _camera;
    private static Image _windowIcon;

    // STAThread is required if you deploy using NativeAOT on Windows
    // See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]
    public static void Main()
    {
        Initialize();
        LoadContent();
        while (!Raylib.WindowShouldClose())
        {
            Update(Raylib.GetFrameTime());
            
            Raylib.BeginDrawing();
            
            Draw();

            // ImGui rendering must be run between BeginDrawing and EndDrawing
            rlImGui.Begin();
            DrawImGui();
            rlImGui.End();
            
            Raylib.EndDrawing();
        }

        UnloadContent();
        
        Shutdown();
    }
    
    private static void Initialize()
    {
        // Set Config flags before initializing the window via:
        Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.ResizableWindow);
        // Initialize the window and ImGui
        Raylib.InitWindow((int)WindowSize.X, (int)WindowSize.Y, WindowTitle);
        
        // load and set your icon
        _windowIcon = Raylib.LoadImage("assets/icon.png");
        Raylib.SetWindowIcon(_windowIcon);
        
        // configure the windows size if it is resizeable
        Raylib.SetWindowMinSize((int)WindowMinSize.X, (int)WindowMinSize.Y);
        Raylib.SetWindowMaxSize((int)WindowMaxSize.X, (int)WindowMaxSize.Y);
        
        //Setup ImGui
        rlImGui.Setup(true);
        
        // Cap the FPS if Vsync isn't used
        //Raylib.SetTargetFPS(60);

        // a default camera for a quick start
        _camera = new Camera2D()
        {
            Zoom = 1.0f,
            Offset = new Vector2(WindowSize.X / 2.0f, WindowSize.Y / 2.0f),
            Target = new Vector2(0,0)
        };
    }
    
    private static void LoadContent()
    {
        // Example: Load a texture from the assets folder
        // myTexture = Raylib.LoadTexture("assets/my_image.png");
    }

    private static void Update(float deltaTime)
    {
        // Handle input and game logic here.
        // For example, update the camera target via arrow keys:
        if (Raylib.IsKeyDown(KeyboardKey.Up)) _camera.Target.Y += 100 * deltaTime;
        if (Raylib.IsKeyDown(KeyboardKey.Down)) _camera.Target.Y -= 100 * deltaTime;
        if (Raylib.IsKeyDown(KeyboardKey.Left)) _camera.Target.X += 100 * deltaTime;
        if (Raylib.IsKeyDown(KeyboardKey.Right)) _camera.Target.X -= 100 * deltaTime;
    }
    
    private static void Draw()
    {
        // Draw the entire screen in one singular color
        Raylib.ClearBackground(Color.Black);
        Raylib.BeginMode2D(_camera);
        Raylib.DrawRectangle(-25, -25, 50, 50, Color.Red);
        Raylib.EndMode2D();
        Raylib.DrawText("Hello, world! Use Arrow Keys to move camera.", 12, 12, 20, Color.White);
    }

    private static void DrawImGui()
    {
        // This is how you create a new window and display information in it.
        ImGui.Begin("Debug");
        ImGui.Text($"FPS: {Raylib.GetFPS()}");
        ImGui.Text($"Frame Time: {Raylib.GetFrameTime() * 1000:0.00} ms");
        ImGui.End();
        //ImGui.ShowDemoWindow();
    }
    
    private static void UnloadContent()
    {
        // Example: Unload your textures, sounds, and fonts here
        // Raylib.UnloadTexture(myTexture);
    }

    private static void Shutdown()
    {
        Raylib.UnloadImage(_windowIcon);
        // ImGui needs to be disposed before Raylib closes the window
        rlImGui.Shutdown();
        Raylib.CloseWindow();
    }
}