using System.Collections.Generic;
public class TreeNode
{
    public string Tag { get; set; }
    public int Stars { get; set; }
    public TreeNode Parent { get; set; }
    public List<TreeNode> Children { get; set; }


    public TreeNode(string tag, int stars)
    {
        Stars = stars;
        Tag = tag;
        Parent = null;
        Children = new List<TreeNode>();
    }
    public TreeNode(string tag) : this(tag, -1)
    {
    }

    public void AddChild(TreeNode child)
    {
        child.Parent = this;
        Children.Add(child);
    }
}
