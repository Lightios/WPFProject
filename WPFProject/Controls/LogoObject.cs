using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPFProject.Interfaces;

namespace WPFProject.Controls
{
    public partial class LogoObject : UserControl, IContentObject
    {
        public LogoObject()
        {
            InitializeComponent();
            LogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/logo.png"));
        }

        public void Serialize()
        {
            // Implementacja metody Serialize
        }

        public void Deserialize()
        {
            // Implementacja metody Deserialize
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