using Solver.Solver.Cube;
using Solver.Solver.Cube.Enums;
using Xunit;

namespace Solver.Tests.Solver.Cube
{
    public class CubieCubeFacts
    {
        public class CornerOriCoordFacts
        {
            [Fact]
            public void NewCubeCoordIsZero()
            {
                Assert.Equal(0, new CubieCube().CornerOriCoord);
            }

            [Fact]
            public void RTurnCubeCoordIsCorrect()
            {
                Assert.Equal(1494, new CubieCube(co: new[] {2, 0, 0, 1, 1, 0, 0, 2}).CornerOriCoord);
            }

            [Fact]
            public void SettingCoordReverses()
            {
                var cubieCube = new CubieCube();
                for (var i = 0; i <= 2186; i++)
                {
                    cubieCube.CornerOriCoord = i;
                    Assert.Equal(i, cubieCube.CornerOriCoord);
                }
            }

            [Fact]
            public void SettingCoordParityCorrect()
            {
                var cubieCube = new CubieCube();

                cubieCube.CornerOriCoord = 0;
                Assert.Equal(0, cubieCube.CO[7]);

                cubieCube.CornerOriCoord = 1;
                Assert.Equal(2, cubieCube.CO[7]);

                cubieCube.CornerOriCoord = 2;
                Assert.Equal(1, cubieCube.CO[7]);
            }
        }

        public class EdgeOriCoordFacts
        {
            [Fact]
            public void NewCubeCoordIsZero()
            {
                Assert.Equal(0, new CubieCube().EdgeOriCoord);
            }

            [Fact]
            public void SettingCoordReverses()
            {
                var cubieCube = new CubieCube();
                for (var i = 0; i <= 2047; i++)
                {
                    cubieCube.EdgeOriCoord = i;
                    Assert.Equal(i, cubieCube.EdgeOriCoord);
                }
            }

            [Fact]
            public void SettingCoordParityCorrect()
            {
                var cubieCube = new CubieCube();

                Assert.Equal(0, cubieCube.EO[11]);

                cubieCube.EdgeOriCoord = 1;
                Assert.Equal(1, cubieCube.EO[11]);
            }
        }

        public class CornerPermCoordFacts
        {
            [Fact]
            public void NewCubeCoordIsZero()
            {
                Assert.Equal(0, new CubieCube().CornerPermCoord);
            }

            [Fact]
            public void RTurnCubeCoordIsCorrect()
            {
                Assert.Equal(21021, new CubieCube(cp: new[] { Corner.Dfr, Corner.Ufl, Corner.Ulb, Corner.Urf, Corner.Drb, Corner.Dlf, Corner.Dbl, Corner.Ubr }).CornerPermCoord);
            }


            [Fact]
            public void SettingCoordReverses()
            {
                var cubieCube = new CubieCube();
                for (var i = 0; i <= 40319; i++)
                {
                    cubieCube.CornerPermCoord = i;
                    if (i != cubieCube.EdgeOriCoord)
                    {
                        break;
                    }
                    Assert.Equal(i, cubieCube.CornerPermCoord);
                }
            }
        }

        public class EdgePermCoordFacts
        {
            [Fact]
            public void NewCubeCoordIsZero()
            {
                Assert.Equal(0, new CubieCube().EdgePermCoord);
            }

            [Fact]
            public void RTurnCubeCoordIsCorrect()
            {
                Assert.Equal(443289849, new CubieCube(ep: new[] { Edge.FR, Edge.UF, Edge.UL, Edge.UB, Edge.BR, Edge.DF, Edge.DL, Edge.DB, Edge.DR, Edge.FL, Edge.BL,
                    Edge.UR }).EdgePermCoord);
            }

            [Fact]
            public void SettingCoordReverses()
            {
                var cubieCube = new CubieCube();
                for (var i = 0; i <= 479001599; i += 10000)
                {
                    cubieCube.EdgePermCoord = i;
                    Assert.Equal(i, cubieCube.EdgePermCoord);
                }
            }
        }
    }
}