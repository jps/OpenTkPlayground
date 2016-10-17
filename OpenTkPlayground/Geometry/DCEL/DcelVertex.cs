namespace OpenTkPlayground.Geometry.DCEL
{
    internal class DcelVertex
    {
        public DcelVertex()
        {
        }

        public DcelVertex(ColouredVertex vertex)
        {
            Vertex = vertex;
        }


        public ColouredVertex Vertex { get; set; }
    }
}