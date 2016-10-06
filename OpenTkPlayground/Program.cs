using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTkPlayground
{
    internal sealed class Program
    {
        public static void Main(string[] args)
        {

            using (var win = new GameWindow(1280, 720, GraphicsMode.Default, "OpenTK Intro",
                GameWindowFlags.Default, DisplayDevice.Default,
                // ask for an OpenGL 3.0 forward compatible context
                3, 0, GraphicsContextFlags.ForwardCompatible))
            {
                win.Load += (s, e) => { /* init global GL resources here */ };
                win.Unload += (s, e) => { /* dispose global GL resources here */ };
                win.RenderFrame += (s, e) =>
                {
                    GL.ClearColor(128, 0, 1, 256);
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    //http://genericgamedev.com/tutorials/opengl-in-csharp-an-object-oriented-introduction-to-opentk/4/

                    win.SwapBuffers();
                };
                win.Resize += (s, e) =>
                {
                    GL.Viewport(0, 0, win.Width, win.Height);
                };
                win.UpdateFrame += (s, e) =>
                {
                    // this is called every frame, put game logic here
                };                

                win.Run();
            }            
        }
    }
}
