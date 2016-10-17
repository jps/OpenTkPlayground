using System.Collections.Generic;

namespace OpenTkPlayground.Geometry.WingedEdge
{
    public class WingedEdgeVertex
    {    
        public ColouredVertex ColouredVertex { get; set; }

        public List<WingedEdge> Edges { get; set; }
    }
}
