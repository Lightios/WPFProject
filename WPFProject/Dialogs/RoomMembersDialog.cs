using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFProject.Controls;


namespace WPFProject.Dialogs;

public partial class RoomMembersDialog :  Window
{
    private RoomMembersObject roomMembersObject;
    private int _x;
    private int _y;
    private int _width;
    private int _height;
    
    public RoomMembersDialog(RoomMembersObject roomMembersObject)
    {
        this.roomMembersObject = roomMembersObject;
        InitializeComponent();
        FontSizeTextBox.Text = roomMembersObject.FontSize.ToString();

        var xAndY = this.roomMembersObject.GetXAndY();
        PositionX.Text = xAndY[0];
        PositionY.Text = xAndY[1];
        
        Width.Text = roomMembersObject.Width.ToString();
        Height.Text = roomMembersObject.Height.ToString();
    }
    
    private void ChangeFontSize(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            if (button.Tag.ToString() == "Increase")
            {
                roomMembersObject.RoomMembersText.FontSize += 1;
            }
            else if (button.Tag.ToString() == "Decrease" && roomMembersObject.FontSize > 1)
            {
                roomMembersObject.RoomMembersText.FontSize -= 1;
            }
            FontSizeTextBox.Text = roomMembersObject.RoomMembersText.FontSize.ToString();
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
        selectedFont = selectedFont.Substring(selectedFont.IndexOf(": ") + 2); // cut Sytem.Windows.Media.FontFamily...
        roomMembersObject.FontFamily = new FontFamily(selectedFont);
    }
    
    private void FontColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        var colorPicker = sender as Xceed.Wpf.Toolkit.ColorPicker;
        if (colorPicker != null && colorPicker.SelectedColor.HasValue)
        {
            var selectedColor = colorPicker.SelectedColor.Value;
            roomMembersObject.RoomMembersText.Foreground = new SolidColorBrush(selectedColor);
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
        roomMembersObject.SetPosition(_x, _y);
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
        roomMembersObject.SetSize(_width, _height);
    }
}