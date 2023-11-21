using System.Collections.Generic;
public class TreeNode
{
    public string Tag { get; set; }
    public string ResponseClient { get; set; }

    public int Stars { get; set; }
    public TreeNode Parent { get; set; }
    public List<TreeNode> Children { get; set; }


    public TreeNode(string tag, string responseClient, int stars)
    {
        Tag = tag;
        Stars = stars;
        ResponseClient = responseClient;
        Parent = null;
        Children = new List<TreeNode>();
    }
    public TreeNode(string tag, string response) : this(tag, response, -1) { }

    public void AddChild(TreeNode child)
    {
        child.Parent = this;
        Children.Add(child);
    }
}
