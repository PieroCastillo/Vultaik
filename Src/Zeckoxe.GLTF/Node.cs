﻿// Copyright (c) 2019-2020 Faber Leonardo. All Rights Reserved. https://github.com/FaberSanZ
// This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)


/*=============================================================================
	Node.cs
=============================================================================*/


using System.Collections.Generic;
using System.Numerics;

namespace Zeckoxe.GLTF
{
    public class Node
    {



        public Node()
        {

        }


        public string Name { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public Matrix4x4 LocalMatrix { get; set; }
        public Mesh Mesh { get; set; }

        public Matrix4x4 Matrix => Parent == null ? LocalMatrix : Parent.Matrix * LocalMatrix;

        public Node FindNode(string name)
        {
            if (Name == name)
            {
                return this;
            }

            if (Children == null)
            {
                return null;
            }

            foreach (Node child in Children)
            {
                Node n = child.FindNode(name);
                if (n != null)
                {
                    return n;
                }
            }
            return null;
        }



        public BoundingBox GetAABB(Matrix4x4 currentTransform)
        {
            Matrix4x4 curTransform = LocalMatrix * currentTransform;
            BoundingBox aabb = new BoundingBox();

            if (Mesh != null)
            {
                aabb = Mesh.bb.getAABB(curTransform);
            }

            if (Children != null)
            {
                for (int i = 0; i < Children.Count; i++)
                {
                    aabb += Children[i].GetAABB(curTransform);
                }
            }
            return aabb;
        }
    }
}