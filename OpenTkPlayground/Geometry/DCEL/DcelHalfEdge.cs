namespace OpenTkPlayground.Geometry.DCEL
{
    public class DcelHalfEdge
    {
        public DcelHalfEdge Next { get; set; }

        public DcelHalfEdge Previous { get; set; }

        /// <summary>
        /// Twin to this half edge
        /// </summary>
        public DcelHalfEdge Twin { get; set; }
        
        /// <summary>
        /// Face on the left hand side
        /// </summary>
        public DcelFace IncidentFace { get; set; }

        /// <summary>
        /// The direction in which the edge is pointing
        /// </summary>
        public DcelVertex TargetVertex { get; set; }        
    }
}