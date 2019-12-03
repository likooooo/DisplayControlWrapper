using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{
    public class HTreeView:System.Windows.Forms.TreeView
    {
        public static Font BaseFont = new Font("宋体", 15);
        public static Font ChildFont = new Font("宋体", 10);
        public List<HRegionDraw> HRegionDraw
        {
            get;
            private set;
        }
        List<List<HRegionDraw>> regionListArry;


        new TreeNodeCollection Nodes
        {
            get { return base.Nodes; }
        }


        public HTreeView():base()
        {
            Dock = DockStyle.Fill;

            regionListArry = new List<List<HRegionDraw>>();
            AddImageNode();
        }

        public void CreateNewNode()
        {
            HRegionDraw = new List<HRegionDraw>();
            regionListArry.Add(HRegionDraw);
            TreeNode node = new TreeNode();          
        }
        public void ClearAllNode()
        {
            Nodes.Clear();
            HRegionDraw.Clear();
            regionListArry.Clear();
        }
        public void AddImageNode()
        {
            HRegionDraw = new List<HRegionDraw>();
            regionListArry.Add(HRegionDraw);
            TreeNode newImageNode = new TreeNode(regionListArry.Count.ToString("00"));
            newImageNode.NodeFont = BaseFont;
            Nodes.Add(newImageNode);
        }
        public void AddRegion(HRegionDraw region)
        {
            TreeNode regionInfoTree = HRegionDrawToNode(region);

            HRegionDraw.Add(region);
            this.Nodes[regionListArry.Count - 1].Nodes.Add(regionInfoTree);
        }



        TreeNode HRegionDrawToNode(HRegionDraw region)
        {
            string name;
            string[] info;
            region.GetInfomationArry(out name, out info);
            TreeNode parent = CreateChildNode(name);
            if (info != null)
            {
                var child = CreateChildNodeArry(info);
                parent.Nodes.AddRange(child);
            }
            return parent;
        }
        TreeNode CreateChildNode(string text)
        {
            TreeNode treeNode = new TreeNode(text);
            treeNode.NodeFont = ChildFont;
            return treeNode;
        }
        TreeNode[] CreateChildNodeArry(string[] text)
        {
            TreeNode[] treeNodes = text.Select(s => CreateChildNode(s)).ToArray();

            return treeNodes;
        }


    }
}
