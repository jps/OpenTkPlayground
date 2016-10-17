using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTkPlayground.Geometry;
using OpenTK;
using OpenTK.Graphics;

namespace OpenTkPlayground.GameObjects
{
    public class Cube : GameObject
    {
        public Cube()
        {
            var vectors = new List<Vector3>()
            {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(1, 1, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),
                new Vector3(0, 1, 1)
            };



            //var wev1 = new WingedEdgeVertex
            //{
            //    ColouredVertex = new ColouredVertex(new Vector3(-1f * (0.01f * random.Next(100)), -1, -1), Color4.Lime),
            //    Edges = new List<WingedEdge>() { edge1, }
            //};

            //var wev2 = new WingedEdgeVertex
            //{
            //    ColouredVertex = new ColouredVertex(new Vector3(1, 1, -1), Color4.Red)
            //};

            //var wev3 = new WingedEdgeVertex
            //{
            //    ColouredVertex = new ColouredVertex(new Vector3(1f * (0.01f * random.Next(100)), -1, -1), Color4.Blue)
            //};

        }

        public override void Draw()
        {
            
        }
    }
}
