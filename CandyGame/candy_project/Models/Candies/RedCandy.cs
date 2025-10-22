using candy_project.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy_project.Models.Candies
{
    public class RedCandy : Candy
    {
        public override ImageObj Image()
        {
            return new ImageObj("red_candy", Resources.red_candy);
        }

        public override int Point()
        {
            return 6;
        }
    }
}
