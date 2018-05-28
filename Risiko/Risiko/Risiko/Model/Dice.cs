using System;
using System.Collections.Generic;
using System.Text;

namespace Risiko.Model
{
    public class Dice
    {
        private static Random rnd = new Random();
        public static int dial()
        {
            return rnd.Next(0, 7);
        }
    }
}
