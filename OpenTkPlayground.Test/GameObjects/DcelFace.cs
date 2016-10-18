using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TestStack.BDDfy;

namespace OpenTkPlayground.Test.GameObjects
{
    public class DcelFace
    {
        [Fact]
        public void IteratorIsCorrectLength()
        {
            this.Given(_ => GivenAFaceWith3Edges())
                .When(_ => WhenIGetEdgeList())
                .Then(_ => TheListHasThreeItems())
                .BDDfy();
        }

        private void GivenAFaceWith3Edges()
        {
            throw new NotImplementedException();
        }

        private void WhenIGetEdgeList()
        {
            throw new NotImplementedException();
        }

        private void TheListHasThreeItems()
        {
            throw new NotImplementedException();
        }
    }
}
