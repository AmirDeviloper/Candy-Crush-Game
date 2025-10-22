using candy_project.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy_project.Models.Candies
{
    public class MagentaCandy : Candy
    {
        public override ImageObj Image()
        {
            return new ImageObj("magenta_candy", Resources.magenta_candy);
        }

        public override int Point()
        {
            return 25;
        }
        
    }
}
