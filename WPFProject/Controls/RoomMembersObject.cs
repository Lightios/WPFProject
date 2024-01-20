using System.Windows.Controls;
using WPFProject.Interfaces;
using WPFProject.Models;

namespace WPFProject.Controls
{
    public partial class RoomMembersObject : UserControl, IContentObject
    {
        public RoomMembersObject()
        {
            InitializeComponent();
            RoomMembersText.Text = "Jan Kowalski\nAdam Mickiewicz"; 
        }

        public void Serialize()
        {
            var textParametersStorage = new TextParametersStorage()
            {
                Text = RoomMembersText.Text,
                FontSize = RoomMembersText.FontSize,
                FontFamily = RoomMembersText.FontFamily,
                FontColor = RoomMembersText.Foreground
            };
            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(textParametersStorage);
            System.IO.File.WriteAllText(@"RoomMembersObject.json", json);
        }

        public void Deserialize()
        {
            var json = System.IO.File.ReadAllText(@"RoomMembersObject.json");
            var textParametersStorage = Newtonsoft.Json.JsonConvert.DeserializeObject<TextParametersStorage>(json);
            RoomMembersText.Text = textParametersStorage.Text;
            RoomMembersText.FontSize = textParametersStorage.FontSize;
            RoomMembersText.FontFamily = textParametersStorage.FontFamily;
            RoomMembersText.Foreground = textParametersStorage.FontColor;
        }
        
        public void SetPosition(int x, int y)
        {
            
        }

        public void SetSize(int width, int height)
        {
            RoomMembersText.Width = width;
            RoomMembersText.Height = height;
        }
    }
}