using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public static TreeNode GetCategoryNode(IEnumerable nodes, string category)
        {
            // don't need to recurse because category nodes are all root depth
            foreach (TreeNode node in nodes)
            {
                if (node.Text == category)
                {
                    return node;
                }
            }
            throw new ArgumentException("node not found");
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

        public static IDictionary<string, (bool IsChecked, bool IsExpanded)> GetState(IEnumerable nodes)
        {
            // dictionary doesn't have an AddRange so use list in recursive function and then map
            return BuildStateCollection(nodes).ToImmutableDictionary(
                item => BuildKey(item.Category, item.Keyword),
                item => (item.IsChecked, item.IsExpanded));
        }

        public static void SetState(IEnumerable nodes, IDictionary<string, (bool IsChecked, bool IsExpanded)> state)
        {
            foreach (TreeNode node in nodes)
            {
                var key = BuildKey(GetCategoryText(node), GetKeywordText(node));
                if (state.ContainsKey(key))
                {
                    node.Checked = state[key].IsChecked;
                    if (state[key].IsExpanded)
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
        
        private static string BuildKey(string category, string keyword) => $"{category},{keyword}";

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

        private static IEnumerable<(string Category, string Keyword, bool IsChecked, bool IsExpanded)> BuildStateCollection(IEnumerable nodes)
        {
            var state = new List<(string, string, bool, bool)>();
            foreach (TreeNode node in nodes)
            {
                // only need to store state that is not default
                if (node.Checked || node.IsExpanded)
                {
                    state.Add((
                        GetCategoryText(node), 
                        GetKeywordText(node), 
                        node.Checked, 
                        node.IsExpanded));
                }
                state.AddRange(BuildStateCollection(node.Nodes));
            }
            return state;
        }
    }
}
