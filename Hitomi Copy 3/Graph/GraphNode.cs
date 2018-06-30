/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hitomi_Copy_3.Graph
{
    public class GraphEdge
    {
        public string Text;
        public Color Color;
        public float Thickness;
        public Point starts;
        public Point ends;
    }

    public class GraphVertex
    {
        public string OuterText;
        public string InnerText;
        public Point Position;
        public Color Color;
        public float Radius;

        public List<Tuple<GraphVertex, GraphEdge>> Nodes;
    }
}
