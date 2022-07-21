using ClosedXML.Report;
using ExcelGenerator.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace ExcelGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var subtitulo = "POC ClosedXML.Report";

            var json = File.ReadAllText(@"..\..\..\Data\Paises.json");
            var data = JsonConvert.DeserializeObject<ModelData>(json);
            data.Subtitulo = subtitulo;

            using (var template = new XLTemplate(@"..\..\..\Templates\Paises_Template.xlsx"))
            {
                template.AddVariable(data);
                template.Generate();
                template.SaveAs(@"..\..\..\Output\Paises.xlsx");
            }
       
            //Show report
            Process.Start(new ProcessStartInfo(@"..\..\..\Output\Paises.xlsx") { UseShellExecute = true });

        }

        /// <summary>
        /// Retorno o array da bytes do excel.
        /// </summary>
        private static byte[] GetArrayBytesFromTamplate(XLTemplate template)
        {
            using (var ms = new MemoryStream())
            {
                template.Workbook.SaveAs(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return ms.ToArray();
            }
        }
    }
}
