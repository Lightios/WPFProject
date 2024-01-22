using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPFProject.Interfaces;
using WPFProject.Models;

namespace WPFProject.Controls
{
    public partial class LogoObject : IContentObject
    {
        public LogoObject()
        {
            InitializeComponent();
            LogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/logo.png"));
        }

        public string Serialize()
        {
            var logoParametersStorage = new LogoParametersStorage()
            {
                X = Canvas.GetLeft(this),
                Y = Canvas.GetTop(this),
                Width = LogoImage.Width,
                Height = LogoImage.Height,
                Path = LogoImage.Source.ToString()
            };
            
            return Newtonsoft.Json.JsonConvert.SerializeObject(logoParametersStorage);
        }

        public void Deserialize(string json)
        {
            var logoParametersStorage = Newtonsoft.Json.JsonConvert.DeserializeObject<LogoParametersStorage>(json);
            Canvas.SetLeft(this, logoParametersStorage.X);
            Canvas.SetTop(this, logoParametersStorage.Y);
            Width = logoParametersStorage.Width;
            Height = logoParametersStorage.Height;
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
            LogoImage.Width = width;
            LogoImage.Height = height;

            Width = width;
            Height = height;
        }

        public void SetImage(string filename)
        {
            LogoImage.Source = new BitmapImage(new Uri(filename));
        }
    }

}