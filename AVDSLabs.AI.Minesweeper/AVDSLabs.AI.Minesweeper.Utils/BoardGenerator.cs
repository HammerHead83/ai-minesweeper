using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVDSLabs.AI.Minesweeper.Utils
{
    public sealed class BoardGenerator
    {
        public int[,] FullArray { get; private set; }
        public int MinesCount => _minesCount;
        
        private int[] _fullArray1D;
        private int _minesCount = 0;

        private readonly int _szHeight, _szWidth;
        private readonly int _sz1DArray;
        
        
        public BoardGenerator(int szWidth, int szHeight)
        {
            _szHeight = szHeight;
            _szWidth = szWidth;
            _sz1DArray = szHeight * szWidth;
            _fullArray1D = ArrayUtils.Create1DArrayAndZeroFill(_sz1DArray);
            FullArray = new int[szHeight, szWidth];
        }

        public bool GenerateValues(int xCoord, int yCoord, int minesCount)
        {
            int coord1D = Determine1DPositionFrom2DCoord(xCoord, yCoord);
            bool result = GenerateMinesArray(coord1D, minesCount);
            if (!result)
                return false;
            //
            return result;
        }
        
        private bool GenerateMinesArray(int coord1D, int minesCount)
        {
            if (minesCount > _sz1DArray - 1)
                return false;
            if (minesCount == _sz1DArray)
            {
                ArrayUtils.FillArray(ref _fullArray1D, -1);
                _fullArray1D[coord1D] = 0;
                FullArray = ArrayUtils.Convert1DTo2D(ref _fullArray1D, _szWidth);
                return true;
            }
            _minesCount = minesCount;
            var rnd = new Random();
            while (minesCount > 0)
            {
                int pos = rnd.Next(_sz1DArray);
                for (; pos < _sz1DArray; ++pos)
                {
                    if (_fullArray1D[pos] == 0 && pos != coord1D)
                    {
                        _fullArray1D[pos] = -1;
                        --minesCount;
                        break;
                    }
                    if (pos == _sz1DArray)
                    {
                        pos = -1;
                        continue;
                    }
                }
            }
            FullArray = ArrayUtils.Convert1DTo2D(ref _fullArray1D, _szWidth);
            return true;
        }

        public int Determine1DPositionFrom2DCoord(int xCoord, int yCoord) => yCoord * _szWidth + xCoord;
    }
}
