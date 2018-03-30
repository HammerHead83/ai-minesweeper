using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVDSLabs.AI.Minesweeper.Utils
{
    internal sealed class ArrayUtils
    {
        public static int[] Create1DArrayAndZeroFill(int size)
        {
            int[] cpyArr = new int[size];
            Parallel.For(0, size, idx => cpyArr[idx] = 0);
            return cpyArr;
        }

        public static void FillArray(ref int[] arr, int value)
        {
            int[] cpyArr = arr;
            Parallel.For(0, arr.Length, idx => cpyArr[idx] = value);
            arr = cpyArr;
        }

        public static void SplitArray(ref int[] arr, int pos, out int[] leftArray, out int[] rightArray)
        {
            int lLen = pos, rLen = arr.Length - pos - 1;
            leftArray = new int[lLen];
            rightArray = new int[rLen];
            Array.ConstrainedCopy(arr, 0, leftArray, 0, lLen);
            Array.ConstrainedCopy(arr, pos + 1, rightArray, 0, rLen);
        }

        public static void ZeroFill2D(ref int[,] arr)
        {
            int h = arr.GetLength(0), w = arr.GetLength(1);
            for (int _h = 0; _h < h; _h++)
                for (int _w = 0; _w < w; _w++)
                    arr[_h, _w] = 0;
        }
        public static int[] Convert2DTo1D(ref int[,] arr)
        {
            int h = arr.GetLength(0), w = arr.GetLength(1);
            int[] result = new int[h * w];
            for (int _h = 0; _h < h; _h++)
            {
                for (int _w = 0; _w < w; _w++)
                {
                    int idx = _h * w + _w;
                    result[idx] = arr[_h, _w];
                }
            }
            return result;
        }

        public static int[,] Convert1DTo2D(ref int[] arr, int w)
        {
            int h = arr.Length / w;
            var result = Array.CreateInstance(typeof(int), h, w) as int[,];
            for (int _h = 0; _h < h; _h++)
            {
                for (int _w = 0; _w < w; _w++)
                {
                    int idx = _h * w + _w;
                    result[_h, _w] = arr[idx];
                }
            }
            return result;
        }
    }
}
