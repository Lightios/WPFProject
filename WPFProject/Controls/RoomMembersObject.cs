using System.Windows.Controls;
using WPFProject.Interfaces;
using WPFProject.Models;

namespace WPFProject.Controls
{
    public partial class RoomMembersObject : IContentObject
    {
        public RoomMembersObject()
        {
            InitializeComponent();
            RoomMembersText.Text = "Jan Kowalski\nAdam Mickiewicz"; 
        }

        public string Serialize()
        {
            var textParametersStorage = new TextParametersStorage()
            {
                Text = RoomMembersText.Text,
                FontSize = RoomMembersText.FontSize,
                FontFamily = RoomMembersText.FontFamily,
                FontColor = RoomMembersText.Foreground,
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
            RoomMembersText.Text = textParametersStorage.Text;
            RoomMembersText.FontSize = textParametersStorage.FontSize;
            RoomMembersText.FontFamily = textParametersStorage.FontFamily;
            RoomMembersText.Foreground = textParametersStorage.FontColor;
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
        
        public string[] GetXAndY()
        {
            return new[]
            {
                Canvas.GetLeft(this).ToString(),
                Canvas.GetTop(this).ToString()
            };
        }

        public void SetSize(int width, int height)
        {
            RoomMembersText.Width = width;
            RoomMembersText.Height = height;
        }
    }
}