using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LerPDF.Azurra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            GerarTabelaPdf();
        }
        private void GerarTabelaPdf()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PDF files|*.pdf", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(ofd.FileName);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                        richTextBox1.Text = sb.ToString();
                        reader.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
