namespace OpenTkPlayground.Geometry.DCEL
{
    public class DcelVertex
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