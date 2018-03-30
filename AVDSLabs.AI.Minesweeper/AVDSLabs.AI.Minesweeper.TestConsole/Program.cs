using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVDSLabs.AI.Minesweeper.Utils;

namespace AVDSLabs.AI.Minesweeper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new BoardGenerator(4, 3);
            int coord1D = generator.Determine1DPositionFrom2DCoord(1, 2);
            Console.WriteLine("[{0}:{1}] : {2}", 1, 2, coord1D);
        }
    }
}
