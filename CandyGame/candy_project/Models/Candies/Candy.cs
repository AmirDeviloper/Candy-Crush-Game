using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy_project.Models
{
    public abstract class Candy
    {
        public abstract int Point();
        public abstract ImageObj Image();

        public bool isEqual(Candy candy)
        {
            return Image().Name == candy.Image().Name;
        }

    }

}
