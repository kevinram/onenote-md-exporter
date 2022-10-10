using a.onexport.Services;
using a.onexport.Services.Export;

namespace a.onexport.Infrastructure;

public static class ExportServiceFactory
{
    public static IExportService GetExportService(ExportFormat exportFormat, AppSettings appSettings, Application oneNoteApp)
    {
        switch (exportFormat)
        {
            case ExportFormat.Markdown:
                return new MdExportService(appSettings, oneNoteApp, new ConverterService(appSettings));
            case ExportFormat.JoplinMdFolder:
                return new JoplinExportService(appSettings, oneNoteApp, new ConverterService(appSettings));
            default:
                throw new NotImplementedException();
        }
    }
}
