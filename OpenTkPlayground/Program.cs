using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTkPlayground
{
    class Program
    {
        static void Main(string[] args)
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
                    // Rendercode goes here
                    GL.ClearColor(0.8f, 0.8f, 1.0f, 1.0f);
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    float[] vertexData =
                    {
                        -1.0f, 1.0f, -5.0f,
                        1.0f, 1.0f, -5.0f,
                        -1.0f, -1.0f, -5.0f
                    };

                    float[] colorData = {
                        0.8f, 0.8f, 1.0f, 1.0f,
                        0.8f, 0.8f, 1.0f, 1.0f,
                        0.8f, 0.8f, 1.0f, 1.0f
                    };

                    //Setup index buffer
                    ushort[] indices = new ushort[] { 0, 1, 2, 3 };

                    int indexBufferId;
                    GL.GenBuffers(1, out indexBufferId);
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBufferId);
                    GL.BufferData(
                        BufferTarget.ElementArrayBuffer,
                        (IntPtr)(indices.Length * sizeof(ushort)),
                        indices,
                        BufferUsageHint.StaticDraw);

                    //Setup vertex buffer
                    int vertexBufferObjectId;
                    GL.GenBuffers(1, out vertexBufferObjectId);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectId);
                    GL.BufferData(BufferTarget.ArrayBuffer,
                        (IntPtr)(sizeof(float) * vertexData.Length),
                        vertexData,
                        BufferUsageHint.StaticDraw);

                    //Setup color buffer
                    int colorBufferId;
                    GL.GenBuffers(1, out colorBufferId);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, colorBufferId);
                    GL.BufferData(
                        BufferTarget.ArrayBuffer,
                        (IntPtr)(colorData.Length * sizeof(float)),
                        colorData,
                        BufferUsageHint.StaticDraw);

                    // Bind vertex buffer:
                    GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectId);
                    GL.EnableClientState(ArrayCap.VertexArray);
                    GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero);

                    // Bind color buffer:
                    GL.BindBuffer(BufferTarget.ArrayBuffer, colorBufferId);
                    GL.EnableClientState(ArrayCap.ColorArray);
                    GL.ColorPointer(4, ColorPointerType.Float, 0, IntPtr.Zero);

                    // Bind index buffer:
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBufferId);

                    GL.DrawElements(PrimitiveType.Triangles, 3, DrawElementsType.UnsignedShort, IntPtr.Zero);

                    // Disable:
                    GL.DisableClientState(ArrayCap.VertexArray);
                    GL.DisableClientState(ArrayCap.ColorArray);


                    //GL.Clear(ClearBufferMask.ColorBufferBit);
                    win.SwapBuffers();
                };
                win.Run();
            }

        }
    }
}
