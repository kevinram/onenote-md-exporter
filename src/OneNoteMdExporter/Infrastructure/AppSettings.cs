﻿
namespace a.onexport.Infrastructure;

public class AppSettings
{

    /*
      * Export general settings
      * */

    /// <summary>
    /// Add at the begining of each page a YAML header that include Page metadata (cf https://assemble.io/docs/YAML-front-matter.html)
    /// </summary>
    public bool AddFrontMatterHeader { get; set; } = true;

    /// <summary>
    /// Length limit of Section and page name used in file and folder name. Reduce this value to avoid error of max file system file path
    /// </summary>
    public int MdMaxFileLength { get; set; } = 50;

    /// <summary>
    /// How page hierarchies should be exported :
    /// - HiearchyAsFolderTree : add folder tree to store pages
    /// - HiearchyAsPageTitlePrefix : prefix page title with their parent / grand-parent page name
    /// - IgnoreHierarchy : ignore page hierarchy
    /// Apply to : Markdown Format
    /// </summary>
    public PageHierarchyEnum ProcessingOfPageHierarchy { get; set; } = PageHierarchyEnum.HiearchyAsFolderTree;

    /// <summary>
    /// For MdExport with ProcessingOfPageHierarchy=HiearchyAsPageTitlePrefix, the separator to use to prefix md page file name
    /// Ex: "_" value for "ParentPage_ChildPage.md"
    /// </summary>
    public string PageHierarchyFileNamePrefixSeparator { get; set; } = "_";

    /// <summary>
    /// Copy DocX export of pages along md files
    /// Apply to : Markdown Format
    /// </summary>
    public bool KeepOneNoteDocxFiles { get; set; } = false;

    /// <summary>
    /// Where file attachemnts and image files should me stored ?
    /// - RootFolder : in a single folder at the root of the export folder,
    /// - PageParentFolder : in folders next to the md file
    /// Apply to : Markdown Format
    /// </summary>
    public ResourceFolderLocationEnum ResourceFolderLocation { get; set; } = ResourceFolderLocationEnum.PageParentFolder;

    /// <summary>
    /// Name of the resource folder where attachemnts and image files are stored
    /// </summary>
    public string ResourceFolderName { get; set; } = "assets2";

    /*
     * Markdown rendering Settings
     * */

    /// <summary>
    /// One of pandoc format https://pandoc.org/MANUAL.html#general-options
    /// Rq: For Joplin "gfm" is recommanded
    /// </summary>
    public string PanDocMarkdownFormat { get; set; } = "gfm";

    /// <summary>
    /// Convert HTML IMG tag generated by PanDoc into markdown references
    /// </summary>
    public bool PostProcessingMdImgRef { get; set; } = true;

    /// <summary>
    /// Remove undesired quotation blocks sometimes generated by PanDoc
    /// </summary>
    public bool PostProcessingRemoveQuotationBlocks { get; set; } = true;

    /// <summary>
    /// Remove OneNote header generated by OneNote Export APIs
    /// </summary>
    public bool PostProcessingRemoveOneNoteHeader { get; set; } = true;

    /// <summary>
    /// Replace every pair of linebreak by a single linebreak (to avoid duplicates generated by Pandoc)
    /// </summary>
    public bool DeduplicateLinebreaks { get; set; } = true;

    /// <summary>
    /// Prevent generation of more that 2 linebreaks in a row
    /// </summary>
    public bool MaxTwoLineBreaksInARow { get; set; } = true;

    /*
     * Developer Settings
     * */

    /// <summary>
    /// Enable verbose mode and keep temporary files (.docx)
    /// </summary>
    public bool Debug { get; set; } = false;


    public static AppSettings LoadAppSettings2()
    {
        IConfigurationRoot configRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        AppSettings appSettings = configRoot.Get<AppSettings>();
        return appSettings;
    }

    public static AppSettings LoadAppSettings()
    {

        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        IConfigurationRoot root = builder.Build();


        IConfigurationRoot configRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var folder = root["ResourceFolderName"];

        IConfigurationRoot configuration = builder.Build();

        var settings = new AppSettings();
        configuration.Bind(settings);
        return settings;

        //AppSettings appSettings = root.Get<AppSettings>();
        //return appSettings;
    }
}
