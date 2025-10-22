using candy_project.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy_project.Models.Candies
{
    public class WhiteCandy : Candy
    {
        public override ImageObj Image()
        {
            return new ImageObj("white_candy", Resources.white_candy);
        }

        public override int Point()
        {
            return 50;
        }
    }
}
