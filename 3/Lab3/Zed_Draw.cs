﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.DataFormats;

namespace Lab3
{
    public partial class Zed_Draw : Form
    {
        private double epsilon = 1e-6; 
        private void zedGraph_MouseClick(object sender, MouseEventArgs e)
        {
            double x, y;

            zedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);

            string text = string.Format("X: {0};    Y: {1}", x, y);
            coordLabel.Text = text;
        }
        private double f(double x)
        {
            return Math.Sin(x) / (2 + Math.Cos(x));
        }
        private double fDiv(double x)
        {
            return (Math.Sin(x) * Math.Sin(x) + Math.Cos(x) * Math.Cos(x) + 2 * Math.Cos(x)) / (4 + 4 * Math.Cos(x) + Math.Cos(x) * Math.Cos(x));
        }
        private void DrawGraphZed()
        {

            GraphPane pane = zedGraph.GraphPane;

            pane.CurveList.Clear();

            PointPairList list = new PointPairList();
            PointPairList fDivList = new PointPairList();

            double xmin = Math.PI * -10;
            double xmax = Math.PI * 10;

            for (double x = xmin; x <= xmax; x += 0.01)
            {
                if (Math.Abs(x) < epsilon && Math.Abs(f(x)) < epsilon)
                {
                    string text = string.Format("X: {0};    Y: {1}", x, f(x));
                }
                list.Add(x, f(x));
            }
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                if (Math.Abs(x) < epsilon && Math.Abs(f(x)) < epsilon)
                {
                    string text = string.Format("X: {0};    Y: {1}", x, f(x));
                }
                fDivList.Add(x, fDiv(x));
            }

            LineItem myCurve = pane.AddCurve("f", list, Color.Blue, SymbolType.None);
            LineItem myCurve1 = pane.AddCurve("fDiv", fDivList, Color.Red, SymbolType.None);

            zedGraph.AxisChange();

        }

        public Zed_Draw()
        {
            
            InitializeComponent();
            DrawGraphZed();
        }
        public Zed_Draw(Menu f)
        {
            
            InitializeComponent();
            Zeros.AppendText("Zeros: 2πn \r\n" + Environment.NewLine);
            Zeros.AppendText("Zeros of the derivative: -2π/3 + 2πn, 2π/3 + 2πn");
            DrawGraphZed();
        }
    }
}