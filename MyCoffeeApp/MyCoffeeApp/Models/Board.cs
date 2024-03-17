using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffeeApp.Models
{
    public class Board
    {
        public int[,] CellValues {  get; set; }
        public bool[,] CellStatus {get; set; }
        public bool Solved {  get; set; }

    }
}
