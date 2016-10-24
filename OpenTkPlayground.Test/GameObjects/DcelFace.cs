using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using OpenTkPlayground.Geometry.DCEL;
using TestStack.BDDfy;
using Xunit;

namespace OpenTkPlayground.Test.GameObjects
{
    public class DcelFaceTests
    {
        private DcelFace _face;
        private IEnumerable<DcelHalfEdge> _expectedHalfEdges;
        private IEnumerable<DcelHalfEdge> _actualHalfEdges;

        [Fact]
        public void CanIterateOverFaceHalfEdges()
        {
            this.Given(_ => GivenAFaceWith3Edges())
                .When(_ => WhenIGetEdgeList())
                .Then(_ => TheListHasThreeItems())
                .Then(_ => ThenAllExpectedHalfEdgesAreReturned())
                .BDDfy();
        }

        private void GivenAFaceWith3Edges()
        {
            var a = new DcelHalfEdge();
            var b = new DcelHalfEdge();
            var c = new DcelHalfEdge();

            a.Next = b;
            b.Next = c;
            c.Next = a;

            _face = new DcelFace()
            {
                HalfEdge = a
            };

            _expectedHalfEdges = new[] { a, b, c };
        }

        private void WhenIGetEdgeList()
        {
            _actualHalfEdges = _face.HalfEdges();
        }

        private void TheListHasThreeItems()
        {
            _actualHalfEdges.Count().Should().Be(3);
        }

        private void ThenAllExpectedHalfEdgesAreReturned()
        {
            _expectedHalfEdges.All(ehe => _expectedHalfEdges.Contains(ehe)).Should().BeTrue();
        }
    }
}
