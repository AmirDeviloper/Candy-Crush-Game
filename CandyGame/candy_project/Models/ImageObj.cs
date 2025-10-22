using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy_project.Models
{
    public class ImageObj
    {
        public string Name { get; set; }
        public Image Image { get; set; }

        public ImageObj(string name, Image image)
        {
            Name = name;
            Image = image;
        }

    }
}
