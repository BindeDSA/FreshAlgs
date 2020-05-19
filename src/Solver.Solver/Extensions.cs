using System;
using System.Linq;
using Solver.Solver.Cube;
using Solver.Solver.Cube.Enums;

namespace Solver.Solver
{
    public static class Extensions
    {
        public static int FirstIndexWhere<TSource>(this TSource[] source, Func<TSource, bool> predicate, int notFound = -1)
        {
            var i = 0;
            foreach (TSource item in source)
            {
                if (predicate.Invoke(item))
                {
                    return i;
                }
                i++;
            }

            return notFound;
        }

        public static int LastIndexWhere<TSource>(this TSource[] source, Func<TSource, bool> predicate, int notFound = -1)
        {
            var i = source.Length - 1;
            while (!predicate.Invoke(source[i]) && i >= 0)
            {
                i--;
            }
            return i >= 0 ? i : notFound;
        }

        public static TSource[] RotateRight<TSource>(this TSource[] source)
        {
            var returnArr = new TSource[source.Length];
            returnArr[0] = source[source.Length - 1];
            for (var i = 1; i < source.Length; i++)
            {
                returnArr[i] = source[i - 1];
            }
            return returnArr;
        }

        public static TSource[] RotateLeft<TSource>(this TSource[] source)
        {
            var returnArr = new TSource[source.Length];
            returnArr[source.Length - 1] = source[0];
            for (var i = 0; i < source.Length - 1; i++)
            {
                returnArr[i] = source[i + 1];
            }
            return returnArr;
        }


    }
}