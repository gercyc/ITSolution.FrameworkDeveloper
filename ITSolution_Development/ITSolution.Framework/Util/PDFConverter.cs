using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
/**
* Essa classe depende da DLL iTextSharp
*/
namespace ITSolution.Framework.Util
{
    public class PDFConverter
    {
        public static string PrintPDFToText(string pdfPath)
        {
            using (PdfReader leitor = new PdfReader(pdfPath))
            {
                StringBuilder texto = new StringBuilder();

                for (int i = 1; i <= leitor.NumberOfPages; i++)
                {
                    texto.Append(PdfTextExtractor.GetTextFromPage(leitor, i));
                }
                return texto.ToString();
            }
        }

        public static int GetNumberPagesOfPDF(string pdfPath)

        {

            int result = 0;

            FileStream fs = new FileStream(pdfPath, FileMode.Open, FileAccess.Read);

            StreamReader r = new StreamReader(fs);

            string pdfText = r.ReadToEnd();

            Regex regx = new Regex(@"/Type\s*/Page[^s]");

            MatchCollection matches = regx.Matches(pdfText);

            result = matches.Count;

            return result;

        }
    }
}
