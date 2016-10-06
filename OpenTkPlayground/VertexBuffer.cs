using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTkPlayground
{
    internal sealed class VertexBuffer<TVertex> : IDisposable where TVertex : struct // vertices must be structs so we can copy them to GPU memory easily
    {
        private readonly int _vertexSize;
        private TVertex[] _vertices = new TVertex[4];

        private int _count;

        private readonly int _handle;

        public VertexBuffer(int vertexSize)
        {
            _vertexSize = vertexSize;

            // generate the actual Vertex Buffer Object
            _handle = GL.GenBuffer();
        }

        public void AddVertex(TVertex v)
        {
            // resize array if too small
            if (_count == _vertices.Length)
                Array.Resize(ref _vertices, _count * 2);
            // add vertex
            _vertices[_count] = v;
            _count++;
        }

        public void Bind()
        {
            // make this the active array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, _handle);
        }

        public void BufferData()
        {
            // copy contained vertices to GPU memory
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(_vertexSize * _count),
                _vertices, BufferUsageHint.StreamDraw);
        }

        public void Draw()
        {
            // draw buffered vertices as triangles
            GL.DrawArrays(PrimitiveType.Triangles, 0, _count);
        }

        private bool _disposed;
        public void Dispose()
        {
            DisposeInternal();
            GC.SuppressFinalize(this);
        }

        private void DisposeInternal()
        {
            if (_disposed)
                return;

            if (GraphicsContext.CurrentContext == null || GraphicsContext.CurrentContext.IsDisposed)
                return;

            GL.DeleteBuffer(_handle);

            GC.SuppressFinalize(this);

            this._disposed = true;
        }

        ~VertexBuffer()
        {
            Dispose();
        }
    }
}
