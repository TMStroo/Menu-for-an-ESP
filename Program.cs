 using ImGuiNET;
using ClickableTransparentOverlay;
using System.Numerics;

namespace GooEyeTesting
{
    public class Program : Overlay
    {
        bool enableOverlay = false;
        Vector2 screenSize = new Vector2(1920, 1080);
        Vector2 drawPosition = new Vector2(150, 150);


        // Called every frame
        protected override void Render()
        {
            DrawMenu();
            DrawOverLay();
        }

        void DrawMenu()
        {
            ImGui.Begin("Main Menu");

            // Checkbox that toggles enableOverlay
            ImGui.Checkbox("Overlay", ref enableOverlay);
            ImGui.End();
        }
        void DrawOverLay()
        {
            if (enableOverlay)
            {
                ImGui.SetNextWindowSize(screenSize);
                ImGui.SetNextWindowPos(new Vector2(0, 0));
                ImGui.Begin("overlay", ImGuiWindowFlags.NoDecoration
                  | ImGuiWindowFlags.NoBackground
                  | ImGuiWindowFlags.NoBringToFrontOnFocus
                  | ImGuiWindowFlags.NoMove
                  | ImGuiWindowFlags.NoInputs
                  | ImGuiWindowFlags.NoCollapse
                  | ImGuiWindowFlags.NoScrollbar
                  | ImGuiWindowFlags.NoScrollWithMouse
                   );
                ImDrawListPtr drawList = ImGui.GetWindowDrawList();
                
                drawList.AddRect(drawPosition,Vector2.Add(drawPosition,new Vector2(300, 150)), ImGui.ColorConvertFloat4ToU32(new Vector4(0, 1, 0, 1)));
            }
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start().Wait(); // Start the overlay loop
        }
    }
}
