using Solver.Solver.Cube.Enums;

namespace Solver.Solver.Cube
{

    /// <summary>
    /// Collection of constants integers
    /// </summary>
    public static class Defs
    {
        // Map the corner positions to facelet positions.
        public static Facelet[][] CornerFacelet = { new[] {Facelet.U9, Facelet.R1, Facelet.F3}, new[] {Facelet.U7, Facelet.F1, Facelet.L3}, new[] {Facelet.U1, Facelet.L1, Facelet.B3}, new[] {Facelet.U3, Facelet.B1, Facelet.R3}, new[] {Facelet.D3, Facelet.F9, Facelet.R7}, new[] {Facelet.D1, Facelet.L9, Facelet.F7}, new[] {Facelet.D7, Facelet.B9, Facelet.L7}, new[] {Facelet.D9, Facelet.R9, Facelet.B7} };

        // Map the edge positions to facelet positions.
        public static Facelet[][] EdgeFacelet = { new[] {Facelet.U6, Facelet.R2}, new[] {Facelet.U8, Facelet.F2}, new[] {Facelet.U4, Facelet.L2}, new[] {Facelet.U2, Facelet.B2}, new[] {Facelet.D6, Facelet.R8}, new[] {Facelet.D2, Facelet.F8}, new[] {Facelet.D4, Facelet.L8}, new[] {Facelet.D8, Facelet.B8}, new[] {Facelet.F6, Facelet.R4}, new[] {Facelet.F4, Facelet.L6}, new[] {Facelet.B6, Facelet.L4}, new[] {Facelet.B4, Facelet.R6}};

        // Map the corner positions to Face colors.
        public static Color[][] CornerColor = { new[] {Color.U, Color.R, Color.F}, new[] {Color.U, Color.F, Color.L}, new[] {Color.U, Color.L, Color.B}, new[] {Color.U, Color.B, Color.R}, new[] {Color.D, Color.F, Color.R}, new[] {Color.D, Color.L, Color.F}, new[] {Color.D, Color.B, Color.L}, new[] {Color.D, Color.R, Color.B}};

        // Map the edge positions to Face colors.
        public static Color[][] EdgeColor = { new[] {Color.U, Color.R }, new[] {Color.U, Color.F}, new[] {Color.U, Color.L}, new[] {Color.U, Color.B}, new[] {Color.D, Color.R}, new[] {Color.D, Color.F}, new[] {Color.D, Color.L}, new[] {Color.D, Color.B}, new[] {Color.F, Color.R}, new[] {Color.F, Color.L}, new[] {Color.B, Color.L}, new[] {Color.B, Color.R}};


        public const int NPerm4 = 24;
        public const int NChoose8_4 = 70;
        public const int NMove = 18; // number of possible face moves

        public const int NTwist = 2187; // 3^7 possible corner orientations in phase 1
        public const int NFlip = 2048; // 2^11 possible edge orientations in phase 1
        public const int NSliceSorted = 11880; // 12*11*10*9 possible positions of the FR, FL, BL, BR edges in phase 1
        public const int NSlice = NSliceSorted / NPerm4; // we ignore the permutation of FR, FL, BL, BR in phase 1
        public const int NFlipSliceClass = 64430; // number of equivalence classes for combined flip+slice concerning symmetry group D4h

        public const int NUEdgesPhase2 = 1680; // number of different positions of the edges UR, UF, UL and UB in phase 2
        public const int NDEdgesPhase2 = 1680; // number of different positions of the edges DR, DF, DL and DB in phase 2
        public const int NCorners = 40320; // 8! corner permutations in phase 2
        public const int NCornersClass = 2768; // number of equivalence classes concerning symmetry group D4h
        public const int NUDEedges = 40320; // 8! permutations of the edges in the U-Sticker and D-Sticker in phase 2
        public const int Nsym = 48; // number of cube symmetries of full group Oh
        public const int NSynD4h = 16; // Number of symmetries of subgroup D4h
    }
}