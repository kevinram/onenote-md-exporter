namespace a.onexport.Models;

public class Section : Node
{
    public bool IsSectionGroup { get; set; }

    public Section(Node parent) : base(parent)
    {
    }
}
