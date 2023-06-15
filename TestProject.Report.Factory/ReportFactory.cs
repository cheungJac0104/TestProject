namespace TestProject.Report.Factory;

public class ReportFactory
{
    #region Report Template
    private enum ReportEnum
    {
    }

    private readonly Dictionary<ReportEnum, string> _reportTemplateDict
        = new Dictionary<ReportEnum, string>()
        {
        };

    #endregion


    #region file type
    private enum FileTypeEnum
    {
        xlsx,
        pdf,
        txt,
        doc,
        docx,
        json,
        xls,
        stream
    }


    private readonly Dictionary<FileTypeEnum, string> _fileTypeDict
        = new Dictionary<FileTypeEnum, string>()
        {
            [FileTypeEnum.xlsx] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            [FileTypeEnum.pdf] = "application/pdf",
            [FileTypeEnum.doc] = "application/msword",
            [FileTypeEnum.txt] = "text/plain; charset=UTF-8",
            [FileTypeEnum.docx] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            [FileTypeEnum.json] = "application/json",
            [FileTypeEnum.xls] = "application/vnd.ms-excel",
            [FileTypeEnum.stream] = "application/octet-stream",
        };

    #endregion

    private string _getFileType(FileTypeEnum type) => _fileTypeDict[type];

    private string _getReportName(ReportEnum report) => _reportTemplateDict[report];


}

