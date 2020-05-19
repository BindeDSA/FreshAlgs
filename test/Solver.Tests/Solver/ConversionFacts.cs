using Solver.Solver.Cube;
using Solver.Solver;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Solver.Tests.Solver
{
    public class ConversionFacts
    {
        public class ToCubieCubeMethod
        {
            [Fact]
            public void NewFaceCubeEqualsNewCubieCube()
            {
                Assert.Equal(new FaceCube().ToCubieCube(), new CubieCube());
            }
        }
        public class ToFaceCubeMethod
        {
            [Fact]
            public void NewCubieCubeIsNewFaceCube()
            {
                Assert.Equal(new CubieCube().ToFaceCube(), new FaceCube());
            }
            [Fact]
            public void RTurnOriCanBeReverses()
            {
                var cubieCube = new CubieCube(co: new[] { 2, 0, 0, 1, 1, 0, 0, 2 });

                Assert.Equal(cubieCube, cubieCube.ToFaceCube().ToCubieCube());
            }
        }
    }
}
