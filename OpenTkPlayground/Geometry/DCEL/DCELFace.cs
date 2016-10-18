using System.Collections.Generic;

namespace OpenTkPlayground.Geometry.DCEL
{
    internal class DcelFace
    {
        /// <summary>
        /// A single edge which is part of this face
        /// </summary>
        public DcelHalfEdge HalfEdge { get; set; }

        public IEnumerable<DcelHalfEdge> HalfEdges()
        {
            var currentHalfEdge = HalfEdge;

            do
            {
                var halfEdgeToYeild = currentHalfEdge;

                currentHalfEdge = HalfEdge.Next;

                yield return halfEdgeToYeild;                
            } while (currentHalfEdge != HalfEdge);
        }

    }
}
