using System.IO;
using System.Xml;

namespace lib.XmlControl_v1
{
    public class XmlControl
    {
        #region 内部必要变量
        XmlDocument doc;
        XmlElement root;
        #endregion
        public XmlControl()
        {
            doc = new XmlDocument();
        }
      
        /* 创建一个XML文件对象
         */
        public void creatXml(string version, string encoding, string standalone)
        {
            XmlDeclaration dec = doc.CreateXmlDeclaration(version, encoding, standalone);/**创建描述信息*/
            doc.AppendChild(dec);
            root = doc.CreateElement("root");
            doc.AppendChild(root);
        }

        /*读取XML文件
         */
        public void loadXml(string filePath)
        {
            doc.Load(filePath);
            root = doc.DocumentElement;
        }

        /*保存XML文件
         */
        public bool saveXml(string filePath)
        {
            //if (!File.Exists(filePath))
            //{
            //    doc.Save(filePath);
            //}
            //else
            //{
            //    return false;
            //}
            doc.Save(filePath);
            return true;
        }

        /*依据节点的名称遍历寻找xml节点
         */
        private XmlNode findNode(string nodeName)
        {
            XmlNode node = null;
            foreach (XmlNode v in root)
            {
                if (v.Name == nodeName)
                {
                    node = v;
                    break;
                }
                if (v.ChildNodes.Count > 0)
                {
                    foreach (XmlNode childNode in v)
                    {
                        if (childNode.Name == nodeName)
                        {
                            node = childNode;
                            break;
                        }
                    }
                }
            }
            return node;
        }

        /**获取节点的子节点数量
         * -1：名为nodeName的节点不存在
         * */
        public int getChildNodeCount(string nodeName)
        {
            int count = 0;
            XmlNode node = findNode(nodeName);
            if (node == null) return -1;
            count = node.ChildNodes.Count;
            return count;
        }
        
        /*返回子节点的姓名
         */
        public string[] getChildName(string nodeName)
        {
            XmlNode node = findNode(nodeName);
            int childCount = node.ChildNodes.Count;
            string[] nameArry = new string[childCount];
            int i = 0;        
            foreach(XmlNode childNode in node.ChildNodes)
            {
                nameArry[i] = childNode.Name;
                i++;
            }
            return nameArry;
        }

        /* 读取节点的属性值，如果该节点没有的话会去子节点查找
         */
        public string getNodeAttribute(string nodeName, string attributeName)
        {
            XmlNode node = findNode(nodeName);
            if (node == null) return "数据节点：\"" + nodeName + "\"不存在.";
            string childStr;
            try
            {
                childStr = node.Attributes[attributeName].InnerText;
            }
            catch
            {
                childStr = "";
            }
            /**查询node的子节点*/
            if (childStr == "" && node.ChildNodes.Count > 0)
            {
                try
                {
                    foreach (XmlNode v in node)
                    {
                        childStr = v.Attributes[attributeName].Value;
                        break;//只有上一句运行正确，这个break才会执行.
                    }
                }
                catch { }
            }
            return childStr;
        }

        /**修改节点属性值
         * false: 名为nodeName的节点不存在或节点的属性值attributeName不存在.
         */
        public bool editNodeAttribute(string nodeName, string attributeName, string str)
        {
            XmlNode node = findNode(nodeName);
            if (node == null) return false;
            try
            {
                node.Attributes[attributeName].Value = str;
            }
            catch
            {
                return false;
            }
            return true;
        }

        /*bool变量的tre或者false，保存到Xml的时候，要转换为字符串
         */
        public static string checkedStr2Xml(bool isChecked)
        {
            if (isChecked)
                return "true";
            else
                return "false";
        }

        /* 将有空隙的名称，如CMA 中国电力科学研究院，变成xml可读的CMA_中国电力科学研究院没有空格的格式
          */
        public static string connectSpace(string textStr)
        {
            string[] temp = new string[2];
            temp = textStr.Split(' ');
            textStr = "";
            for (int i = 0; i < temp.Length - 1; i++)
            {
                textStr += temp[i] + "_";
            }
            textStr += temp[temp.Length - 1];
            return textStr;
        }
    }
}
