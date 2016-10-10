using OpenTK;
using OpenTK.Graphics;

namespace OpenTkPlayground
{
    public struct ColouredVertex
    {
        public const int Size = (3 + 4) * 4; // size of struct in bytes

        private readonly Vector3 _position;
        private readonly Color4 _color;

        public ColouredVertex(Vector3 position, Color4 color)
        {
            _position = position;
            _color = color;
        }
    }
}
