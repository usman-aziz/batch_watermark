using GroupDocs.Watermark;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Watermark
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Note: Uncomment the following code in case you have product license.
             */
            //ApplyLicense();

            // Apply watermark
            ApplyWatermark();

            Console.ReadKey();
        }

        private static void ApplyWatermark()
        {
            DirectoryInfo dir = new DirectoryInfo(@"../../Documents/");
            FileInfo[] files = dir.GetFiles();
            // Iterate through the files
            foreach (FileInfo file in files)
            {
                // Load document
                using (Document doc = Document.Load(file.FullName))
                {
                    // Initialize the font to be used for watermark
                    Font font = new Font("Calibre", 50, FontStyle.Bold | FontStyle.Italic);
                    // Create watermark
                    TextWatermark watermark = new TextWatermark("Protected", font);
                    // Set watermark properties
                    watermark.ForegroundColor = Color.Red; 
                    watermark.TextAlignment = TextAlignment.Right;
                    watermark.Opacity = 0.5;
                    watermark.HorizontalAlignment = HorizontalAlignment.Center;
                    watermark.VerticalAlignment = VerticalAlignment.Center;
                    watermark.RotateAngle = -45;
                    // Apply watermark
                    doc.AddWatermark(watermark);
                    // Save document
                    doc.Save(Path.Combine("../../Output",file.Name));
                    Console.WriteLine("Processed: "+ file.Name);
                }
            }

            Console.WriteLine("Documents have been saved to output directory...");
        }

        private static void ApplyLicense()
        {
            License lic = new License();
            lic.SetLicense("D:\\GroupDocs.Total.Net.lic");
            
        }
    }
}
