using candy_project.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy_project.Models.Candies
{
    internal class EvilCandy : Candy
    {
        public override ImageObj Image()
        {
            return new ImageObj("evil_candy", Resources.evil_candy);
        }

        public override int Point()
        {
            return -10;
        }
    }
    
}
