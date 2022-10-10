namespace a.onexport.Services.Export;

public interface IExportService
{
    void ExportNotebook(Notebook notebook, string sectionNameFilter = "", string pageNameFilter = "");
}