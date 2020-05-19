using System.Collections.Generic;
using Solver.Solver;
using Xunit;

namespace Solver.Tests.Solver
{
    public class ExtensionsFacts
    {
        public class FistIndexWhereFacts
        {
            [Fact]
            public void FindsElementIndex()
            {
                var list = new[] { 0, 1, 2 };
                for (var i = 0; i < list.Length; i++)
                {
                    Assert.Equal(i, list.FirstIndexWhere(elem => elem == i));
                }
            }

            [Fact]
            public void ReturnsNotFoundVal()
            {
                var list = new[] { -1, -1, -1 };

                for (var i = 0; i < list.Length; i++)
                {
                    Assert.Equal(4, list.FirstIndexWhere(elem => elem == i, 4));
                }
            }
        }

        public class LastIndexWhereFacts
        {
            [Fact]
            public void FindsLastElementIndex()
            {
                var list = new[] { 0, 1, 1 };
                Assert.Equal(2, list.LastIndexWhere(elem => elem == 1));
            }

        }

        public class RotateRightFacts
        {
            [Fact]
            public void CorrectsRotatedLeft()
            {
                var rotatedLeftArray = new[] { 1, 2, 3, 0 };
                var array = rotatedLeftArray.RotateRight();
                for (var i = 0; i < array.Length; i++)
                {
                    Assert.Equal(i, array[i]);
                }
            }
        }

        public class RotateLeftFacts
        {
            [Fact]
            public void CorrectsRotatedRight()
            {
                var rotateRightArray = new[] { 3, 0, 1, 2 };
                var array = rotateRightArray.RotateLeft();

                for (var i = 0; i < array.Length; i++)
                {
                    Assert.Equal(i, array[i]);
                }
            }
        }
    }
}