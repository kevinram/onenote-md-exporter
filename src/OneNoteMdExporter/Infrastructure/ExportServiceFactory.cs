using a.onexport.Models;
using a.onexport.Services;
using a.onexport.Services.Export;
using Microsoft.Office.Interop.OneNote;
using System;

namespace a.onexport.Infrastructure
{
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
}
