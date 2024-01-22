
using System;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WPFProject.Dialogs;
using WPFProject.Models;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DoorTag doorTag = new DoorTag();
        
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = doorTag;
            doorTag.AddContentObject(LogoObject);
            doorTag.AddContentObject(RoomMembersObject);
            doorTag.AddContentObject(RoomNumberObject);
        }
        
        private void Save(object sender, RoutedEventArgs e)
        {
	        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
	        dlg.FileName = "Tabliczka"; 
	        dlg.DefaultExt = ".json";
	        dlg.Filter = "JSON documents (.json)|*.json";

	        Nullable<bool> result = dlg.ShowDialog();

	        if (result == true)
	        {
		        string filename = dlg.FileName;
		        doorTag.Serialize(filename);
	        }
        }
        
        private void Load(object sender, RoutedEventArgs e)
        {
	        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
	        dlg.DefaultExt = ".json";
	        dlg.Filter = "JSON documents (.json)|*.json";

	        Nullable<bool> result = dlg.ShowDialog();

	        if (result == true)
	        {
		        string filename = dlg.FileName;
		        doorTag.Deserialize(filename);
	        }
        }
        
        // Zapisz plik
        
        private void EditRoomNumber(object sender, RoutedEventArgs e)
        {
            var dialog = new RoomNumberDialog(RoomNumberObject);
            dialog.ShowDialog();
        }
        
        private void EditRoomMembers(object sender, RoutedEventArgs e)
        {
            var dialog = new RoomMembersDialog(RoomMembersObject);
            dialog.ShowDialog();
        }
        
        private void EditLogo(object sender, RoutedEventArgs e)
		{
			var dialog = new LogoDialog(LogoObject);
			dialog.ShowDialog();
		}

		private void RoomNumberObject_Loaded(object sender, RoutedEventArgs e) {

		}

		// private void Print(object sender, RoutedEventArgs e) {
   //          System.Windows.Documents.FlowDocument document = Document1;
			// // Clone the source document's content into a new FlowDocument.
			// // This is because the pagination for the printer needs to be
			// // done differently than the pagination for the displayed page.
			// // We print the copy, rather that the original FlowDocument.
			// System.IO.MemoryStream s = new System.IO.MemoryStream();
			// TextRange source = new TextRange(document.ContentStart, document.ContentEnd);
			// source.Save(s, DataFormats.Xaml);
			// FlowDocument copy = new FlowDocument();
			// TextRange dest = new TextRange(copy.ContentStart, copy.ContentEnd);
			// dest.Load(s, DataFormats.Xaml);
   //
			// // Create a XpsDocumentWriter object, implicitly opening a Windows common print dialog,
			// // and allowing the user to select a printer.
   //
			// // get information about the dimensions of the seleted printer+media.
			// System.Printing.PrintDocumentImageableArea ia = null;
			// System.Windows.Xps.XpsDocumentWriter docWriter = System.Printing.PrintQueue.CreateXpsDocumentWriter(ref ia);
   //
			// if (docWriter != null && ia != null) {
			// 	DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;
   //
			// 	// Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
			// 	paginator.PageSize = new Size(ia.MediaSizeWidth, ia.MediaSizeHeight);
			// 	Thickness t = new Thickness(72);  // copy.PagePadding;
			// 	copy.PagePadding = new Thickness(
			// 					 Math.Max(ia.OriginWidth, t.Left),
			// 					   Math.Max(ia.OriginHeight, t.Top),
			// 					   Math.Max(ia.MediaSizeWidth - (ia.OriginWidth + ia.ExtentWidth), t.Right),
			// 					   Math.Max(ia.MediaSizeHeight - (ia.OriginHeight + ia.ExtentHeight), t.Bottom));
   //
			// 	copy.ColumnWidth = double.PositiveInfinity;
			// 	//copy.PageWidth = 528; // allow the page to be the natural with of the output device
   //
			// 	// Send content to the printer.
			// 	docWriter.Write(paginator);
			// }

		// }
		private void Print(object sender, RoutedEventArgs e)
		{
			PrintDialog prnt = new PrintDialog();
			if (prnt.ShowDialog() == true)
			{
				Size pageSize = new Size(prnt.PrintableAreaWidth, prnt.PrintableAreaHeight);
				Document1.Measure(pageSize);
				Document1.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));

				if (prnt.ShowDialog() == true)
				{
					prnt.PrintVisual(Document1, "Printing Canvas");
				}
			}
			this.Close();
		}
	}
}