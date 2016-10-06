using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTkPlayground
{
    internal sealed class Shader
    {
        private readonly int _handle;

        public int Handle => _handle;

        public Shader(ShaderType type, string code)
        {
            // create shader object
            _handle = GL.CreateShader(type);

            // set source and compile shader
            GL.ShaderSource(_handle, code);
            GL.CompileShader(_handle);
        }
    }

    internal sealed class ShaderProgram
    {
        private readonly int _handle;

        public ShaderProgram(params Shader[] shaders)
        {
            // create program object
            _handle = GL.CreateProgram();

            // assign all shaders
            foreach (var shader in shaders)
                GL.AttachShader(_handle, shader.Handle);

            // link program (effectively compiles it)
            GL.LinkProgram(_handle);

            // detach shaders
            foreach (var shader in shaders)
            {
                GL.DetachShader(_handle, shader.Handle);
            }                
        }

        public void Use()
        {
            // activate this program to be used
            GL.UseProgram(_handle);
        }
        public int GetUniformLocation(string name)
        {
            // get the location of a uniform variable
            return GL.GetUniformLocation(_handle, name);
        }

        public int GetAttributeLocation(string name)
        {
            // get the location of a vertex attribute
            return GL.GetAttribLocation(_handle, name);
        }
    }
}
