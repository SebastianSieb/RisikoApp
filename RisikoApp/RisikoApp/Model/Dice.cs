using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisikoApp.Model
{
    public static class Dice
    {
        private static Random rnd = new Random();
        public static int dial()
        {
            return rnd.Next(0, 7);
        }
    }
}
