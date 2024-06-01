using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeomProj
{

    public interface ICrtanje
    {
        PointF PozicijaEl { get; }
        void Nacrtaj(Graphics g, Point centar, int strKvad);
    }
}
