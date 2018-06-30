/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_3.Analysis;
using Hitomi_Copy_3.Graph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class GraphViewer : Form
    {
        string tag;

        public GraphViewer(string tag = "")
        {
            InitializeComponent();

            this.tag = tag;
            //graph_control.BackColor = Color.FromArgb(40, 40, 50);
        }
        
        private void GraphViewer_Load(object sender, EventArgs e)
        {
            if (tag != "")
            {
                var rnd = new Random();
                var result = HitomiAnalysisRelatedTags.Instance.result[tag]; //.OrderBy(item => rnd.Next());

                int index = 0;
                int eindex = 0;

                GraphVertex v = new GraphVertex();
                v.Index = index++;
                v.Color = Color.White;
                v.InnerText = tag;
                v.OuterText = "";
                v.Radius = 100.0F;
                v.Nodes = new List<Tuple<GraphVertex, GraphEdge>>();

                foreach (var ld in result)
                {
                    GraphVertex vt = new GraphVertex();
                    GraphEdge et = new GraphEdge();
                    vt.Index = index++;
                    vt.Color = Color.WhiteSmoke;
                    vt.InnerText = ld.Item1;
                    vt.Radius = 100.0F;
                    vt.OuterText = "";

                    et.StartsIndex = 0;
                    et.EndsIndex = vt.Index;
                    et.Index = eindex++;
                    et.Text = ld.Item2.ToString().Substring(0, Math.Min(5, ld.Item2.ToString().Length));
                    et.Thickness = 6.0F; //(float)(ld.Item2 * 100);
                    et.Color = Color.Black;

                    v.Nodes.Add(new Tuple<GraphVertex, GraphEdge> (vt, et));
                }
                List<Tuple<Point, double>> edges = new List<Tuple<Point, double>>();
                for (int i = 0; i < v.Nodes.Count; i++)
                {
                    for (int j = i+1; j < v.Nodes.Count; j++)
                    {
                        var list = HitomiAnalysisRelatedTags.Instance.result[v.Nodes[i].Item1.InnerText].Where(x => x.Item1 == v.Nodes[j].Item1.InnerText);

                        if (list.Count() > 0)
                        {
                            edges.Add(new Tuple<Point, double> (new Point(i+1, j+1), list.ToList()[0].Item2));
                        }
                    }
                }
                graph_control.GetGNM().Nomalize(v, edges);
            }
        }
    }
}
