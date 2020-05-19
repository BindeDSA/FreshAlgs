using Solver.Solver.Cube.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solver.Solver.Cube
{
   public static class Conversions
    {
        public static FaceCube ToFaceCube(this CubieCube cubieCube)
        {
            var faceCube = new FaceCube();
            for (var i = 0; i < cubieCube.CO.Length; i++)
            {
                int perm = (int)cubieCube.CP[i];
                int ori = cubieCube.CO[i];

                for (int j = 0; j < 3; j++)
                {
                    faceCube.Facelets[(int)Defs.CornerFacelet[i][(j + ori) % 3]] = Defs.CornerColor[perm][j];
                }
            }
            for (var i = 0; i < cubieCube.EO.Length; i++)
            {
                int perm = (int)cubieCube.EP[i];
                int ori = cubieCube.EO[i];

                for (int j = 0; j < 2; j++)
                {
                    faceCube.Facelets[(int)Defs.EdgeFacelet[i][(j + ori) % 2]] = Defs.EdgeColor[perm][j];
                }
            }
            return faceCube;
        }

        public static CubieCube ToCubieCube(this FaceCube faceCube)
        {
            var facelets = faceCube.Facelets;
            var cubieCube = new CubieCube();
            cubieCube.CP = cubieCube.CP.Select((c) => Corner.Invalid).ToArray();
            cubieCube.EP = cubieCube.EP.Select((E) => Edge.Invalid).ToArray();


            for (var i = 0; i < Defs.CornerFacelet.Length; i++)
            {
                Facelet[] corner = Defs.CornerFacelet[i];
                int ori = -1;
                var color3 = Color.Invalid;
                var color2 = Color.Invalid;

                if (facelets[(int)corner[0]] == Color.U || facelets[(int)corner[0]] == Color.D)
                {
                    ori = 0;
                    color2 = facelets[(int)corner[1]];
                    color3 = facelets[(int)corner[2]];
                }
                else if (facelets[(int)corner[1]] == Color.U || facelets[(int)corner[1]] == Color.D)
                {
                    ori = 1;
                    color2 = facelets[(int)corner[2]];
                    color3 = facelets[(int)corner[0]];
                }
                else if (facelets[(int)corner[2]] == Color.U || facelets[(int)corner[2]] == Color.D)
                {
                    ori = 2;
                    color2 = facelets[(int)corner[0]];
                    color3 = facelets[(int)corner[1]];
                }

                cubieCube.CP[i] = (Corner)Defs.CornerColor.FirstIndexWhere(cornerC => cornerC[1] == color2 && cornerC[2] == color3, (int)Corner.Invalid);
                cubieCube.CO[i] = ori;
            }

            for (var i = 0; i < Defs.EdgeFacelet.Length; i++)
            {
                Facelet[] edge = Defs.EdgeFacelet[i];
                foreach (Color[] edgeColors in Defs.EdgeColor)
                {

                    if (edgeColors[0] == facelets[(int)edge[0]] && edgeColors[1] == facelets[(int)edge[1]])
                    {
                        cubieCube.EP[i] = (Edge)i;
                        cubieCube.EO[i] = 0;
                    }
                    else if (edgeColors[0] == facelets[(int)edge[0]] && edgeColors[1] == facelets[(int)edge[1]])
                    {
                        cubieCube.EP[i] = (Edge)i;
                        cubieCube.EO[i] = 1;
                    }
                }
            }

            return cubieCube;
        }
    }
}
