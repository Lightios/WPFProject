using System.Windows.Controls;
using WPFProject.Interfaces;
using WPFProject.Models;

namespace WPFProject.Controls
{
    public partial class RoomNumberObject : UserControl, IContentObject
    {
        public RoomNumberObject()
        {
            InitializeComponent();
            RoomNumberText.Text = "0000"; // Set the default text

        }

        public void Serialize()
        {
			var textParametersStorage = new TextParametersStorage() {
				Text = RoomNumberText.Text,
				FontSize = RoomNumberText.FontSize,
				FontFamily = RoomNumberText.FontFamily,
				FontColor = RoomNumberText.Foreground
			};

			var json = Newtonsoft.Json.JsonConvert.SerializeObject(textParametersStorage);
			System.IO.File.WriteAllText(@"RoomNumberObject.json", json);
		}
        
        public void Deserialize()
        {
			var json = System.IO.File.ReadAllText(@"RoomNumberObject.json");
			var textParametersStorage = Newtonsoft.Json.JsonConvert.DeserializeObject<TextParametersStorage>(json);
			RoomNumberText.Text = textParametersStorage.Text;
			RoomNumberText.FontSize = textParametersStorage.FontSize;
			RoomNumberText.FontFamily = textParametersStorage.FontFamily;
			RoomNumberText.Foreground = textParametersStorage.FontColor;
		}

        public void SetPosition(int x, int y)
        {
            // Implementacja metody SetPosition
        }

        public void SetSize(int x, int y)
        {
            // Implementacja metody SetSize
        }
    }
}