using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.ES11;

namespace OpenTkPlayground.GameObjects
{
    public abstract class GameObject
    {
        //Global position of the object - objects vertexs will be relative to this position
        public Vector3 Position;

        public abstract void Draw();
    }
}
