using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFProject.Controls;


namespace WPFProject.Dialogs;

public partial class LogoDialog :  Window
{
    private LogoObject _logoObject;
    private int _x;
    private int _y;
    private int _width;
    private int _height;
    
    public LogoDialog(LogoObject logoObject)
    {
        _logoObject = logoObject;
        InitializeComponent();

        var xAndY = _logoObject.GetXAndY();
        PositionX.Text = xAndY[0];
        PositionY.Text = xAndY[1];
        
        Width.Text = _logoObject.LogoImage.Width.ToString();
        Height.Text = _logoObject.LogoImage.Height.ToString();
    }
    
    
    private void PositionX_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            string userInput = textBox.Text;
            int number;
            if (int.TryParse(userInput, out number))
            {
                _x = number;
            }
        }
    }
    
    private void PositionY_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            string userInput = textBox.Text;
            int number;
            if (int.TryParse(userInput, out number))
            {
                _y = number;
            }
        }
    }
    
    private void SetPosition(object sender, RoutedEventArgs e)
    {
        _logoObject.SetPosition(_x, _y);
    }
    
    private void Width_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            string userInput = textBox.Text;
            int number;
            if (int.TryParse(userInput, out number))
            {
                _width = number;
            }
        }
    }
    
    private void Height_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            string userInput = textBox.Text;
            int number;
            if (int.TryParse(userInput, out number))
            {
                _height = number;
            }
        }
    }
    
    private void SetSize(object sender, RoutedEventArgs e)
    {
        _logoObject.SetSize(_width, _height);
    }

    private void ChooseImage(object sender, RoutedEventArgs e)
    {
        var dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.DefaultExt = ".png";
        dlg.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp;*.gif;*.tiff)|*.png;*.jpeg;*.jpg;*.bmp;*.gif;*.tiff";

        var result = dlg.ShowDialog();

        if (result == true)
        {
            var filename = dlg.FileName;
            _logoObject.SetImage(filename);
        }
    }
}