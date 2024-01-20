using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFProject.Controls;


namespace WPFProject.Dialogs;

public partial class RoomNumberDialog :  Window
{
    private RoomNumberObject roomNumberObject;
    
    public RoomNumberDialog(RoomNumberObject roomNumberObject)
    {
        this.roomNumberObject = roomNumberObject;
        InitializeComponent();
        FontSizeTextBox.Text = roomNumberObject.FontSize.ToString();
        // FontSizeSlider.Value = currentFontSize;
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
        roomNumberObject.RoomNumberText.FontFamily = new FontFamily(selectedFont);
        Console.WriteLine(selectedFont);
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
}