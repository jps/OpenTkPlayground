using System;
using System.Linq;
using OpenTkPlayground.Geometry.DCEL;
using OpenTkPlayground.Helpers;
using OpenTK;

namespace OpenTkPlayground.GameObjects
{
    public class RegularTetrahedron : GameObject
    {
        DcelFace[] _faces;

        public RegularTetrahedron()
        {
            var random = new Random();
            random.Next(1000);

            const float l = 0.20f; 

            var vertices = new[]
            {
                new DcelVertex(new ColouredVertex(new Vector3(0,          0,  0), RandomColorGenerator.NextColor())),
                new DcelVertex(new ColouredVertex(new Vector3(l,          0,  0), RandomColorGenerator.NextColor())),
                new DcelVertex(new ColouredVertex(new Vector3(l/2f,       0,  -l), RandomColorGenerator.NextColor())),
                new DcelVertex(new ColouredVertex(new Vector3((1.5f*l)/3, l,  -l/3f), RandomColorGenerator.NextColor()))
            };

            var edges = Enumerable.Range(0, 12).Select( x => new DcelHalfEdge()).ToArray();
            
            _faces = Enumerable.Range(0, 4).Select(x => new DcelFace()).ToArray();

            //f0
            _faces[0].HalfEdge = edges[0];

            //e0
            edges[0].IncidentFace = _faces[0];
            edges[0].TargetVertex = vertices[1];
            edges[0].Next = edges[1];
            edges[0].Previous = edges[2];
            edges[0].Twin = edges[3];
            //e1
            edges[1].IncidentFace = _faces[0];
            edges[1].TargetVertex = vertices[2];
            edges[1].Next = edges[2];
            edges[1].Previous = edges[0];
            edges[1].Twin = edges[6];
            //e2
            edges[2].IncidentFace = _faces[0];
            edges[2].TargetVertex = vertices[0];
            edges[2].Next = edges[0];
            edges[2].Previous = edges[1];
            edges[2].Twin = edges[9];

            //f1
            _faces[1].HalfEdge = edges[3];
            //e3
            edges[3].IncidentFace = _faces[1];
            edges[3].TargetVertex = vertices[0];
            edges[3].Next = edges[4];
            edges[3].Previous = edges[5];
            edges[3].Twin = edges[0];
            //e4
            edges[4].IncidentFace = _faces[1];
            edges[4].TargetVertex = vertices[3];
            edges[4].Next = edges[5];
            edges[4].Previous = edges[3];
            edges[4].Twin = edges[11];
            //e5
            edges[5].IncidentFace = _faces[1];
            edges[5].TargetVertex = vertices[1];
            edges[5].Next = edges[3];
            edges[5].Previous = edges[4];
            edges[5].Twin = edges[7];

            //f2
            _faces[2].HalfEdge = edges[6];
            //e6
            edges[6].IncidentFace = _faces[2];
            edges[6].TargetVertex = vertices[1];
            edges[6].Next = edges[7];
            edges[6].Previous = edges[8];
            edges[6].Twin = edges[1];
            //e7
            edges[7].IncidentFace = _faces[2];
            edges[7].TargetVertex = vertices[3];
            edges[7].Next = edges[8];
            edges[7].Previous = edges[6];
            edges[7].Twin = edges[5];
            //e8
            edges[8].IncidentFace = _faces[2];
            edges[8].TargetVertex = vertices[2];
            edges[8].Next = edges[6];
            edges[8].Previous = edges[7];
            edges[8].Twin = edges[10];

            //f3
            _faces[3].HalfEdge = edges[9];
            //e9
            edges[9].IncidentFace = _faces[3];
            edges[9].TargetVertex = vertices[2];
            edges[9].Next = edges[10];
            edges[9].Previous = edges[11];
            edges[9].Twin = edges[2];
            //e10
            edges[10].IncidentFace = _faces[3];
            edges[10].TargetVertex = vertices[3];
            edges[10].Next = edges[11];
            edges[10].Previous = edges[9];
            edges[10].Twin = edges[8];
            //e11
            edges[11].IncidentFace = _faces[3];
            edges[11].TargetVertex = vertices[0];
            edges[11].Next = edges[9];
            edges[11].Previous = edges[10];
            edges[11].Twin = edges[4];
        }

        internal void Draw(VertexBuffer<ColouredVertex> vertexBuffer)
        {
            var verticies = _faces.SelectMany(f => f.HalfEdges().Select(he => he.TargetVertex));

            foreach (var vertex in verticies)
            {
                vertexBuffer.AddVertex(vertex.Vertex);
            }
        }

        public override void Draw()
        {
            
        }
    }
}
