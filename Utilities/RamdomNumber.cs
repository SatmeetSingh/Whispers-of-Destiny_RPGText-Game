using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Utilities
{
    class RandomNumber
    {
        public static int RandomCase()
        {
            Random random = new Random();
            int randomNum = random.Next(1,10);
            return randomNum;
        }
    }
}
