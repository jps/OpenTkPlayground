using System.Collections.Generic;

namespace OpenTkPlayground.Geometry.DCEL
{
    public class DcelFace
    {
        /// <summary>
        /// A single edge which is part of this face
        /// </summary>
        public DcelHalfEdge HalfEdge { get; set; }

        public IEnumerable<DcelHalfEdge> HalfEdges()
        {
            yield return HalfEdge;
                      
            var currentHalfEdge = HalfEdge.Next;

            while (currentHalfEdge != HalfEdge)
            {
                yield return currentHalfEdge;
                currentHalfEdge = currentHalfEdge.Next;
            }
        }

    }
}
