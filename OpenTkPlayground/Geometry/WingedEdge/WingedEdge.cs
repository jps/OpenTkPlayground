namespace OpenTkPlayground.Geometry.WingedEdge
{
    public class WingedEdge
    {
        public WingedEdgeVertex VertexStart { get; set; }

        public WingedEdgeVertex VertexEnd { get; set; }

        public WingedEdgeFace FaceLeft { get; set; }

        public WingedEdgeFace FaceRight { get; set; }

        public WingedEdge PreviousCounterclockwise { get; set; }

        public WingedEdge NextCounterclockwise { get; set; }

        public WingedEdge PreviousCLockwise { get; set; }

        public WingedEdge NextCLockwise { get; set; }
    }
}
