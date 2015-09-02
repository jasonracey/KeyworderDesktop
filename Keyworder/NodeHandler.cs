using System.Collections;
using System.Windows.Forms;

namespace Keyworder
{
    public static class NodeHandler
    {
        public static bool AtLeastOneNodeIsChecked(IEnumerable nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    return AtLeastOneNodeIsChecked(node.Nodes);
                }
                if (node.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public static void UpdateChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    UpdateChildNodes(node, nodeChecked);
                }
            }
        }
    }
}
