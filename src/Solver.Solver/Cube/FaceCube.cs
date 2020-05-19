using System;
using System.Linq;
using Solver.Solver.Cube.Enums;

namespace Solver.Solver.Cube
{
    /// <summary>
    /// Represents a cube by stickers ordered as defined by the Sticker enum
    /// </summary>
    public class FaceCube
    {
        public Color[] Facelets;

        public FaceCube()
        {
            var faces = (Color[])Enum.GetValues(typeof(Color));
            Facelets = faces.SkipLast(1).SelectMany(face => new[] { face, face, face, face, face, face, face, face, face }).ToArray();
        }

        public override string ToString()
        {
            return string.Join("", Facelets.Select(face => face.ToString()));
        }

        public void FromString(string faceString)
        {

            if (faceString.Length != 54)
                throw new ArgumentException("String must contain 54 characters", nameof(faceString));

            if (faceString.GroupBy(stickerChar => stickerChar).Any(stickerGroup => stickerGroup.Count() != 9))
                throw new ArgumentException("String must contain 9 stickers per face", nameof(faceString));
            
            Facelets = faceString.Select(stickerChar => (Color)Enum.Parse(typeof(Color), stickerChar.ToString())).ToArray();
        }

        public override bool Equals(object obj)
        {
            return ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(FaceCube left, FaceCube right)
        {
            if (ReferenceEquals(left, null))
            {
                if (ReferenceEquals(right, null))
                {
                    return true;
                }

                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(FaceCube left, FaceCube right)
        {
            return !(left == right);
        }

        //    public CubieCube ToCubieCube()
        //    {
        //        var cubieCube = new CubieCube();
        //        cubieCube.CP = cubieCube.CP.Select((c) => Corner.Invalid).ToArray();
        //        cubieCube.EP = cubieCube.EP.Select((e) => Edge.Invalid).ToArray();


        //        for (var i = 0; i < Defs.CornerFacelet.Length; i++)
        //        {
        //            (Facelet, Facelet, Facelet) corner = Defs.CornerFacelet[i];
        //            int ori = -1;
        //            var color3 = Color.Invalid;
        //            var color2 = Color.Invalid;

        //            if (Facelets[(int)corner.Item1] == Color.U || Facelets[(int)corner.Item1] == Color.D)
        //            {
        //                ori = 0;
        //                color2 = Facelets[(int)corner.Item2];
        //                color3 = Facelets[(int)corner.Item3];
        //            }
        //            else if (Facelets[(int)corner.Item2] == Color.U || Facelets[(int)corner.Item2] == Color.D)
        //            {
        //                ori = 1;
        //                color2 = Facelets[(int)corner.Item3];
        //                color3 = Facelets[(int)corner.Item1];
        //            }
        //            else if (Facelets[(int)corner.Item3] == Color.U || Facelets[(int)corner.Item3] == Color.D)
        //            {
        //                ori = 2;
        //                color2 = Facelets[(int)corner.Item1];
        //                color3 = Facelets[(int)corner.Item2];
        //            }

        //            cubieCube.CP[i] = (Corner)Defs.CornerColor.FirstIndexWhere(cornerC => cornerC.Item2 == color2 && cornerC.Item3 == color3, (int)Corner.Invalid);
        //            cubieCube.CO[i] = ori;
        //        }

        //        for (var i = 0; i < Defs.EdgeFacelet.Length; i++)
        //        {
        //            (Facelet, Facelet) edge = Defs.EdgeFacelet[i];
        //            foreach ((Color, Color) edgeColors in Defs.EdgeColor)
        //            {

        //                if (edgeColors.Item1 == Facelets[(int)edge.Item1] && edgeColors.Item2 == Facelets[(int)edge.Item2])
        //                {
        //                    cubieCube.EP[i] = (Edge)i;
        //                    cubieCube.EO[i] = 0;
        //                }
        //                else if (edgeColors.Item1 == Facelets[(int)edge.Item1] && edgeColors.Item2 == Facelets[(int)edge.Item2])
        //                {
        //                    cubieCube.EP[i] = (Edge)i;
        //                    cubieCube.EO[i] = 1;
        //                }
        //            }
        //        }

        //        return cubieCube;
        //    }
    }
}