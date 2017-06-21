using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Model;
using Razor;
using HiQPdf;
using System.Web.Script.Serialization;

namespace InvoiceTemplateTestHarness
{
    public partial class Form1 : Form
    {

        TemplateOption templateOption = null;
        float leftStartXPoint = (float)2.5;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create Invoice action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            DocumentTemplate template = new DocumentTemplate();

            template.HeaderCsHtml = txbHeader.Text;
            template.BodyCsHtml = txbBody.Text;
            template.FooterCsHtml = txbFooter.Text;

            string templateOptionsJson = txbTemplateOption.Text;
            List<TemplateOption> templateOptionsList = new JavaScriptSerializer().Deserialize<List<TemplateOption>>(templateOptionsJson);
            TemplateOption templateOptions = templateOptionsList[0];

            CreatePDFBasedOnCsHtmlTemplate(template, txbOutput.Text, templateOptions);

            

            MessageBox.Show(txbOutput.Text + " was created successfully.");
        }



        /// <summary>
        /// This function is used for creating the invoice based on cshtml templates
        /// </summary>
        /// <param name="documentTemplate"></param>
        /// <param name="filePathToSave"></param>
        /// <param name="templateOption"></param>
        /// <returns></returns>
        public bool CreatePDFBasedOnCsHtmlTemplate(DocumentTemplate documentTemplate, string filePathToSave, TemplateOption templateOption = null)
        {
            FileStream objFileStream = null;

            try
            {
                string headerHtml = string.Empty;
                string bodyHtml = string.Empty;
                string footerHtml = string.Empty;


                documentTemplate.InvoicePdfGenerationDetails = new InvoicePdfGenerationDetails() { ImagesFolderRootPath = "" };

                if (!string.IsNullOrWhiteSpace(documentTemplate.HeaderCsHtml))
                {
                    // Getting the header html
                    headerHtml = RazorBoss.GetHtmlFromRazorView(documentTemplate.HeaderCsHtml, documentTemplate.InvoicePdfGenerationDetails);
                }

                if (!string.IsNullOrWhiteSpace(documentTemplate.BodyCsHtml))
                {
                    // Getting the body Html
                    bodyHtml = RazorBoss.GetHtmlFromRazorView(documentTemplate.BodyCsHtml, documentTemplate.InvoicePdfGenerationDetails);
                }

                if (!string.IsNullOrWhiteSpace(documentTemplate.FooterCsHtml))
                {
                    // Getting the footer html
                    footerHtml = RazorBoss.GetHtmlFromRazorView(documentTemplate.FooterCsHtml, documentTemplate.InvoicePdfGenerationDetails);
                }

                // Getting the blob data based on generated html and template option for file creation
                byte[] blob = CreatePDFBasedOnHTMLTemplate(headerHtml, bodyHtml, footerHtml, templateOption);

                // Creating the file stream object and writing to the file
                objFileStream = new FileStream(filePathToSave, FileMode.Create);
                objFileStream.Write(blob, 0, blob.Length);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.InnerException.Message);
                throw;
            }
            finally
            {
                // Closing and disposing the file stream object
                if (objFileStream != null)
                {
                    objFileStream.Close();
                    objFileStream.Dispose();
                }
            }
        }

        public bool CreateHtmlBasedOnCsHtmlTemplate(DocumentTemplate documentTemplate, string filePathToSave, TemplateOption templateOption = null)
        {
            FileStream objFileStream = null;

            try
            {
                string headerHtml = string.Empty;
                string bodyHtml = string.Empty;
                string footerHtml = string.Empty;


                documentTemplate.InvoicePdfGenerationDetails = new InvoicePdfGenerationDetails() { ImagesFolderRootPath = "" };

                if (!string.IsNullOrWhiteSpace(documentTemplate.HeaderCsHtml))
                {
                    // Getting the header html
                    headerHtml = RazorBoss.GetHtmlFromRazorView(documentTemplate.HeaderCsHtml, documentTemplate.InvoicePdfGenerationDetails);
                }

                if (!string.IsNullOrWhiteSpace(documentTemplate.BodyCsHtml))
                {
                    // Getting the body Html
                    bodyHtml = RazorBoss.GetHtmlFromRazorView(documentTemplate.BodyCsHtml, documentTemplate.InvoicePdfGenerationDetails);
                }

                if (!string.IsNullOrWhiteSpace(documentTemplate.FooterCsHtml))
                {
                    // Getting the footer html
                    footerHtml = RazorBoss.GetHtmlFromRazorView(documentTemplate.FooterCsHtml, documentTemplate.InvoicePdfGenerationDetails);
                }

                // We write out html here :
                StringBuilder buffer = new StringBuilder();
                buffer.Append("<Html><head></head><body>");
                buffer.Append(headerHtml);
                buffer.Append(bodyHtml);
                buffer.Append(footerHtml);
                buffer.Append("</body></Html>");
                // we get html 
                byte[] blob = Encoding.ASCII.GetBytes(buffer.ToString());




                // Creating the file stream object and writing to the file
                objFileStream = new FileStream(filePathToSave, FileMode.Create);
                objFileStream.Write(blob, 0, blob.Length);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.InnerException.Message);
                throw;
            }
            finally
            {
                // Closing and disposing the file stream object
                if (objFileStream != null)
                {
                    objFileStream.Close();
                    objFileStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Returns pdf content based on html content 
        /// </summary>
        /// <param name="headerHtml"></param>
        /// <param name="bodyHtml"></param>
        /// <param name="footerHtml"></param>
        /// <param name="templateOption"></param>
        /// <returns></returns>
        public Byte[] CreatePDFBasedOnHTMLTemplate(string headerHtml, string bodyHtml, string footerHtml, TemplateOption templateOption = null)
        {
            string baseUrl = string.Empty;
            

            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
            PdfDocumentControl doc = htmlToPdfConverter.Document;
            doc.FontEmbedding = true;
            this.templateOption = templateOption;
            if (templateOption != null)
            {
                if (templateOption.PageMargin != null)
                {
                    htmlToPdfConverter.PageLayoutingEvent += htmlToPdfConverter_PageLayoutingEvent;

                    htmlToPdfConverter.Document.Margins = new PdfMargins(templateOption.PageMargin.LeftMargin, templateOption.PageMargin.RightMargin, templateOption.PageMargin.TopMargin, templateOption.PageMargin.BottomMargin);
                }

                // Setting page orientation
                if (templateOption.IsLandscapeOrientation)
                {
                    htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Landscape;
                }
            }
            htmlToPdfConverter.SerialNumber = "bad==";

            // set header and footer
            SetHeader(htmlToPdfConverter.Document, headerHtml, baseUrl, templateOption);
            SetFooter(htmlToPdfConverter.Document, footerHtml, baseUrl, templateOption);

            

            
            return htmlToPdfConverter.ConvertHtmlToMemory(bodyHtml, baseUrl);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventParams"></param>
        private void htmlToPdfConverter_PageLayoutingEvent(PdfPageLayoutingParams eventParams)
        {
            if ((templateOption != null) && (templateOption.PageMargin != null))
            {
                PdfPage page = eventParams.PdfPage;
                PdfLine leftLine = new PdfLine(new System.Drawing.PointF(leftStartXPoint, 0), new System.Drawing.PointF(leftStartXPoint, page.DrawableRectangle.Height));
                PdfLine rightLine = new PdfLine(new System.Drawing.PointF((float)(page.DrawableRectangle.Width - 2.5), 0), new System.Drawing.PointF((float)(page.DrawableRectangle.Width - 2.5), page.DrawableRectangle.Height));
                PdfFont font = page.Document.CreateStandardFont(PdfStandardFont.TimesRoman);


                //Border Color for the PDF 
                if (!string.IsNullOrEmpty(templateOption.PageMargin.Color))
                {
                    leftLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    leftLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    rightLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    rightLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                }
                page.Layout(leftLine);
                page.Layout(rightLine);
            }
        }

        /// <summary>
        /// updates the html header based on html content
        /// </summary>
        /// <param name="pdfDocumentControl"></param>
        /// <param name="headerHtml"></param>
        /// <param name="baseUri"></param>
        /// <param name="templateOption"></param>
        private void SetHeader(PdfDocumentControl pdfDocumentControl, string headerHtml, string baseUri, TemplateOption templateOption = null)
        {
            PdfHtml headerPdfHtml = new PdfHtml(headerHtml, baseUri);

            pdfDocumentControl.Header.Enabled = true;
            float pdfPageWidth = 0, headerWidth = 0, headerHeight = 0;
            if (templateOption != null)
            {
                if (templateOption.HeaderHeight.HasValue)
                {
                    pdfDocumentControl.Header.Height = templateOption.HeaderHeight.Value;
                }

                pdfPageWidth = pdfDocumentControl.PageOrientation == PdfPageOrientation.Portrait ?
                                pdfDocumentControl.PageSize.Width : pdfDocumentControl.PageSize.Height;

                headerWidth = pdfPageWidth - pdfDocumentControl.Margins.Left - pdfDocumentControl.Margins.Right;
                headerHeight = pdfDocumentControl.Header.Height;

                PdfLine leftLine = new PdfLine(new System.Drawing.PointF(leftStartXPoint, 10), new System.Drawing.PointF(leftStartXPoint, headerHeight));
                PdfLine rightLine = new PdfLine(new System.Drawing.PointF((float)(headerWidth - 2.5), 10), new System.Drawing.PointF((float)(headerWidth - 2.5), headerHeight));
                PdfLine topLine = new PdfLine(new System.Drawing.PointF(leftStartXPoint, 10), new System.Drawing.PointF((float)(headerWidth - 2.5), 10));

                //Border Color for the PDF 
                if (!string.IsNullOrEmpty(templateOption.PageMargin.Color))
                {
                    leftLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    leftLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    rightLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    rightLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    topLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    topLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                }

                pdfDocumentControl.Header.Layout(leftLine);
                pdfDocumentControl.Header.Layout(rightLine);
                pdfDocumentControl.Header.Layout(topLine);

            }
            // add page numbering in a text element
            System.Drawing.Font pageNumberingFont = new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 8, System.Drawing.GraphicsUnit.Point);
            PdfText pageNumberingText = new PdfText(headerWidth - 60, 0,"Page {CrtPage} of {PageCount}", pageNumberingFont);
            pageNumberingText.EmbedSystemFont = true;
            pdfDocumentControl.Header.Layout(pageNumberingText);
            pdfDocumentControl.Header.Layout(headerPdfHtml);
        }

        /// <summary>
        /// Updates the footer based on html content
        /// </summary>
        /// <param name="pdfDocumentControl"></param>
        /// <param name="footerHtml"></param>
        /// <param name="baseUri"></param>
        /// <param name="templateOption"></param>
        private void SetFooter(PdfDocumentControl pdfDocumentControl, string footerHtml, string baseUri, TemplateOption templateOption = null)
        {
            PdfHtml footerPdfHtml = new PdfHtml(footerHtml, baseUri);
            pdfDocumentControl.Footer.Enabled = true;
            if (templateOption != null)
            {
                if (templateOption.FooterHeight.HasValue)
                {
                    pdfDocumentControl.Footer.Height = templateOption.FooterHeight.Value;
                }

                if (templateOption.PageMargin != null)
                {
                    PageBorder pageBorder = templateOption.PageMargin;

                    float pdfPageWidth = pdfDocumentControl.PageOrientation == PdfPageOrientation.Portrait ?
                                   pdfDocumentControl.PageSize.Width : pdfDocumentControl.PageSize.Height;

                    float footerWidth = pdfPageWidth - pdfDocumentControl.Margins.Left - pdfDocumentControl.Margins.Right;
                    float footerHeight = pdfDocumentControl.Footer.Height;

                    PdfLine leftLine = new PdfLine(new System.Drawing.PointF(leftStartXPoint, 0), new System.Drawing.PointF(leftStartXPoint, footerHeight));
                    PdfLine rightLine = new PdfLine(new System.Drawing.PointF((float)(footerWidth - 2.5), 0), new System.Drawing.PointF((float)(footerWidth - 2.5), footerHeight));
                    PdfLine bottomLine = new PdfLine(new System.Drawing.PointF(leftStartXPoint, footerHeight), new System.Drawing.PointF((float)(footerWidth - 2.5), footerHeight));

                    //Border Color for the PDF 
                    if (!string.IsNullOrEmpty(templateOption.PageMargin.Color))
                    {
                        leftLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                        leftLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                        rightLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                        rightLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                        bottomLine.ForeColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                        bottomLine.BackColor = System.Drawing.Color.FromName(templateOption.PageMargin.Color);
                    }
                    pdfDocumentControl.Footer.Layout(leftLine);
                    pdfDocumentControl.Footer.Layout(rightLine);
                    pdfDocumentControl.Footer.Layout(bottomLine);
                }
            }
            pdfDocumentControl.Footer.Layout(footerPdfHtml);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnHeaderOpen_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txbHeader.Text = openFileDialog1.FileName;
            }
        }

        private void btnBodyOpen_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txbBody.Text = openFileDialog1.FileName;
            }
        }

        private void btnFooterOpen_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txbFooter.Text = openFileDialog1.FileName;
            }
        }

        private void btnSetLocation_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter =
            "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
          
                txbOutput.Text = saveFileDialog1.FileName;
            }
        }

    }
}
