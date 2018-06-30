/* Copyright (C) 2018. Hitomi Parser Developers */

using System.Collections.Generic;

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
                Position = new System.Drawing.Point(0, 0),
                Radius = 100.0F,
                Color = System.Drawing.Color.White
            });
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
