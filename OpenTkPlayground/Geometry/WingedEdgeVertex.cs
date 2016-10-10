using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;

namespace OpenTkPlayground.Geometry
{
    public class WingedEdgeVertex
    {    
        public ColouredVertex ColouredVertex { get; set; }

        public List<WingedEdge> Edges { get; set; }
    }
}
