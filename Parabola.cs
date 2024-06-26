﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    public class Parabola:IElementSZ
    {
        public PointF[] PozicijaEl { get; }
        public float P { get; }
        public SlobodanZadatak SlobodanZadatak { get; set; }

        public Parabola(float p)
        {
            P = p;
        }
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            Pen olovka = new Pen(Color.Black, 3);
            int brTacaka = 30;
            PointF[] Gornje = new PointF[brTacaka];
            PointF[] Donje = new PointF[brTacaka];
            //y=sqrt(2p*x)
            float Pomeraj = 11f / (float)brTacaka;
            float x = 0;
            for (int i = 0; i < brTacaka; i++)
            {
                Gornje[i] = new PointF(x, Convert.ToSingle(Math.Sqrt(2*P*x)));
                Donje[i] = new PointF(x, -Gornje[i].Y);
                x += Pomeraj;
            }
            for (int i = 0; i < brTacaka; i++)
            {
                Gornje[i] = new PointF(centar.X + Gornje[i].X * strKvad, centar.Y - Gornje[i].Y * strKvad);
                Donje[i] = new PointF(centar.X + Donje[i].X * strKvad, centar.Y - Donje[i].Y * strKvad);
            }
            g.DrawCurve(olovka, Gornje,.7f);
            g.DrawCurve(olovka, Donje,.7f);
        }
    }
}