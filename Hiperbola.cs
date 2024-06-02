using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    internal class Hiperbola:IElementSZ
    {
        public PointF[] PozicijaEl { get; }
        public float A { get; }
        public float B { get; }
        public SlobodanZadatak SlobodanZadatak { get; set; }

        public Hiperbola(float a, float b)
        {
            A = a;
            B = b;
        }
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            Pen olovka = new Pen(Color.Black, 3);
            PointF[] leveGornje = new PointF[10];
            PointF[] leveDonje = new PointF[10];
            PointF[] DesneGornje = new PointF[10];
            PointF[] DesneDonje = new PointF[10];
            float Pomeraj = (10 - A) / 9;
            //y=sqrt((x*x*b*b)/(a*a) - b*b)
            for (int i = 0; i < 10; i++)
            {
                float x = Convert.ToSingle(Math.Round(-10 + i * Pomeraj,2));
                leveGornje[i] = new PointF(x, Convert.ToSingle(Math.Sqrt((x * x * B * B) / (A * A) - B * B)));
                leveDonje[i] = new PointF(x, -leveGornje[i].Y);
                DesneGornje[i] = new PointF(-x, leveGornje[i].Y);
                DesneDonje[i] = new PointF(-x, -leveGornje[i].Y);
            }
            for (int i = 0; i < 10; i++)
            {
                leveGornje[i] = new PointF(centar.X + leveGornje[i].X * strKvad, centar.Y - leveGornje[i].Y * strKvad);
                leveDonje[i] = new PointF(centar.X + leveDonje[i].X * strKvad, centar.Y - leveDonje[i].Y * strKvad);
                DesneGornje[i] = new PointF(centar.X + DesneGornje[i].X * strKvad, centar.Y - DesneGornje[i].Y * strKvad);
                DesneDonje[i] = new PointF(centar.X + DesneDonje[i].X * strKvad, centar.Y - DesneDonje[i].Y * strKvad);
            }
            g.DrawCurve(olovka, leveGornje, .4f);
            g.DrawCurve(olovka, leveDonje, .4f);
            g.DrawCurve(olovka, DesneGornje, .4f);
            g.DrawCurve(olovka, DesneDonje, .4f);
        }
    }
}
