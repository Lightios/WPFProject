using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFProject.Controls;


namespace WPFProject.Dialogs;

public partial class RoomNumberDialog :  Window
{
    private RoomNumberObject roomNumberObject;
    private int _x;
    private int _y;
    private int _width;
    private int _height;
    
    public RoomNumberDialog(RoomNumberObject roomNumberObject)
    {
        this.roomNumberObject = roomNumberObject;
        InitializeComponent();
        FontSizeTextBox.Text = roomNumberObject.FontSize.ToString();

        var xAndY = roomNumberObject.GetXAndY();
        PositionX.Text = xAndY[0];
        PositionY.Text = xAndY[1];
        
        Width.Text = roomNumberObject.Width.ToString();
        Height.Text = roomNumberObject.Height.ToString();
    }
    
    private void ChangeFontSize(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            if (button.Tag.ToString() == "Increase")
            {
                roomNumberObject.FontSize += 1;
            }
            else if (button.Tag.ToString() == "Decrease" && roomNumberObject.FontSize > 1)
            {
                roomNumberObject.FontSize -= 1;
            }
            FontSizeTextBox.Text = roomNumberObject.FontSize.ToString();
        }
    }
    
    private void FontComboBox_Loaded(object sender, RoutedEventArgs e)
    {
        FontComboBox.Items.Clear();
        foreach (var fontFamily in Fonts.SystemFontFamilies)
        {
            FontComboBox.Items.Add(new ComboBoxItem() { Content = fontFamily.Source });
        }
    }

    private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        var selectedFont = comboBox?.SelectedItem.ToString();
        selectedFont = selectedFont.Substring(selectedFont.IndexOf(": ") + 2);
        roomNumberObject.RoomNumberText.FontFamily = new FontFamily(selectedFont);
    }
    
    private void FontColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        var colorPicker = sender as Xceed.Wpf.Toolkit.ColorPicker;
        if (colorPicker != null && colorPicker.SelectedColor.HasValue)
        {
            var selectedColor = colorPicker.SelectedColor.Value;
            roomNumberObject.RoomNumberText.Foreground = new SolidColorBrush(selectedColor);
        }
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
        roomNumberObject.SetPosition(_x, _y);
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
        roomNumberObject.SetSize(_width, _height);
    }
}