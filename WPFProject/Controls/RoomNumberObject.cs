using System;
using System.Collections.Generic;
using System.Windows.Controls;
using WPFProject.Interfaces;
using WPFProject.Models;

namespace WPFProject.Controls
{
    public partial class RoomNumberObject : IContentObject
    {
        public RoomNumberObject()
        {
            InitializeComponent();
            RoomNumberText.Text = "0000";
        }

        public string Serialize()
        {
			var textParametersStorage = new TextParametersStorage() {
				Text = RoomNumberText.Text,
				FontSize = RoomNumberText.FontSize,
				FontFamily = RoomNumberText.FontFamily,
				FontColor = RoomNumberText.Foreground,
				X = Canvas.GetLeft(this),
				Y = Canvas.GetTop(this),
				Width = Width,
				Height = Height
			};

			return Newtonsoft.Json.JsonConvert.SerializeObject(textParametersStorage);
		}
        
        public void Deserialize(string json)
        {
			var textParametersStorage = Newtonsoft.Json.JsonConvert.DeserializeObject<TextParametersStorage>(json);
			RoomNumberText.Text = textParametersStorage.Text;
			RoomNumberText.FontSize = textParametersStorage.FontSize;
			RoomNumberText.FontFamily = textParametersStorage.FontFamily;
			RoomNumberText.Foreground = textParametersStorage.FontColor;
			Canvas.SetLeft(this, textParametersStorage.X);
			Canvas.SetTop(this, textParametersStorage.Y);
			Width = textParametersStorage.Width;
			Height = textParametersStorage.Height;
		}
        
        public void SetPosition(int x, int y)
		{
			Canvas.SetLeft(this, x);
			Canvas.SetTop(this, y);
		}
        
        
		public void SetSize(int width, int height)
		{
			RoomNumberText.Width = width;
			RoomNumberText.Height = height;
		}
        
        public string[] GetXAndY()
        {
	        return new[]
	        {
		        Canvas.GetLeft(this).ToString(),
		        Canvas.GetTop(this).ToString()
	        };
        }
    }
}