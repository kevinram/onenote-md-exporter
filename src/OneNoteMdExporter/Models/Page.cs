using a.onexport.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace a.onexport.Models;

public class Page : Node
{
    public Page(Section parent) : base(parent)
    {
    }

    public Page(Node parent) : base(parent)
    {
    }
    public int PageLevel { get; set; }

    private Page _parentPage { get; set; }

    public Page ParentPage { get; }

    public void SetParentPage(Page parentPage)
    {
        _parentPage = parentPage;
        parentPage.ChildPages.Add(this);
    }

    public IList<Page> ChildPages { get; set; } = new List<Page>();

    /// <summary>
    /// Ordering of the page inside the Section
    /// </summary>
    public int PageSectionOrder { get; set; }

    public string TitleWithPageLevelTabulation { get
        {
            var level = "";
            for (int i = 1; i < PageLevel; i++) level += "--";
            return level + (level.Length > 0 ? " " : "") + Title;
        } 
    }
    public string TitleWithNoInvalidChars(int maxLength) 
        => Title.RemoveInvalidFileNameChars().Left(maxLength);

    public IList<Item> Attachements { get; set; } = new List<Item>();
    public IList<Item> ImageAttachements { get => Attachements.Where(a => a.Type == ItemType.Image).ToList(); }
    public IList<Item> FileAttachements { get => Attachements.Where(a => a.Type == ItemType.File).ToList(); }

    public string Author { get; internal set; }


    /// <summary>
    /// Override page md file path in case of multiple page with the same name
    /// </summary>
    public string OverridePageFilePath { get; set; }

    public string GetPageFileRelativePath(int pageTitleMaxLength)
    {
        return Path.Combine(Parent.GetPath(pageTitleMaxLength), TitleWithNoInvalidChars(pageTitleMaxLength));
    }
}
