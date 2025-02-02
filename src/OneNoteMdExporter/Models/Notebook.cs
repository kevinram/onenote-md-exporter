﻿using System.Collections.Generic;
using System.Linq;

namespace a.onexport.Models;

public class Notebook : Node
{
    public Notebook() : base(null)
    {
    }

    /// <summary>
    /// Return a flattened list of note book sections
    /// </summary>
    /// <param name="includeSectionGroup">If true, section group are returned</param>
    /// <returns></returns>
    public List<Section> GetSections(bool includeSectionGroup = false)
    {
        return GetChilds().OfType<Section>().Where(n => !n.IsSectionGroup || includeSectionGroup).ToList();
    }
    
    /// <summary>
    /// The target folder where to export the notebook
    /// </summary>
    public string ExportFolder { get; set; }

    public IList<Item> GetAllAttachments()
    {
        var attachments = new List<Item>();

        foreach(Section s in GetSections(false))
        {
            foreach(Page p in s.Childs)
            {
                attachments.AddRange(p.Attachements);
            }
        }

        return attachments;
    }
}
