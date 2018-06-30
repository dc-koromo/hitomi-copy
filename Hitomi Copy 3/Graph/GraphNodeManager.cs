/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hitomi_Copy_3.Graph
{
    public class GraphNodeManager
    {
        public delegate void IterateVertex(GraphVertex p);

        List<GraphVertex> vertexs;
        List<GraphEdge> edges;

        public GraphNodeManager()
        {
            vertexs = new List<GraphVertex>();
            edges = new List<GraphEdge>();

            vertexs.Add(new GraphVertex()
            {
                Position = new Point(0, 0),
                Radius = 100.0F,
                Color = Color.White,
                InnerText = "Center",
                OuterText = "Sex"
            });

            for (int i = 0; i < 30; i++)
            {
                GraphVertex v = new GraphVertex();
                v.Position = new Point((int)(Math.Cos(2 * Math.PI / 30 * i) * 200), (int)(Math.Sin(2 * Math.PI / 30 * i) * 200));
                v.Radius = 20;
                v.Color = Color.Cyan;
                v.InnerText = i.ToString();
                v.OuterText = $"Sex Child : {i.ToString()}";
                vertexs.Add(v);
            }
        }

        public void IterateVertexs(IterateVertex ic)
        {
            foreach (var v in vertexs)
            {
                ic(v);
            }
        }
    }

}
