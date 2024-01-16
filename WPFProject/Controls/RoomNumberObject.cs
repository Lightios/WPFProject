using System.Windows.Controls;
using WPFProject.Interfaces;

namespace WPFProject.Controls
{
    public partial class RoomNumberObject : UserControl, IContentObject
    {
        public RoomNumberObject()
        {
            InitializeComponent();
            RoomNumberText.Text = "Default Text"; // Set the default text
        }

        public void Serialize()
        {
            // Implementacja metody Serialize
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