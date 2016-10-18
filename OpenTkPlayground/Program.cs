using System;
using System.IO;
using System.Linq;
using OpenTkPlayground.GameObjects;
using OpenTkPlayground.Uniforms;
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
                VertexBuffer<ColouredVertex> vertexBuffer = null;
                ShaderProgram shaderProgram = null;
                VertexArray<ColouredVertex> vertexArray = null;
                Matrix4Uniform projectionMatrix = null; 

                win.Load += (s, e) =>
                {
                    var vertexShader = new Shader(ShaderType.VertexShader,
                        File.ReadAllText(@"../../VertexShaders/vertex-shader.vs"));
                    var fragmentShader = new Shader(ShaderType.FragmentShader,
                        File.ReadAllText(@"../../FragmentShaders/fragment-shader.fs"));

                    // link shaders into shader program
                    shaderProgram = new ShaderProgram(vertexShader, fragmentShader);
                    
                    // create projection matrix uniform
                    projectionMatrix = new Matrix4Uniform("projectionMatrix")
                    {
                        Matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, 16f/9, 0.1f, 100f)
                    };

                };
                win.Unload += (s, e) => { /* dispose global GL resources here */ };
                win.RenderFrame += (s, e) =>
                {
                    GL.ClearColor(128, 0, 1, 256);
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    //http://genericgamedev.com/tutorials/opengl-in-csharp-an-object-oriented-introduction-to-opentk/4/

                    // activate shader program and set uniforms
                    shaderProgram.Use();
                    projectionMatrix.Set(shaderProgram);

                    // bind vertex buffer and array objects
                    vertexBuffer.Bind();
                    vertexArray.Bind();

                    // upload vertices to GPU and draw them
                    vertexBuffer.BufferData();
                    vertexBuffer.Draw();

                    // reset state for potential further draw calls (optional, but good practice)
                    GL.BindVertexArray(0);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                    GL.UseProgram(0);

                    // swap backbuffer
                    win.SwapBuffers();
                };
                win.Resize += (s, e) =>
                {
                    GL.Viewport(0, 0, win.Width, win.Height);
                };

                long updateCount = 0;
                var random = new Random();
                

                win.UpdateFrame += (s, e) =>
                {
                    

                    // create and fill a vertex buffer
                    vertexBuffer = new VertexBuffer<ColouredVertex>(ColouredVertex.Size);

                    //foreach (var i in Enumerable.Range(0, random.Next(100, 1000)))
                    //{                        
                    //    vertexBuffer.AddVertex(new ColouredVertex(new Vector3(-1f * (0.01f * updateCount), -1, -i), Color4.Lime));
                    //    vertexBuffer.AddVertex(new ColouredVertex(new Vector3(1, 1, -i), Color4.Red));
                    //    vertexBuffer.AddVertex(new ColouredVertex(new Vector3(1f * (0.01f * updateCount), -1, -i), Color4.Blue));
                    //}

                    var tetrahedron = new RegularTetrahedron();

                    tetrahedron.Draw(vertexBuffer);



                    // create vertex array to specify vertex layout
                    vertexArray = new VertexArray<ColouredVertex>(
                        vertexBuffer, shaderProgram,
                        new VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, ColouredVertex.Size, 0),
                        new VertexAttribute("vColor", 4, VertexAttribPointerType.Float, ColouredVertex.Size, 12)
                        );

                    ++updateCount;
                };                

                win.Run();
            }            
        }
    }
}
