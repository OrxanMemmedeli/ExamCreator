using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.Reports
{
    public abstract class BaseReport
    {
        private readonly string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
        protected BaseFont bf;
        protected Font headerFont;
        protected Font bFont; // bold font
        protected Font font; // normal font
        protected Font italicFont; // normal font
        protected readonly Document document = new Document(PageSize.A4);
        protected readonly Document documentX = new Document(PageSize.A4.Rotate());
        protected readonly Document documentXS = new Document(PageSize.A4.Rotate());
        protected readonly Document documentXL = new Document(PageSize.A4.Rotate());
        protected readonly Document documentVS = new Document(PageSize.A4);
        protected readonly Document documentSM = new Document(new Rectangle(226f, 126f), 0, 0, 0, 0);
        protected readonly Document documentXSM = new Document(new Rectangle(38f, 38f), 0, 0, 0, 0);
        protected readonly Document documentLB = new Document(PageSize.A4);
        protected PdfPCell _cell;
        protected BaseReport()
        {
            bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            headerFont = new Font(bf, 16, Font.BOLD);
            bFont = new Font(bf, 12, Font.BOLD);
            font = new Font(bf, 12, Font.NORMAL);
            italicFont = new Font(bf, 12, Font.ITALIC);
            document.SetMargins(0, 0, 50f, 20f);
            documentXS.SetMargins(-20f, -20f, 50f, 36f);
            documentXL.SetMargins(-20f, -20f, 36f, 70f);
            documentVS.SetMargins(0, 0, 50f, 70f);
            documentLB.SetMargins(0, 0, 100f, 70f);
        }

        public abstract PdfPTable AddFooterSpecial();
        public abstract PdfPTable AddHeaderSpecial();

        public abstract void AddHeader();

        public abstract void AddBody();

        public abstract void AddFooter();

        public byte[] GeneratePdf()
        {
            using (var ms = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(documentVS, ms);
                bool condition = false;
                PdfPTable table = AddFooterSpecial();
                if (table != null)
                {

                    writer.PageEvent = new HeaderFooter(table);

                    condition = true;
                }
                else
                {
                    documentVS.Open();
                    AddHeader();
                    AddBody();
                    AddFooter();
                    documentVS.Close();
                }

                if (condition)
                {
                    documentVS.Open();
                    AddHeader();
                    AddBody();
                    AddFooter();
                    documentVS.Close();
                }


                return AddPageNumber(ms.ToArray()); ;
            }
        }
        public byte[] AddPageNumber(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);

                PdfStamper stamper = new PdfStamper(reader, stream);

                int pages = reader.NumberOfPages;
                for (int i = 1; i <= pages; i++)
                    ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_CENTER, new Phrase($"~ {i}/{pages} ~", font), 568f, 15f, 0);

                bytes = stream.ToArray();
            }

            return bytes;
        }


        #region helper methods

        protected PdfPTable GetDefaultTable(int numColumns)
        {
            var table = new PdfPTable(numColumns);
            table.DefaultCell.Border = 0;
            return table;
        }

        protected virtual PdfPTable GetDefaultBorderedTable(int numColumns, float? borderWidth = null)
        {
            var table = new PdfPTable(numColumns);
            table.DefaultCell.Padding = 5;
            table.DefaultCell.UseVariableBorders = true;
            if (borderWidth != null) table.DefaultCell.BorderWidth = borderWidth.Value;
            else table.DefaultCell.BorderWidth = 1;
            table.DefaultCell.BorderColor = BaseColor.Black; ;
            return table;
        }

        protected PdfPCell GetDefaultCell(Phrase phrase, int? colspan = null, int? rowspan = null)
        {
            var cell = new PdfPCell(phrase);
            cell.Border = 0;
            if (colspan != null) cell.Colspan = colspan.Value;
            if (rowspan != null) cell.Rowspan = rowspan.Value;
            return cell;
        }

        protected virtual PdfPCell GetDefaultBorderedCell(Phrase phrase, int? colspan = null, int? rowspan = null, float? borderWidth = null)
        {
            var cell = new PdfPCell(phrase);
            cell.Padding = 5;
            cell.UseVariableBorders = true;

            if (borderWidth != null) cell.BorderWidth = borderWidth.Value;
            else cell.BorderWidth = 1;
            cell.BorderColor = BaseColor.Black;
            if (colspan != null) cell.Colspan = colspan.Value;
            if (rowspan != null) cell.Rowspan = rowspan.Value;
            return cell;
        }

        protected virtual Paragraph GetDefaultParagraph(string label, string text)
        {
            var p = new Paragraph();
            p.Add(new Phrase(label, bFont));
            p.Add(new Phrase(text, font));
            return p;
        }

        protected virtual Paragraph GetDefaultParagraphUniCode(string label, string text)
        {
            //var fontPath = HttpContext.Current.Server.MapPath("~/fonts/ARIALUNI.TTF");
            var fontPath = "~/fonts/ARIALUNI.TTF";
            var b = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, true);
            var f = new Font(b, 11, Font.NORMAL);
            var p = new Paragraph();
            p.Add(new Phrase(label, bFont));
            p.Add(new Phrase(text, f));
            return p;

        }

        protected class HeaderFooter : PdfPageEventHelper
        {
            public PdfPTable _table { get; set; }

            public HeaderFooter(PdfPTable table)
            {
                _table = table;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                _table.WriteSelectedRows(0, -1, writer.PageSize.GetLeft(document.LeftMargin + 50), writer.PageSize.GetBottom(document.BottomMargin + 30), writer.DirectContent);
            }
        }
        #endregion
    }
}
