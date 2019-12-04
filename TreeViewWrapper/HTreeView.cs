using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{
    /// <summary>
    /// 一幅图像包含的内容(一幅图像，多个Region,多个)
    /// ImagePath-|            |
    ///           |-RegionName-|-Info1
    ///                        |-Info2
    /// </summary>
    public class TreeViewData
    {
        TreeNode imageInfo;
        HImageHandle image;
        List<TreeNode> regionInfoArry;
        List<HRegionDraw> hRegionArry;
        public TreeNode Node { get { return imageInfo; } }
        public HImageHandle Image { get { return image; } }
        public List<HRegionDraw> HRegionArry { get { return hRegionArry; } }

        public static Font BaseFont = new Font("宋体", 15);
        public static Font ChildFont = new Font("宋体", 10);



        public TreeViewData(string imagePath)
        {
            imageInfo = new TreeNode(imagePath);
            imageInfo.ExpandAll();
            image = new HImageHandle();
            image.ReadImage(imagePath);
            regionInfoArry = new List<TreeNode>();
            hRegionArry = new List<HRegionDraw>();
        }
        public TreeViewData(string imagePath, TreeNodeCollection parent)
        {
            imageInfo = new TreeNode(imagePath);
            imageInfo.ExpandAll();
            parent.Add(imageInfo);
            image = new HImageHandle();
            image.ReadImage(imagePath);
            regionInfoArry = new List<TreeNode>();
            hRegionArry = new List<HRegionDraw>();
        }
        public TreeViewData(HImageHandle image, TreeNodeCollection parent)
        {
            imageInfo = new TreeNode();
            imageInfo.ExpandAll();
            parent.Add(imageInfo);
            this.image = image;
            regionInfoArry = new List<TreeNode>();
            hRegionArry = new List<HRegionDraw>();
        }



        public void AddRegion(HRegionDraw region)
        {
            TreeNode regionInfoTree = HRegionDrawToNode(region);
            regionInfoArry.Add(regionInfoTree);
            hRegionArry.Add(region);

            imageInfo.Nodes.Add(regionInfoTree);

        }


        /// <summary>
        /// 删除指定节点资源
        /// </summary>
        /// <param name="selectNode"></param>
        public void RmSelectRegion(TreeNode selectNode)
        {
            if (!imageInfo.Nodes.Contains(selectNode)) return;
            if (imageInfo == selectNode) RmAllRegion();
            int index = selectNode.Index;
            hRegionArry[index].Dispose();
            hRegionArry.RemoveAt(index);

            imageInfo.Nodes[index].Remove();
            regionInfoArry.RemoveAt(index);
        }


        /// <summary>
        /// 删除所有资源
        /// </summary>
        public void RmAllRegion()
        {
            foreach (var region in hRegionArry)
            {
                region.Dispose();
            }
            hRegionArry.Clear();
            foreach (var childNode in regionInfoArry)
            {
                childNode.Remove();
            }
            regionInfoArry.Clear();
            image.Dispose();
            imageInfo.Nodes.Clear();        
        }



        TreeNode CreateChildNode(string text)
        {
            TreeNode treeNode = new TreeNode(text);
            treeNode.NodeFont = ChildFont;
            return treeNode;
        }
        TreeNode[] CreateChildNodeArry(string[] text)
        {
            TreeNode[] treeNodes = text.Select(s => this.CreateChildNode(s)).ToArray();
            return treeNodes;
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
    }
    public class HTreeView:System.Windows.Forms.TreeView
    {
        List<TreeViewData> imageTreeViewData;
        public bool Active
        {
            get;
            private set;
        }

        public new TreeNode SelectedNode
        {
            get
            {
                return GetSelectedNode();
            }
        }
        public TreeViewData SelectImageTreeViewData
        {
            get
            {
                var tempNode = GetSelectedImageNode();
                if (tempNode == null) return null;
                return imageTreeViewData[tempNode.Index];
            }
        }
        public HImageHandle SelectImage
        {
            get
            {
                if (SelectImageTreeViewData == null) return new HImageHandle();
                return SelectImageTreeViewData.Image;
            }
        }
        public List<HRegionDraw> SelectRegionArry
        {
            get
            {
                if (SelectImageTreeViewData == null) return null;
                return SelectImageTreeViewData.HRegionArry;
            }
        }





        public HTreeView():base()
        {
            Dock = DockStyle.Fill;

            imageTreeViewData = new List<TreeViewData>();
            Active = false;           
        }


        /// <summary>
        /// 添加图像
        /// </summary>
        /// <param name="image"></param>
        public void AddImageNode(string imagePath)
        {
            TreeViewData data = new TreeViewData(imagePath);
            base.SelectedNode = data.Node;
            imageTreeViewData.Add(data);
            Nodes.Add(data.Node);
            Active = true;
        }
        public void AddRangeImageNode(string[] imagePath)
        {
            foreach (var path in imagePath)
            {
                AddImageNode(path);
            }
        }

        /// <summary>
        /// 默认给最后一个图像添加Region
        /// </summary>
        /// <param name="region"></param>
        public void AddRegionNode(HRegionDraw region)
        {
            if (imageTreeViewData.Count == 0) return;
            SelectImageTreeViewData.AddRegion(region);
        }


        /// <summary>
        /// 删除选中的值
        /// </summary>
        public void RmSelectValue()
        {
            int imageIndex;
            TreeNode SelectedNode = this.SelectedNode;

            if (Nodes.Contains(SelectedNode))//如果是图像节点
            {
                imageIndex = SelectedNode.Index;

                imageTreeViewData[imageIndex].RmAllRegion();
            }
            else//如果是Roi节点
            {
                imageIndex = SelectedNode.Parent.Index;
                imageTreeViewData[imageIndex].RmSelectRegion(SelectedNode);
            }

        }
        public void RmAllValue()
        {
            foreach (var v in imageTreeViewData)
            {
                v.RmAllRegion();
            }
            imageTreeViewData.Clear();
            Nodes.Clear();
            Active = false;
        }




        /// <summary>
        /// 返回图像节点,Region节点
        /// </summary>
        /// <returns></returns>
        TreeNode GetSelectedNode()
        {
            if (base.SelectedNode == null) return null;
            var selectNode = base.SelectedNode;
            if (Nodes.Contains(selectNode))//删除1层节点(整个图像)
            {
                selectNode = base.SelectedNode;
     
            }
            else if (Nodes.Contains(selectNode.Parent))//删除二层节点(整个Region)
            {
                selectNode = base.SelectedNode;

            }
            else//删除二层节点,由于选择了三层节点(region的属性)，删除的时候默认删除了属性对应的二层节点
            {
                selectNode = SelectedNode.Parent;
            }
            return selectNode;
        }
        TreeNode GetSelectedImageNode()
        {
            var tempNode = GetSelectedNode();if (tempNode == null) return tempNode;
            return Nodes.Contains(tempNode) ? tempNode : tempNode.Parent;
        }
        TreeNode GetSelectedRegionNode()
        {
            var tempNode = GetSelectedNode();
            return Nodes.Contains(tempNode) ?
                (tempNode.Nodes.Count > 0 ? tempNode.Nodes[0] : null)
                : tempNode;
        }
      
    }
}

