using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Libreria.Helpers
{
    public class ExcelHelper 
    {
        public string Filepath { get; set; }
        public string Sheetname { get; set; }
        public List<string> Headers { get; set; }
        public List<List<string>> Data { get; set; }

        public ExcelHelper()
        {
            Headers = new List<string>();
            Data = new List<List<string>>();
        }


        public ExcelHelper SetFileData(string filename, string sheetname)
        {
            if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(sheetname))
            {
                Filepath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{filename}.xlsx";
                Sheetname = sheetname;
            }

            return this;
        }

        public ExcelHelper SetHeaders(List<string> headers)
        {
            Headers = headers;

            return this;
        }

        public ExcelHelper SetData(List<List<string>> data)
        {
            Data = data;

            return this;
        }

        public ExcelHelper Export()
        {
            using (SpreadsheetDocument excel = SpreadsheetDocument.Create(this.Filepath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = excel.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();
                WorksheetPart sheet = workbookpart.AddNewPart<WorksheetPart>();
                sheet.Worksheet = new Worksheet();

                Columns columns = new Columns();
                sheet.Worksheet.Append(columns);

                SheetData data = CreateData();
                sheet.Worksheet.Append(data);

                var stylesPart = workbookpart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = new Stylesheet();
                stylesPart.Stylesheet.Save();

                Sheets sheets = excel.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                sheets.Append(new Sheet()
                {
                    Id = excel.WorkbookPart.GetIdOfPart(sheet),
                    SheetId = 1,
                    Name = this.Sheetname
                });

                workbookpart.Workbook.Save();
            }

            return this;
        }


        #region Private
        private SheetData CreateData()
        {
            SheetData data = new SheetData();
            var rowIndex = 0;
            var rowHeaders = GenerarRowHeaders();
            data.InsertAt(rowHeaders, rowIndex++);

            foreach (var eachData in Data)
            {
                var row = GenerarRowData(eachData);
                data.InsertAt(row, rowIndex++);
            }

            return data;
        }
        private Row GenerarRowHeaders()
        {
            var row = new Row();
            var indexColumna = 0;

            foreach (var header in Headers)
            {
                row.InsertAt<Cell>(new Cell()
                {
                    DataType = CellValues.InlineString,
                    InlineString = new InlineString() { Text = new Text(header) },
                }, indexColumna);

                indexColumna++;
            }

            return row;
        }
        private Row GenerarRowData(List<string> eachData)
        {
            var row = new Row();
            var indexColumna = 0;

            foreach (var data in eachData)
            {
                row.InsertAt<Cell>(new Cell()
                {
                    DataType = CellValues.InlineString,
                    InlineString = new InlineString() { Text = new Text(data) },
                }, indexColumna);

                indexColumna++;
            }

            return row;
        }
        #endregion
    }
}
