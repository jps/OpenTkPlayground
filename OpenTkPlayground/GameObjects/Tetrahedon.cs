using System;
using System.Collections.Generic;
using System.Linq;
using OpenTkPlayground.Geometry;
using OpenTkPlayground.Helpers;
using OpenTK;

namespace OpenTkPlayground.GameObjects
{
    public class RegularTetrahedron : GameObject
    {
        public RegularTetrahedron()
        {
            var random = new Random();
            random.Next(1000);

            var l = 1; 

            var vertices = new List<Vector3>()
            {
                new Vector3(0,          0,  0), 
                new Vector3(l,          0,  0), 
                new Vector3(l/2f,       0,  l),
                new Vector3((1.5f*l)/3, l,  l/3f), 
            };

            var wingedEdgedvertices = vertices.Select(position => new WingedEdgeVertex
            {
                ColouredVertex = new ColouredVertex(position, RandomColorGenerator.NextColor())
            });

            var triangles = new List<Tuple<int, int, int>>()
            {
                new Tuple<int, int, int>(0, 1, 3),
                new Tuple<int, int, int>(1, 2, 3),
                new Tuple<int, int, int>(0, 3, 2),
                new Tuple<int, int, int>(0, 2, 1),
            };

            triangles.Select(t => new WingedEdgeFace()
            {
                Edges = new List<WingedEdge>()
                {
                    new WingedEdge() {}
                }
            });



            var wingedEdges = new List<WingedEdge>()
            {
                new WingedEdge
                {

                }
            };


            //var edge1 = new WingedEdge();
            //var edge2 = new WingedEdge();
            //var edge3 = new WingedEdge();

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
