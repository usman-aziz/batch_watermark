import java.io.File; 

import com.groupdocs.watermark.Color;
import com.groupdocs.watermark.Document;
import com.groupdocs.watermark.Font;
import com.groupdocs.watermark.FontStyle;
import com.groupdocs.watermark.HorizontalAlignment;
import com.groupdocs.watermark.License; 
import com.groupdocs.watermark.TextAlignment;
import com.groupdocs.watermark.TextWatermark;
import com.groupdocs.watermark.VerticalAlignment; 

public class Main {

	public static void main(String[] args) {
		// Uncomment following code in case you have product license
		/*License lic = new License();
		lic.setLicense("D:\\GroupDocs.Total.java.lic");*/

		// Get files in the Documents folder
		File folder = new File("./Documents/");
		File[] listOfFiles = folder.listFiles();
		
		// Iterate through the files
		for (int i = 0; i < listOfFiles.length; i++) {
			if (listOfFiles[i].isFile()) {
				Document doc = Document.load(listOfFiles[i].getPath());
				// Create watermark
				Font font = new Font("Calibre", 50, FontStyle.Bold | FontStyle.Italic);
				TextWatermark watermark = new TextWatermark("Protected", font);
				// Set watermark properties
				watermark.setForegroundColor(Color.getRed());
				watermark.setTextAlignment(TextAlignment.Right);
				watermark.setOpacity(0.5);
				watermark.setHorizontalAlignment(HorizontalAlignment.Center);
				watermark.setVerticalAlignment(VerticalAlignment.Center);
				watermark.setRotateAngle(-45);
				// Apply watermark to the document
				doc.addWatermark(watermark);
				// Save document
				doc.save("./Output/" + listOfFiles[i].getName());

				doc.close();
			}
		}

		System.out.println("Completed...");
	}

}
