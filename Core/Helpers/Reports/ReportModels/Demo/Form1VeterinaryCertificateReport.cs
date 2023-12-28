using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace CoreLayer.Helpers.Reports.ReportModels.Demo
{
    //[HttpGet]
    //public ActionResult Print(Guid id)
    //{
    //    var response = _serviceFacade.GetReportData(id);

    //    if (!response.IsSucceed)
    //        return AjaxFailureResult(response);

    //    var report = new Form1VeterinaryCertificateReport(response.Data);

    //    var pdf = report.GeneratePdfVS();

    //    return File(pdf, "application/pdf");
    //}


    public class Form1VeterinaryCertificateReport : BaseReport
    {
        private readonly Form1VeterinaryCertificateReportModel _model;
        private readonly string TIMESNEWROMAN_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "TIMES.TTF");

        public Form1VeterinaryCertificateReport(Form1VeterinaryCertificateReportModel model)
        {
            _model = model;
            bf = BaseFont.CreateFont(TIMESNEWROMAN_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            bFont = new Font(bf, 10, Font.BOLD);
            font = new Font(bf, 10, Font.NORMAL);
            headerFont = new Font(bf, 13, Font.BOLD);
        }

        #region Override Methods
        protected override Paragraph GetDefaultParagraph(string label, string text)
        {
            var p = new Paragraph();
            var chunk = new Chunk(text, font);
            var chunkLabel = new Chunk(label, bFont);
            //p.Add(new Phrase(chunkLabel.SetCharacterSpacing(0)));
            //p.Add(new Phrase(chunk.SetCharacterSpacing(0)));
            return p;
        }
        protected override Paragraph GetDefaultParagraphUniCode(string text, string label)
        {
            //string fontPath = HttpContext.Current.Server.MapPath("~/fonts/ARIALUNI.TTF");
            string fontPath = "~/fonts/ARIALUNI.TTF";
            BaseFont b = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, true);
            Font f = new Font(b, 8.8f, Font.NORMAL);
            Paragraph p = new Paragraph
            {
                new Phrase(text, f),
                new Phrase(label, bFont)
            };
            return p;

        }
        protected override PdfPCell GetDefaultBorderedCell(Phrase phrase, int? colspan = null, int? rowspan = null, float? borderWidth = null)
        {
            var cell = new PdfPCell(phrase);
            cell.Padding = 5;
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 0.1f;
            cell.BorderWidthRight = 0.1f;
            cell.BorderWidthLeft = 0.1f;
            cell.BorderWidthTop = 0.1f;
            if (borderWidth != null) cell.BorderWidth = borderWidth.Value;
            else cell.BorderWidth = 1;
            cell.BorderColor = BaseColor.Black;
            if (colspan != null) cell.Colspan = colspan.Value;
            if (rowspan != null) cell.Rowspan = rowspan.Value;
            return cell;
        }
        protected override PdfPTable GetDefaultBorderedTable(int numColumns, float? borderWidth = null)
        {
            PdfPTable table = new PdfPTable(numColumns);
            table.DefaultCell.Padding = 4;
            table.DefaultCell.UseVariableBorders = true;
            if (borderWidth != null)
            {
                table.DefaultCell.BorderWidth = borderWidth.Value;
            }
            else
            {
                table.DefaultCell.BorderWidth = 1;
            }

            table.DefaultCell.BorderColor = BaseColor.Black; ;
            return table;
        }
        protected Paragraph GetBoldedSpesificParagraph(string label, string text)
        {
            Font f = new Font(bf, 9f, Font.NORMAL);
            Font bFont = new Font(bf, 9f, Font.BOLD);
            Paragraph p = new Paragraph
            {

                new Phrase(label, bFont),
                new Phrase(text, f)
            };
            return p;
        }
        protected Paragraph GetSpecialParagraph(string label, string text)
        {
            Font f = new Font(bf, 7f, Font.ITALIC);
            Paragraph p = new Paragraph
                {
                  new Phrase(text, f),
                  new Phrase(label, bFont)
                };
            p.SetLeading(0, 1);
            return p;
        }
        public PdfPCell GetDefaultImageCell(Image image, int? colspan = null, int? rowspan = null, float? borderWidth = null)
        {
            var cell = new PdfPCell(image);
            cell.Padding = 5;
            cell.UseVariableBorders = true;
            cell.BorderWidthBottom = 0.1f;
            cell.BorderWidthRight = 0.1f;
            cell.BorderWidthLeft = 0.1f;
            cell.BorderWidthTop = 0.1f;
            if (borderWidth != null) cell.BorderWidth = borderWidth.Value;
            else cell.BorderWidth = 1;
            cell.BorderColor = BaseColor.Black;
            if (colspan != null) cell.Colspan = colspan.Value;
            if (rowspan != null) cell.Rowspan = rowspan.Value;
            return cell;
        }
        #endregion

        public override PdfPTable AddHeaderSpecial()
        {
            return null;
        }
        public override void AddHeader()
        {
            #region image
            PdfPTable imgTable = new PdfPTable(1);
            imgTable.DefaultCell.Border = 0;
            imgTable.DefaultCell.FixedHeight = 65f;
            imgTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            //string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/img/gerb.png");
            string imagePath = "~/Content/img/gerb.png";
            Image image = Image.GetInstance(imagePath);
            imgTable.AddCell(image);

            documentVS.Add(imgTable);
            #endregion

            #region header

            var headerTable = new PdfPTable(1);
            headerTable.DefaultCell.Border = 0;
            PdfPCell headerCell = new PdfPCell();
            headerCell.Border = 0;
            headerCell.BorderWidthBottom = 0.2f;
            headerTable.DefaultCell.PaddingBottom = 1f;
            headerCell.BorderColorBottom = BaseColor.Black;

            Paragraph hParagraph = new Paragraph(new Phrase($"XXX", new Font(bf, 12, Font.BOLD, BaseColor.Black)));
            hParagraph.Alignment = Element.ALIGN_CENTER;
            headerCell.AddElement(hParagraph);
            Paragraph regionalSectionName = new Paragraph(new Phrase($"{_model.RegionalSectionName}", new Font(bf, 12, Font.BOLD, BaseColor.Black)));
            regionalSectionName.Alignment = Element.ALIGN_CENTER;
            regionalSectionName.SpacingAfter = 2;
            headerCell.AddElement(regionalSectionName);
            headerTable.AddCell(headerCell);

            PdfPCell headerSubCell = new PdfPCell();
            headerSubCell.BorderWidthBottom = 0.2f;
            headerSubCell.BorderColorBottom = BaseColor.Black;
            headerSubCell.PaddingTop = 0;
            Paragraph hSubParagraph = new Paragraph(new Phrase("\"xxx", new Font(bf, 6.5f, Font.NORMAL)));
            hSubParagraph.SetLeading(0, 1f);
            hSubParagraph.Alignment = Element.ALIGN_TOP;
            hSubParagraph.Alignment = Element.ALIGN_CENTER;
            headerSubCell.AddElement(hSubParagraph);
            headerSubCell.Border = 0;
            headerTable.AddCell(headerSubCell);

            PdfPCell headerSubCell_2 = new PdfPCell();
            headerSubCell_2.BorderWidthBottom = 0.2f;
            headerSubCell_2.BorderColorBottom = BaseColor.Black;
            headerSubCell_2.PaddingTop = 0;
            Paragraph hSubParagraph_2 = new Paragraph(new Phrase("2 nömrəli əlavə", new Font(bf, 7, Font.BOLD)));
            hSubParagraph_2.SetLeading(0, 1f);
            hSubParagraph_2.Alignment = Element.ALIGN_TOP;
            hSubParagraph_2.Alignment = Element.ALIGN_CENTER;
            headerSubCell_2.AddElement(hSubParagraph_2);
            headerSubCell_2.Border = 0;
            headerTable.AddCell(headerSubCell_2);

            headerTable.HorizontalAlignment = Element.ALIGN_CENTER;

            documentVS.Add(headerTable);
            #endregion        
        }

        public override void AddBody()
        {
            var defaultSpace = "    ";
            {
                var table5 = GetDefaultBorderedTable(1);
                var text = $"\nBAYTARLIQ ŞƏHADƏTNAMƏSİ №: ";
                Phrase headerNameS = new Phrase(text, new Font(bf, 12, Font.BOLD, BaseColor.Black));
                Phrase headerNameD = new Phrase(_model.UnicalNumber, new Font(bf, 14, Font.BOLD, new BaseColor(29, 97, 167)));

                Paragraph headerP = new Paragraph();
                headerP.Add(headerNameS);
                headerP.Add(headerNameD);

                _cell = GetDefaultCell(headerP, 10);
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.BorderWidthBottom = 0;
                _cell.Padding = 1f;
                table5.AddCell(_cell);
                documentVS.Add(table5);
            }
            {
                var table = GetDefaultBorderedTable(1);
                ////table.PaddingTop = 0;

                var text = "Qeyd: xxx";
                Paragraph paragraph = new Paragraph(new Phrase(text, new Font(bf, 7.5f, Font.NORMAL, BaseColor.Black)));

                _cell = GetDefaultCell(paragraph, 1);
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.BorderWidthBottom = 0;
                _cell.Padding = 1f;

                table.AddCell(_cell);
                documentVS.Add(table);
            }

            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = 0;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = -20f;

                var text = $"\n{defaultSpace}Mən, aşağıda imza edən baytar həkimi, həmin baytarlıq şəhadətnaməsini vermişəm ondan ötrü ki, baytarlıq baxışı zamanı göndərilən";
                //var text2 = $"\nQoşma sənədi Cədvəl 1.1 (Məhsul haqqında məlumatlar)";

                Phrase phrase = new Phrase(text, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));
                //Phrase phrase2 = new Phrase(text2, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase);
                //paragraph.Add(phrase2);


                ////paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph.SetLeading(0, 1.3f); //line space

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = 0;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = 5f;

                var text2 = $"\n{defaultSpace}Cədvəl 1.1 (Məhsul haqqında məlumatlar)";

                Phrase phrase2 = new Phrase(text2, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase2);

                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                float[] columnWidths = { 2f, 10f, 10f, 8f, 8f, 5f, 3f, 8f, 3f, 6f, 8f }; // Set the width of each column
                int counter = 1;

                PdfPTable table = new PdfPTable(11);
                table.DefaultCell.Border = 2;
                table.WidthPercentage = 83;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                table.SplitLate = false;

                table.SetWidths(columnWidths);

                PdfPCell headerCell0 = GenerateCell("SN", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell1 = GenerateCell("Cinsi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell2 = GenerateCell("Heyvanın növü", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell3 = GenerateCell("Birka nömrəsi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell4 = GenerateCell("Şəhadətnamə nömrəsi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell5 = GenerateCell("Cinsiyəti", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell6 = GenerateCell("Yaşı", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell7 = GenerateCell("Mənşəyi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell8 = GenerateCell("Baş sayı", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell9 = GenerateCell("Peyvəndlənmə", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell10 = GenerateCell("Parazitlərə qarşı işlənmə", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));

                table.AddCell(headerCell0);
                table.AddCell(headerCell1);
                table.AddCell(headerCell2);
                table.AddCell(headerCell3);
                table.AddCell(headerCell4);
                table.AddCell(headerCell5);
                table.AddCell(headerCell6);
                table.AddCell(headerCell7);
                table.AddCell(headerCell8);
                table.AddCell(headerCell9);
                table.AddCell(headerCell10);

                if (_model.ProductInfos.Count > 0)
                {
                    foreach (var item in _model.ProductInfos)
                    {
                        PdfPCell rowCell0 = GenerateCell($"{counter}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell1 = GenerateCell($"{item.AnimalType}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell2 = GenerateCell($"{item.AnimalKind}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell3 = GenerateCell($"{item.TagNumber}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell4 = GenerateCell($"{item.CertificateNumber}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell5 = GenerateCell($"{item.Gender}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell6 = GenerateCell($"{item.Age}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell7 = GenerateCell($"{item.OriginCountry}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell8 = GenerateCell($"{item.AnimalCount}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell9 = GenerateCell($"{item.VaccinationDate?.ToString("dd.MM.yyyy")}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell10 = GenerateCell($"{item.AgainstParasitesDate?.ToString("dd.MM.yyyy")}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);

                        counter++;

                        table.AddCell(rowCell0);
                        table.AddCell(rowCell1);
                        table.AddCell(rowCell2);
                        table.AddCell(rowCell3);
                        table.AddCell(rowCell4);
                        table.AddCell(rowCell5);
                        table.AddCell(rowCell6);
                        table.AddCell(rowCell7);
                        table.AddCell(rowCell8);
                        table.AddCell(rowCell9);
                        table.AddCell(rowCell10);
                    }
                }
                else
                {
                    PdfPCell emptyCell = GenerateCell("Məlumat yoxdur", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC, 8, columnWidths.Length);
                    table.AddCell(emptyCell);
                }

                table.HorizontalAlignment = Element.ALIGN_CENTER;
                documentVS.Add(table);
            }

            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                //table.PaddingTop = -50f;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = -10f;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = -20f;

                //Row 1
                var text0 = $"\nyoluxucu xəstəliklərə görə xəstə və ya xəstəliyə şübhəli heyvan aşkar olunmadı və onlar çıxarılır";
                Phrase phrase0 = new Phrase(text0, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row2
                var text1 = $"\n{defaultSpace}Hüquqi və ya fiziki şəxsin adı, VÖEN və ya FİN, ünvanı: ";
                var text2 = $"{_model.FullName}, {_model.IdentityOrPinCode}, {_model.Adress}";
                Phrase phrase1 = new Phrase(text1, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));
                Phrase phrase2 = new Phrase(text2, new Font(bf, 7.2f, Font.ITALIC, BaseColor.Black));

                //Row 3
                var text3 = $"\nxüsusi təhlükəli və karantin heyvan xəstəliklərinə görə sağlamdır.";
                Phrase phrase3 = new Phrase(text3, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row 4
                var text4 = $"\n{defaultSpace}Heyvan idxal olunan ölkənin tələbinə uyğun olaraq ixrac zamanı heyvanın çıxdığı təsərrüfat və ərazinin hansı müddətdə (ay, il) sağlam olduğu göstərilir: {_model.HealthPeriodMonth}/{_model.HealthPeriodYear}";
                Phrase phrase4 = new Phrase(text4, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row 5
                var text5 = $"\nHeyvan doğulduğu gündən, ";
                var text6 = $"6 ";
                var text7 = $"aydan az olmamaqla, yaxud “{_model.ExistencPeriod}” ay Azərbaycan Respublikasında olmuşdur.";
                Phrase phrase5 = new Phrase(text5, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));
                Phrase phrase6 = new Phrase(text6, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));
                Phrase phrase7 = new Phrase(text7, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row 6
                var text8 = $"\n{defaultSpace}Heyvan göndərilməmişdən əvvəl karantində saxlanılmışdır: {_model.KeepinQuarantineInfo}";
                Phrase phrase8 = new Phrase(text8, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                //Row 7
                var text9 = $"\n{defaultSpace}Karantin müddətində heyvan digər heyvanlarla kontaktda olmamışdır, hər gün bədən temperaturu ölçülmüş və kliniki baxış aparılmışdır, şəhadətnamə verilən gün müayinə edilmiş xəstə və xəstəliyə şübhəli heyvan aşkar edilməmişdir. Karantin müddətində heyvandan götürülmüş müayinə məlumatları cədvəldə əks edilmişdir.";
                Phrase phrase9 = new Phrase(text9, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row 8
                //var text12 = $"\nQoşma sənədi Cədvəl 2.1 (Laboratoriya nəticələri)";
                //Phrase phrase12 = new Phrase(text12, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase0);
                paragraph.Add(phrase1);
                paragraph.Add(phrase2);
                paragraph.Add(phrase3);
                paragraph.Add(phrase4);
                paragraph.Add(phrase5);
                paragraph.Add(phrase6);
                paragraph.Add(phrase7);
                paragraph.Add(phrase8);
                paragraph.Add(phrase9);
                //paragraph.Add(phrase12);

                paragraph.SpacingAfter = 0;
                paragraph.SpacingBefore = 0;
                paragraph.ExtraParagraphSpace = 0;
                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph.SetLeading(0, 1.4f);

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = 0;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = 5f;

                var text2 = $"\n{defaultSpace}Cədvəl 2.1 (Laboratoriya nəticələri)";

                Phrase phrase2 = new Phrase(text2, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase2);

                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                float[] columnWidths = { 3f, 13f, 15f, 8f, 8f, 15f, 15f }; // Set the width of each column
                int counter = 1;

                PdfPTable table = new PdfPTable(7);
                table.DefaultCell.Border = 2;
                table.WidthPercentage = 83;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                table.SplitLate = false;

                table.SetWidths(columnWidths);

                PdfPCell headerCell0 = GenerateCell("SN", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell1 = GenerateCell("Laboratoriya", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell2 = GenerateCell("Xəstəliyin adı", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell3 = GenerateCell("Başlama tarixi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell4 = GenerateCell("Bitmə tarixi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell5 = GenerateCell("Müayinə methodu", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell6 = GenerateCell("Müayinənin nəticəsi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));

                table.AddCell(headerCell0);
                table.AddCell(headerCell1);
                table.AddCell(headerCell2);
                table.AddCell(headerCell3);
                table.AddCell(headerCell4);
                table.AddCell(headerCell5);
                table.AddCell(headerCell6);

                if (_model.Items.Count > 0)
                {
                    foreach (var item in _model.Items)
                    {
                        PdfPCell rowCell0 = GenerateCell($"{counter}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell1 = GenerateCell($"{item.LaboratoryName}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell2 = GenerateCell($"{item.DiseaseName}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell3 = GenerateCell($"{item.CheckupStartDate?.ToString("dd.MM.yyyy")}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell4 = GenerateCell($"{item.CheckupEndDate?.ToString("dd.MM.yyyy")}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell5 = GenerateCell($"{item.CheckupMethod}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell6 = GenerateCell($"{item.CheckupResult}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);

                        counter++;

                        table.AddCell(rowCell0);
                        table.AddCell(rowCell1);
                        table.AddCell(rowCell2);
                        table.AddCell(rowCell3);
                        table.AddCell(rowCell4);
                        table.AddCell(rowCell5);
                        table.AddCell(rowCell6);
                    }
                }
                else
                {
                    PdfPCell emptyCell = GenerateCell("Məlumat yoxdur", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC, 8, columnWidths.Length);
                    table.AddCell(emptyCell);
                }

                table.HorizontalAlignment = Element.ALIGN_CENTER;
                documentVS.Add(table);
            }

            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                //table.PaddingTop = -50f;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = -10f;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = -50f;

                //Row 3
                var text4 = $"\n{defaultSpace}Müşayiət edilən yük və qablaşdırma materialları bilavasitə yükgöndərənin təsərrüfatından çıxır və infeksion xəstəlik törədiciləri ilə kontaktda olmamışdır. ";
                Phrase phrase4 = new Phrase(text4, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row 4
                //var text5 = $"\nQoşma sənədi Cədvəl 3.1 (Marşurut haqqında məlumatlar)";
                //Phrase phrase5 = new Phrase(text5, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));


                //Row 6
                //var text9 = $"\nQoşma sənədi Cədvəl 4.1 (Nəqliyyat vasitəsi)";
                //Phrase phrase9 = new Phrase(text9, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase4);
                //paragraph.Add(phrase5);
                //paragraph.Add(phrase9);

                paragraph.SpacingAfter = 0;
                paragraph.SpacingBefore = 0;
                paragraph.ExtraParagraphSpace = 0;
                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph.SetLeading(0, 1.4f);

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = -9f;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = 5f;

                var text2 = $"\n{defaultSpace}Cədvəl 3.1 (Marşurut haqqında məlumatlar)";

                Phrase phrase2 = new Phrase(text2, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase2);

                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                float[] columnWidths = { 2f, 15f, 15f, 20f, 4f, 10f, 7f }; // Set the width of each column
                int counter = 1;

                PdfPTable table = new PdfPTable(7);
                table.DefaultCell.Border = 2;
                table.WidthPercentage = 83;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                table.SplitLate = false;

                table.SetWidths(columnWidths);

                PdfPCell headerCell0 = GenerateCell("SN", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell1 = GenerateCell("Çıxış məntəqəsi(rayon, kənd)", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell2 = GenerateCell("Qəbul məntəqəsi (rayon, kənd)", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell3 = GenerateCell("Qəbul edən", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell4 = GenerateCell("Baş sayı", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell5 = GenerateCell("Cinsləri", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell6 = GenerateCell("İstifadə təyinatı", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));

                table.AddCell(headerCell0);
                table.AddCell(headerCell1);
                table.AddCell(headerCell2);
                table.AddCell(headerCell3);
                table.AddCell(headerCell4);
                table.AddCell(headerCell5);
                table.AddCell(headerCell6);

                if (_model.RouteInfos.Count > 0)
                {
                    foreach (var item in _model.RouteInfos)
                    {
                        PdfPCell rowCell0 = GenerateCell($"{counter}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell1 = GenerateCell($"{item.ExitRegion}, {item.ExitCity}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell2 = GenerateCell($"{item.ReachRegion}, {item.ReachCity}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell3 = GenerateCell($"{item.FullName}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell4 = GenerateCell($"{item.AnimalCount}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell5 = GenerateCell($"{item.AnimalType}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                        PdfPCell rowCell6 = GenerateCell($"{item.ProductDesignation}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);

                        counter++;

                        table.AddCell(rowCell0);
                        table.AddCell(rowCell1);
                        table.AddCell(rowCell2);
                        table.AddCell(rowCell3);
                        table.AddCell(rowCell4);
                        table.AddCell(rowCell5);
                        table.AddCell(rowCell6);
                    }
                }
                else
                {
                    PdfPCell emptyCell = GenerateCell("Məlumat yoxdur", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC, 8, columnWidths.Length);
                    table.AddCell(emptyCell);
                }

                table.HorizontalAlignment = Element.ALIGN_CENTER;
                documentVS.Add(table);
            }
            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = -20f;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = 5f;

                var text2 = $"\n{defaultSpace}Cədvəl 4.1 (Nəqliyyat vasitəsi)";

                Phrase phrase2 = new Phrase(text2, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase2);

                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                float[] columnWidths = { 2f, 15f, 15f, 15f }; // Set the width of each column
                int counter = 1;

                PdfPTable table = new PdfPTable(4);
                table.DefaultCell.Border = 2;
                table.WidthPercentage = 83;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                table.SplitLate = true;
                //table.PaddingTop = -18f;

                table.SetWidths(columnWidths);

                PdfPCell headerCell0 = GenerateCell("SN", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell1 = GenerateCell("Nəqliyyatın növü", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell2 = GenerateCell("Əsas nömrəsi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));
                PdfPCell headerCell3 = GenerateCell("Qoşqu nömrəsi", new BaseColor(238, 238, 228), new BaseColor(0, 0, 0));

                table.AddCell(headerCell0);
                table.AddCell(headerCell1);
                table.AddCell(headerCell2);
                table.AddCell(headerCell3);

                if (_model.Transportation != null)
                {
                    PdfPCell rowCell0 = GenerateCell($"{counter}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                    PdfPCell rowCell1 = GenerateCell($"{_model.Transportation.DN_TransportType}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                    PdfPCell rowCell2 = GenerateCell($"{_model.Transportation.TransportNumber}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);
                    PdfPCell rowCell3 = GenerateCell($"{_model.Transportation.TrailerNumber}", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC);

                    table.AddCell(rowCell0);
                    table.AddCell(rowCell1);
                    table.AddCell(rowCell2);
                    table.AddCell(rowCell3);
                }
                else
                {
                    PdfPCell emptyCell = GenerateCell("Məlumat yoxdur", new BaseColor(255, 255, 255), new BaseColor(0, 0, 0), Font.ITALIC, 8, columnWidths.Length);
                    table.AddCell(emptyCell);
                }


                table.HorizontalAlignment = Element.ALIGN_CENTER;
                documentVS.Add(table);
            }

            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                //table.PaddingTop = -50f;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = -10f;
                cell.PaddingLeft = 50f;
                cell.Border = 0;
                cell.PaddingBottom = -20f;

                //Row 1
                var text0 = $"\n{defaultSpace}Nəqliyyat vasitələri təmizlənib və dezinfeksiya edilmişdir.\f";
                Phrase phrase0 = new Phrase(text0, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row2
                var text2 = $"\n{defaultSpace}Qeydlər: ";
                var text3 = _model.Description;
                Phrase phrase2 = new Phrase(text2, new Font(bf, 7.2f, Font.BOLD, BaseColor.Black));
                Phrase phrase3 = new Phrase(text3, new Font(bf, 7.2f, Font.BOLDITALIC, BaseColor.Black));

                //Row 3
                var text4 = $"\n{defaultSpace}Şəhadətnamə yükləmə və yol boyu yükün hərəkəti zamanı nəzarət üçün təqdim edilir və yük sahibinə təhvil verilir. Şəhadətnamənin surəti etibarsızdır. Şəhadətnamə blankının doldurulması qaydasında pozuntu hallan müəyyən edildikdə, aşkar olunmuş pozuntu göstərilməklə, şəhadətnamə Azərbaycan Respublikasının baş dövlət baytarlıq müfəttişinə təqdim edilir.";
                Phrase phrase4 = new Phrase(text4, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));

                //Row 4
                var text5 = $"\n{defaultSpace}Sənədin verilməsi tarixi: ";
                var text6 = $"{_model.GeneratedDate?.ToString("dd/MM/yyyy")}";
                Phrase phrase5 = new Phrase(text5, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));
                Phrase phrase6 = new Phrase(text6, new Font(bf, 7.2f, Font.ITALIC, BaseColor.Black));

                //Row 5
                var text7 = $"\n{defaultSpace}Sənədin etibarllıq tarixi: ";
                var text8 = $"{_model.ExpiredDate?.ToString("dd/MM/yyyy")}";
                Phrase phrase7 = new Phrase(text7, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black));
                Phrase phrase8 = new Phrase(text8, new Font(bf, 7.2f, Font.ITALIC, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase0);
                paragraph.Add(phrase2);
                paragraph.Add(phrase3);
                paragraph.Add(phrase4);
                paragraph.Add(phrase5);
                paragraph.Add(phrase6);
                paragraph.Add(phrase7);
                paragraph.Add(phrase8);

                paragraph.SpacingAfter = 0;
                paragraph.SpacingBefore = 0;
                paragraph.ExtraParagraphSpace = 0;
                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph.SetLeading(0, 1.4f);

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = 0;
                table.WidthPercentage = 90;
                table.SpacingAfter = 0;
                table.SpacingBefore = 0;
                //table.PaddingTop = -50f;

                PdfPCell cell = new PdfPCell();
                cell.PaddingTop = -20f;
                cell.PaddingLeft = 150f;
                cell.Border = 0;

                //Row 1
                var text1 = $"\n\n\nBaytarıq müfəttişi: ";
                var text2 = $"{defaultSpace}{defaultSpace}{_model.InspectorName}";
                Phrase phrase1 = new Phrase(text1, new Font(bf, 9, Font.BOLD, BaseColor.Black));
                Phrase phrase2 = new Phrase(text2, new Font(bf, 9, Font.BOLDITALIC, BaseColor.Black));

                Paragraph paragraph = new Paragraph();
                paragraph.Add(phrase1);
                paragraph.Add(phrase2);

                paragraph.SpacingAfter = 0;
                paragraph.SpacingBefore = 0;
                paragraph.ExtraParagraphSpace = 0;
                //paragraph.PaddingTop = 0;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                cell.AddElement(paragraph);

                AddCellToDocument(table, cell, Element.ALIGN_JUSTIFIED);
            }
            //documentVS.NewPage();
            //{
            //    var table5 = GetDefaultBorderedTable(1);
            //    //var text = $"\nBAYTARLIQ ŞƏHADƏTNAMƏSİ №: ";
            //    var text = $"\nBAYTARLIQ ŞƏHADƏTNAMƏSİ";
            //    var text2 = $"\nQOŞMA SƏNƏDİ";
            //    Phrase headerNameS = new Phrase(text, new Font(bf, 12, Font.BOLD, BaseColor.Black));
            //    Phrase headerName2 = new Phrase(text2, new Font(bf, 12, Font.BOLD, BaseColor.Black));
            //    //Phrase headerNameD = new Phrase(_model.UnicalNumber, new Font(bf, 14, Font.BOLD, new BaseColor(29, 97, 167)));

            //    Paragraph headerP = new Paragraph();
            //    headerP.Add(headerNameS);
            //    headerP.Add(headerName2);
            //    //headerP.Add(headerNameD);

            //    _cell = GetDefaultCell(headerP, 10);
            //    _cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    _cell.BorderWidthBottom = 0;
            //    _cell.Padding = 1f;
            //    table5.AddCell(_cell);
            //    documentVS.Add(table5);
            //}

        }

        public override void AddFooter()
        {
        }

        public override PdfPTable AddFooterSpecial()
        {

            var applicationTable6 = new PdfPTable(3);
            applicationTable6.TotalWidth = document.PageSize.Width - 100;
            //applicationTable6.FooterHeight = document.PageSize.Height-10;


            PdfPCell spaceCell2 = new PdfPCell(new Paragraph(new Phrase("\n\n\n", new Font(bf, 10, Font.NORMAL))));
            spaceCell2.Border = 0;
            applicationTable6.AddCell(spaceCell2);

            PdfPCell spaceCell3 = new PdfPCell(new Paragraph(new Phrase("\n\n\n", new Font(bf, 10, Font.NORMAL))));
            spaceCell3.Border = 0;
            applicationTable6.AddCell(spaceCell3);

            PdfPCell spaceCell4 = new PdfPCell(new Paragraph(new Phrase("\n\n\n", new Font(bf, 10, Font.NORMAL))));
            spaceCell4.Border = 0;
            applicationTable6.AddCell(spaceCell4);



            bFont = new Font(bf, 10, Font.NORMAL);
            applicationTable6.DefaultCell.BorderWidthTop = 0;
            applicationTable6.DefaultCell.BorderWidthRight = 0;
            applicationTable6.DefaultCell.BorderWidthLeft = 0;
            applicationTable6.DefaultCell.BorderWidthBottom = 0;

            //string imagepathLogo = System.Web.HttpContext.Current.Server.MapPath("~/Content/img/aqtis_logo.png");
            string imagepathLogo = "~/Content/img/aqtis_logo.png";
            Image image1 = Image.GetInstance(imagepathLogo);
            image1.ScaleAbsolute(70f, 50f);
            PdfPCell imageCell = new PdfPCell(image1);
            imageCell.BorderWidthRight = 0f;
            imageCell.BorderWidthLeft = 0f;
            imageCell.BorderColorTop = new BaseColor(29, 97, 167);
            imageCell.BorderWidthBottom = 0f;
            imageCell.BorderWidthTop = 0.3f;
            imageCell.PaddingTop = 2f;
            imageCell.HorizontalAlignment = Element.ALIGN_LEFT;
            imageCell.FixedHeight = 50f;
            applicationTable6.AddCell(imageCell);




            _cell = GetDefaultCell(new Paragraph(new Phrase($"xx \nAvtomatlaşdırılmış Qida Təhlükəsizliyi İnformasiya sistemi – AQTİS\nİmzalayan şəxs: {_model.InspectorName}\nQEYD: “Elektron imza və elektron sənəd” haqqında Azərbaycan Respublikası Qanununun 3-cü maddəsinə əsasən elektron imza əl imzası ilə bərabər hüquqi qüvvəyə malikdir.Elektron imza şəxsin kağız daşıyıcı üzərindəki möhürlə təsdiq edilmiş əl imzasına bərabər tutulur.", new Font(bf, 7, Font.NORMAL, new BaseColor(29, 97, 167)))));
            _cell.HorizontalAlignment = Element.ALIGN_LEFT;
            _cell.BorderColorTop = new BaseColor(29, 97, 167);
            _cell.BorderWidthLeft = 0;
            _cell.BorderWidthRight = 0;
            _cell.BorderWidthTop = 0.3f;
            _cell.FixedHeight = 50f;
            applicationTable6.AddCell(_cell);


            #region qr code


            //QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            ////string url;
            ////var env = Environment.GetEnvironmentVariable("ENV", EnvironmentVariableTarget.Machine);
            ////if (env == ENV.DEVELOPMENT.ToString()) _model.QRUrl = "http://localhost:4340/Certification/VeterinaryCertificateReportQrCode/" + _model.Id;
            ////else if (env == ENV.STAGING.ToString()) _model.QRUrl = "http://test.afsa.gov.az/web/Certification/VeterinaryCertificateReportQrCode/" + _model.Id;
            ////else if (env == ENV.PRODUCTION.ToString()) _model.QRUrl = "https://e-afsa.gov.az/Certification/VeterinaryCertificateReportQrCode/" + _model.Id;

            //QRCodeData qrData = qrGenerator.CreateQrCode(_model.QRUrl, QRCoder.QRCodeGenerator.ECCLevel.L);
            //var qrCode = new QRCoder.QRCode(qrData);
            //var qrImage = (System.Drawing.Image)qrCode.GetGraphic(2);
            //var imageqr = Image.GetInstance(qrImage, System.Drawing.Imaging.ImageFormat.Png);
            //imageqr.ScaleAbsolute(50f, 50f);
            //PdfPCell qrImageCell = new PdfPCell(imageqr);
            //qrImageCell.BorderWidthRight = 0f;
            //qrImageCell.BorderWidthLeft = 0f;
            //qrImageCell.BorderWidthBottom = 0f;
            //qrImageCell.BorderColorTop = new BaseColor(29, 97, 167);
            //qrImageCell.BorderWidthTop = 0.3f;
            //qrImageCell.PaddingTop = 2f;
            //qrImageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //qrImageCell.FixedHeight = 50f;


            //applicationTable6.AddCell(qrImageCell);
            #endregion


            float[] columnWidths = new float[] { 40f, 200f, 40f };
            applicationTable6.SetWidths(columnWidths);

            return applicationTable6;
        }

        #region private
        private PdfPCell GenerateCell(string text, BaseColor baseColor, BaseColor textColor, int style = 0, float size = 7.2f, int colSpan = 1)
        {
            PdfPCell headerCell = new PdfPCell();

            // Set padding for top and bottom of the cell
            headerCell.PaddingTop = 5f;
            headerCell.PaddingBottom = 5f;

            Paragraph headerP = new Paragraph(new Phrase(text, new Font(bf, size, style, textColor)));
            //headerP.PaddingTop = 0;

            // Set horizontal alignment to center
            headerP.Alignment = Element.ALIGN_CENTER;

            // Set vertical alignment to center within the cell
            headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            // Remove spacing between lines
            headerP.SpacingAfter = 0;
            headerP.SpacingBefore = 0;

            // Set leading (line spacing) to 1
            headerP.SetLeading(0, 1f);

            headerCell.AddElement(headerP);
            headerCell.BackgroundColor = baseColor;

            // Set the number of columns to span
            headerCell.Colspan = colSpan;

            return headerCell;
        }
        private PdfPCell GenerateCellWithPadding(float cellPaddingTop, float cellPaddingBottom, string text, BaseColor baseColor, BaseColor textColor, int style = 0, float size = 8)
        {
            PdfPCell headerCell = GenerateCell(text, baseColor, textColor, style, size);

            headerCell.PaddingTop = cellPaddingTop;
            headerCell.PaddingBottom = cellPaddingBottom;

            return headerCell;
        }
        private PdfPCell GenerateCellWithoutBorder(string text, BaseColor baseColor)
        {
            PdfPCell headerCell = new PdfPCell();
            Paragraph headerP = new Paragraph(new Phrase(text, new Font(bf, 7.2f, Font.NORMAL, BaseColor.Black)));
            //headerP.PaddingTop = 0;
            headerP.Alignment = Element.ALIGN_CENTER;
            headerCell.AddElement(headerP);
            headerCell.BackgroundColor = baseColor;
            headerCell.Border = 0;
            return headerCell;
        }
        private void AddCellToDocument(PdfPTable Table, PdfPCell Cell, int alignment)
        {
            Table.AddCell(Cell);
            Table.HorizontalAlignment = alignment;
            documentVS.Add(Table);
        }
        #endregion
        public class HeaderFooter : PdfPageEventHelper
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
    }
}
