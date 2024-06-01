using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeomProj
{
    public class Prava : IElementSZ//abc implicitni, kn eksplicitni
    {
        public SlobodanZadatak SlobodanZadatak { get; set; }
        public PointF PozicijaEl { get; set; }
        public float N { get;}
        public float K { get;}
        public float A { get;}
        public float B { get;}
        public float C { get;}
        public Prava( PointF pozicijaEl, float n, float k)
        {
            PozicijaEl = pozicijaEl;
            N = n;
            K = k;
        }
        public Prava(PointF pozicijaEl, float a, float b, float c)
        {
            PozicijaEl = pozicijaEl;
            A = a;
            B = b;
            C = c;
            (K,N) = UEksplicitni();
        }
        public (float, float) UEksplicitni()
        {
            float k, n;
            k = -(A / B);
            n = -(C / A);
            return (k, n);
        }
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            PointF A = new PointF();
            PointF B = new PointF();

            //ima 6 slucajeva za odredjivanje granicnih tacaka u odnosu na maxX i maxY i minX i minY
            float presekDesno = IzracunajY(10), presekLevo = IzracunajY(-10);
            float presekGore = IzracunajX(10), presekDole = IzracunajX(-10);

            PointF[] preseci = new PointF[4];
            preseci[0] = new PointF(10, IzracunajY(10));
            preseci[1] = new PointF(-10, IzracunajY(-10));
            preseci[2] = new PointF(IzracunajX(10), 10);
            preseci[3] = new PointF(IzracunajX(-10), -10);
            int br = 0;
            for (int i = 0; i < 4; i++)
            {
                if (preseci[i].X >= -10 && preseci[i].X <= 10 && preseci[i].Y >= -10 && preseci[i].Y <= 10)
                {
                    A.X = centar.X + preseci[i].X * strKvad;
                    A.Y = centar.Y - preseci[i].Y * strKvad;
                    br = i;
                    break;
                }
            }
            for (int i = br + 1; i < 4; i++)
            {
                if (preseci[i].X >= -10 && preseci[i].X <= 10 && preseci[i].Y >= -10 && preseci[i].Y <= 10)
                {
                    B.X = centar.X + preseci[i].X * strKvad;
                    B.Y = centar.Y - preseci[i].Y * strKvad;
                    break;
                }
            }
            Pen olovka = new Pen(Color.Black, 3);
            g.DrawLine(olovka, A, B);
        }
        public float IzracunajY(float x)
        {
            return this.K*x + this.N;
        }
        public float IzracunajX(float y)
        {
            return (y - this.N)/this.K;
        }
    }
}
