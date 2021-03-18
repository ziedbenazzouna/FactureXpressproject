using FactureXpressProject.Data;
using FactureXpressProject.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FactureXpressProject.Report
{
    public class CommandeReport
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;

        public CommandeReport(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _context = context;
            _env = env;

        }

        int _totalColumn = 4;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(4);
        PdfPTable _pdfTableInfos = new PdfPTable(1);
        PdfPTable _pdfTableTotal = new PdfPTable(1);
        PdfPTable _pdfTableComment = new PdfPTable(1);
        PdfPTable _pdfTableClient = new PdfPTable(1);
        PdfPTable _pdfTableFacture = new PdfPTable(1);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Commande> _commandes = new List<Commande>();

        public byte[] PrepareReport(List<Commande> commandes)
        {
            _commandes = commandes;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTableInfos.WidthPercentage = 30;
            _pdfTableClient.WidthPercentage = 20;
            _pdfTableFacture.WidthPercentage = 20;
            _pdfTableTotal.WidthPercentage = 20;
            _pdfTableComment.WidthPercentage = 35;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfTableInfos.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfTableClient.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfTableTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfTableFacture.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfTableComment.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 40f, 200f, 70f, 70f });

            this.ReportHeader(_commandes);
            this.ReportBody(_commandes);
            this.ReportFooter(_commandes);
            _pdfTable.HeaderRows = 1;
            _document.Add(_pdfTableInfos);
            _document.Add(_pdfTableFacture);
            _document.Add(_pdfTableClient);
            _document.Add(_pdfTable);
            _document.Add(_pdfTableTotal);
            _document.Add(_pdfTableComment);
            _document.Close();
            return _memoryStream.ToArray();
        }
        private void ReportHeader(List<Commande> commandes)
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Tunis le: " + DateTime.Now.ToString("dd/MM/yyyy"), _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableFacture.AddCell(_pdfPCell);
            _pdfTableFacture.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 20f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Facture", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableFacture.AddCell(_pdfPCell);
            _pdfTableFacture.CompleteRow();

            _pdfTableFacture.SpacingBefore = 20;
            _pdfTableFacture.SpacingAfter = 20;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("A: " + commandes.FirstOrDefault().Client.FullName, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableClient.AddCell(_pdfPCell);
            _pdfTableClient.CompleteRow();


            _pdfTableClient.SpacingBefore = 20;
            _pdfTableClient.SpacingAfter = 0;

            //
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine(_env.WebRootPath, "Images", "logo.png"));
            logo.ScaleAbsolute(100f, 50f);
            _pdfPCell = new PdfPCell(logo);
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
            _pdfTableInfos.AddCell(_pdfPCell);
            _pdfTableInfos.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Impression numérique", _fontStyle));
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            _pdfTableInfos.AddCell(_pdfPCell);
            _pdfTableInfos.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("3 Rue de l'inépendance - Denden", _fontStyle));
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            _pdfTableInfos.AddCell(_pdfPCell);
            _pdfTableInfos.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("R.C.: D2414032010", _fontStyle));
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            _pdfTableInfos.AddCell(_pdfPCell);
            _pdfTableInfos.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Code T.V.A.: 1144382/H/A/M/000", _fontStyle));
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;

            _pdfTableInfos.AddCell(_pdfPCell);
            _pdfTableInfos.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("GSM: 22 807 944", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
            _pdfPCell.BorderWidthBottom = 1;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableInfos.AddCell(_pdfPCell);
            _pdfTableInfos.CompleteRow();

            _pdfTableInfos.SpacingBefore = 20;
            _pdfTableInfos.SpacingAfter = 20;

        }
        private void ReportBody(List<Commande> commandes)
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Quantité", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Désignation", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Prix.U", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Prix . Total", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            foreach (Commande cmd in commandes)
            {
                var Produits = _context.Produits.Where(p => p.CommandeId == cmd.CommandeId).ToList();
                foreach (Produit p in Produits)
                {
                    _pdfPCell = new PdfPCell(new Phrase(p.Qantity.ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(p.Description, _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(p.Price.Value.ToString("#,##0"), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase((p.Price * p.Qantity).Value.ToString("#,##0"), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfTable.AddCell(_pdfPCell);
                    _pdfTable.CompleteRow();

                }

            }

            _pdfTable.SpacingBefore = 20;
            _pdfTable.SpacingAfter = 20;
        }
        private void ReportFooter(List<Commande> commandes)
        {
            int? somme = 0;
            int? tva = 0;
            int? ttc = 0;
            int timbre = 0;
            int? total = 0;
            foreach (Commande cmd in commandes)
            {
                var Produits = _context.Produits.Where(p => p.CommandeId == cmd.CommandeId).ToList();
                foreach (Produit p in Produits)
                {
                    somme = somme + (p.Price * p.Qantity);
                }
                tva = (somme * 19) / 100;
                ttc = somme + tva;
                timbre = 600;
                total = ttc + timbre;
                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            }

            _pdfPCell = new PdfPCell(new Phrase("Total HTVA      " + somme.Value.ToString("#,##0"), _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableTotal.AddCell(_pdfPCell);
            _pdfTableTotal.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("T.V.A 19%       " + tva.Value.ToString("#,##0"), _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableTotal.AddCell(_pdfPCell);
            _pdfTableTotal.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Total T.T.C.     " + ttc.Value.ToString("#,##0"), _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableTotal.AddCell(_pdfPCell);
            _pdfTableTotal.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Timbre fiscale          " + timbre.ToString("#,##0"), _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableTotal.AddCell(_pdfPCell);
            _pdfTableTotal.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("NET A PAYER     " + total.Value.ToString("#,##0"), _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
            _pdfPCell.BorderWidthBottom = 1;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableTotal.AddCell(_pdfPCell);
            _pdfTableTotal.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Arreté la présence facture à la somme de : ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableComment.AddCell(_pdfPCell);

            _pdfTableComment.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("........................................................................", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableComment.AddCell(_pdfPCell);

            _pdfTableComment.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("........................................................................", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTableComment.AddCell(_pdfPCell);
            _pdfTableComment.CompleteRow();
            _pdfTableComment.SpacingBefore = 50;
        }
    }
}
