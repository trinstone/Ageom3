using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AgeomProj
{
    public static class RadnaPovrsina
    {
        public static void IzracunajPolja(Form forma, out Point gornjiLevi,out Point centar, out int duzinaStr)
        {
            Point gL = new Point();
            centar = new Point();
            if (forma.Width >= forma.Height)
            {
                gL.X = (forma.ClientSize.Width - forma.ClientSize.Height) / 2;
                gL.Y = 0;
                gornjiLevi = gL;
                duzinaStr = forma.ClientSize.Height - forma.ClientSize.Height % 20;
            }
            else
            {
                gL.X = 0;
                gL.Y = (forma.ClientSize.Height - forma.ClientSize.Width) / 2;
                gornjiLevi = gL;
                duzinaStr = forma.ClientSize.Width - forma.ClientSize.Width % 20;
            }
            centar.X = gornjiLevi.X + duzinaStr / 2;
            centar.Y = gornjiLevi.Y + duzinaStr / 2;
        }
        public static void ucitajPozadinu(Graphics g, Form forma)
        {
            Point gornjiLevi;
            Point centar;
            int duzinaStr;
            IzracunajPolja(forma, out gornjiLevi, out centar, out duzinaStr);
            int strKvad = duzinaStr / 20;
            Pen pozadina = new Pen(Color.FromArgb(192, 192, 192), 1);
            Point gornja = new Point();
            gornja.X = gornjiLevi.X;
            gornja.Y = gornjiLevi.Y;
            Point donja = new Point();
            donja.X = gornjiLevi.X;
            donja.Y = gornjiLevi.Y + duzinaStr;
            Point leva = new Point();
            leva.X = gornjiLevi.X;
            leva.Y = gornjiLevi.Y;
            Point desna = new Point();
            desna.X = leva.X + duzinaStr;
            desna.Y = gornjiLevi.Y;
            for (int i = 0; i < duzinaStr / strKvad; i++)
            {
                g.DrawLine(pozadina, gornja, donja);
                g.DrawLine(pozadina, leva, desna);
                gornja.X += strKvad;
                donja.X += strKvad;
                leva.Y += strKvad;
                desna.Y += strKvad;
            }
            pozadina.Color = Color.Black;
            pozadina.Width = 5;
            g.DrawLine(pozadina, gornjiLevi, new Point(gornjiLevi.X + duzinaStr, gornjiLevi.Y));//gornja granica
            g.DrawLine(pozadina, new Point(gornjiLevi.X, gornjiLevi.Y + duzinaStr), new Point(gornjiLevi.X + duzinaStr, gornjiLevi.Y + duzinaStr));//donja granica
            g.DrawLine(pozadina, gornjiLevi, new Point(gornjiLevi.X, gornjiLevi.Y + duzinaStr));//leva granica
            g.DrawLine(pozadina, new Point(gornjiLevi.X + duzinaStr, gornjiLevi.Y), new Point(gornjiLevi.X + duzinaStr, gornjiLevi.Y + duzinaStr));//desna granica
        }
    }
}
