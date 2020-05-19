using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solver.Solver.Cube.Enums;

namespace Solver.Solver.Cube
{
    /// <summary>
    /// Represents a cube defined piece by piece, each with it's own orientation
    ///</summary>
    public class CubieCube
    {

        /// <summary>Collection of moves defined by new position and orientation of each pieces</summary>
        private struct Moves
        {

            public static (Corner[] CP, int[] CO, Edge[] EP, int[] EO) U = (
                CP: new[] { Corner.Ubr, Corner.Urf, Corner.Ufl, Corner.Ulb, Corner.Dfr, Corner.Dlf, Corner.Dbl, Corner.Drb },
                CO: new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                EP: new[] { Edge.UB, Edge.UR, Edge.UF, Edge.UL, Edge.DR, Edge.DF, Edge.DL, Edge.DB, Edge.FR, Edge.FL, Edge.BL, Edge.BR },
                EO: new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            public static (Corner[] CP, int[] CO, Edge[] EP, int[] EO) R = (
                CP: new[] { Corner.Dfr, Corner.Ufl, Corner.Ulb, Corner.Urf, Corner.Drb, Corner.Dlf, Corner.Dbl, Corner.Ubr },
                CO: new[] { 2, 0, 0, 1, 1, 0, 0, 2 },
                EP: new[] { Edge.FR, Edge.UF, Edge.UL, Edge.UB, Edge.BR, Edge.DF, Edge.DL, Edge.DB, Edge.DR, Edge.FL, Edge.BL, Edge.UR },
                EO: new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            public static (Corner[] CP, int[] CO, Edge[] EP, int[] EO) F = (
                CP: new[] { Corner.Ufl, Corner.Dlf, Corner.Ulb, Corner.Ubr, Corner.Urf, Corner.Dfr, Corner.Dbl, Corner.Drb },
                CO: new[] { 1, 2, 0, 0, 2, 1, 0, 0 },
                EP: new[] { Edge.UR, Edge.FL, Edge.UL, Edge.UB, Edge.DR, Edge.FR, Edge.DL, Edge.DB, Edge.UF, Edge.DF, Edge.BL, Edge.BR },
                EO: new[] { 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0 });

            public static (Corner[] CP, int[] CO, Edge[] EP, int[] EO) D = (
                CP: new[] { Corner.Urf, Corner.Ufl, Corner.Ulb, Corner.Ubr, Corner.Dlf, Corner.Dbl, Corner.Drb, Corner.Dfr },
                CO: new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                EP: new[] { Edge.UR, Edge.UF, Edge.UL, Edge.UB, Edge.DF, Edge.DL, Edge.DB, Edge.DR, Edge.FR, Edge.FL, Edge.BL, Edge.BR },
                EO: new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            public static (Corner[] CP, int[] CO, Edge[] EP, int[] EO) L = (
                CP: new[] { Corner.Urf, Corner.Ulb, Corner.Dbl, Corner.Ubr, Corner.Dfr, Corner.Ufl, Corner.Dlf, Corner.Drb },
                CO: new[] { 0, 1, 2, 0, 0, 2, 1, 0 },
                EP: new[] { Edge.UR, Edge.UF, Edge.BL, Edge.UB, Edge.DR, Edge.DF, Edge.FL, Edge.DB, Edge.FR, Edge.UL, Edge.DL, Edge.BR },
                EO: new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            public static (Corner[] CP, int[] CO, Edge[] EP, int[] EO) B = (
                CP: new[] { Corner.Urf, Corner.Ufl, Corner.Ubr, Corner.Drb, Corner.Dfr, Corner.Dlf, Corner.Ulb, Corner.Dbl },
                CO: new[] { 0, 0, 1, 2, 0, 0, 2, 1 },
                EP: new[] { Edge.UR, Edge.UF, Edge.UL, Edge.BR, Edge.DR, Edge.DF, Edge.DL, Edge.BL, Edge.FR, Edge.FL, Edge.UB, Edge.DB },
                EO: new[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1 });
        }

        public Corner[] CP { get; set; }
        public int[] CO { get; set; }
        public Edge[] EP { get; set; }
        public int[] EO { get; set; }

        /// <summary>Creates a new solved cube</summary>
        public CubieCube()
        {
            CP = Enumerable.Range(0, 8).Cast<Corner>().ToArray();
            CO = new int[8];
            EP = Enumerable.Range(0, 12).Cast<Edge>().ToArray();
            EO = new int[12];
        }

        /// <summary>Creates a cube based on a full or partial set of coords</summary>
        public CubieCube(Corner[] cp = null, int[] co = null, Edge[] ep = null, int[] eo = null)
        {
            CP = cp ?? Enumerable.Range(0, 8).Cast<Corner>().ToArray();
            CO = co ?? new int[8];
            EP = ep ?? Enumerable.Range(0, 12).Cast<Edge>().ToArray();
            EO = eo ?? new int[12];
        }


        /// <summary>The cube coords as a string</summary>
        public override string ToString()
        {
            return "CP: " + string.Join(" ", CP) +
                "\nCO: " + string.Join(" ", CO) +
                "\nEP: " + string.Join(" ", EP) +
                "\nEO: " + string.Join(" ", EO);
        }

        /// <summary>Determines equality based on coords</summary>
        public override bool Equals(object obj)
        {
            if (!(obj is CubieCube) || obj == null)
            {
                return false;
            }

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return CornerOriCoord ^ CornerPermCoord ^ EdgeOriCoord ^ EdgePermCoord;
        }

        public static bool operator ==(CubieCube left, CubieCube right)
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

        public static bool operator !=(CubieCube left, CubieCube right)
        {
            return !(left == right);
        }

        /// <summary>The orientation coord of the 8 corners. Coord = [0, 2186(3^7 - 1)]</summary>
        public int CornerOriCoord
        {
            get
            {
                var value = 0;
                for (var i = 0; i < 7; i++)
                {
                    value = value * 3 + CO[i];
                }
                return value;
            }
            set
            {

                if (0 > value || value > 2186)
                {
                    throw new ArgumentException("twist is limited to the [0, 2187]", nameof(value));
                }

                var parity = 12;

                for (var i = 6; i >= 0; i--)
                {

                    CO[i] = value % 3;
                    parity -= value % 3;
                    value /= 3;
                }

                CO[7] = parity % 3;
            }
        }

        /// <summary>The orientation coord of the 12 edges. Coord = [0, 2047(2^11 - 1)]</summary>
        public int EdgeOriCoord
        {
            get
            {
                var value = 0;
                for (var i = 0; i < 11; i++)
                {
                    value = value * 2 + EO[i];
                }
                return value;
            }
            set
            {
                if (0 > value || value > 2047)
                {
                    throw new ArgumentException("the coord is limited to [0, 2047]", nameof(value));
                }

                var parity = 10;

                for (var i = 10; i >= 0; i--)
                {
                    EO[i] = value % 2;
                    parity -= value % 2;
                    value /= 2;
                }

                EO[11] = parity % 2;
            }
        }

        /// <summary>The corner permutation coord. Coord = [0, 40319(8! - 1)]</summary>
        public int CornerPermCoord
        {
            get
            {
                var value = 0;
                for (var i = 7; i > 0; i--)
                {
                    var above = 0;
                    for (var j = 0; j < i; j++)
                    {
                        if (CP[i] < CP[j])
                        {
                            above++;
                        }
                    }
                    value = (value + above) * i;
                }

                return value;
            }
            set
            {
                if (0 > value || value > 40319)
                {
                    throw new ArgumentException("the coord is limited to [0, 40319]", nameof(value));
                }

                var used = new[] { false, false, false, false, false, false, false, false };
                var order = new int[8];
                for (var i = 0; i < 8; i++)
                {
                    order[i] = value % (i + 1);
                    value /= i + 1;
                }

                for (var i = 7; i >= 0; i--)
                {
                    var curr = used.LastIndexWhere(val => !val);
                    for (int j = order[i]; j > 0; j--)
                    {

                        do
                        {
                            curr--;
                        } while (used[curr]);
                    }

                    CP[i] = (Corner) curr;
                    used[curr] = true;
                }
            }
        }

        public int EdgePermCoord
        {
            get
            {

                var value = 0;
                for (var i = 11; i > 0; i--)
                {
                    var above = 0;
                    for (var j = 0; j < i; j++)
                    {
                        if (EP[i] < EP[j])
                        {
                            above++;
                        }
                    }
                    value = (value + above) * i;
                }

                return value;
            }
            set
            {

                if (0 > value || value > 479001599)
                {
                    throw new ArgumentException("the coord is limited to [0, 479001599]", nameof(value));
                }

                var used = new[] { false, false, false, false, false, false, false, false, false, false, false, false };
                var order = new int[12];
                for (var i = 0; i < 12; i++)
                {
                    order[i] = value % (i + 1);
                    value /= i + 1;
                }

                for (var i = 11; i >= 0; i--)
                {
                    var curr = used.LastIndexWhere(val => !val);
                    for (int j = order[i]; j > 0; j--)
                    {

                        do
                        {
                            curr--;
                        } while (used[curr]);
                    }

                    EP[i] = (Edge)curr;
                    used[curr] = true;
                }
            }
        }
    }
}