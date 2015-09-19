using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Keyworder
{
    public static class NodeHandler
    {
        public static bool AtLeastOneNodeIsChecked(IEnumerable nodes)
        {
            return nodes.Cast<TreeNode>().Any(AnyNodeIsChecked);
        }

        public static IEnumerable<TreeNode> GetCheckedNodes(IEnumerable nodes)
        {
            var checkedNodes = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    checkedNodes.Add(node);
                }

                checkedNodes.AddRange(GetCheckedNodes(node.Nodes));
            }
            return checkedNodes;
        }

        public static Dictionary<string, Tuple<bool, bool>> GetState(IEnumerable nodes)
        {
            // dictionary doesn't have an AddRange so use list in recursive function and then map
            return BuildStateList(nodes).ToDictionary(
                tuple => $"{tuple.Item1},{tuple.Item2}",
                tuple => new Tuple<bool, bool>(tuple.Item3, tuple.Item4));
        }

        public static void SetState(IEnumerable nodes, Dictionary<string, Tuple<bool, bool>> state)
        {
            foreach (TreeNode node in nodes)
            {
                var key = $"{GetCategoryText(node)},{GetKeywordText(node)}";
                if (state.ContainsKey(key))
                {
                    node.Checked = state[key].Item1;
                    if (state[key].Item2)
                    {
                        node.Expand();
                    }
                }
                SetState(node.Nodes, state);
            }
        }

        public static void UpdateChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                UpdateChildNodes(node, nodeChecked);
            }
        }

        private static string GetCategoryText(TreeNode node)
        {
            return node.Nodes.Count > 0 ? node.Text : node.Parent.Text;
        }

        private static string GetKeywordText(TreeNode node)
        {
            return node.Nodes.Count == 0 ? node.Text : string.Empty;
        }

        private static bool AnyNodeIsChecked(TreeNode node)
        {
            return node.Checked || node.Nodes.Cast<TreeNode>().Any(AnyNodeIsChecked);
        }

        private static IEnumerable<Tuple<string, string, bool, bool>> BuildStateList(IEnumerable nodes)
        {
            var state = new List<Tuple<string, string, bool, bool>>();
            foreach (TreeNode node in nodes)
            {
                // only need to store state that is not default
                if (node.Checked || node.IsExpanded)
                {
                    state.Add(new Tuple<string, string, bool, bool>(
                        GetCategoryText(node), 
                        GetKeywordText(node), 
                        node.Checked, 
                        node.IsExpanded));
                }
                state.AddRange(BuildStateList(node.Nodes));
            }
            return state;
        }
    }
}
