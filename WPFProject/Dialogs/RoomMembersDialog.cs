using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFProject.Controls;


namespace WPFProject.Dialogs;

public partial class RoomMembersDialog :  Window
{
    private RoomMembersObject roomMembersObject;
    
    public RoomMembersDialog(RoomMembersObject roomMembersObject)
    {
        this.roomMembersObject = roomMembersObject;
        InitializeComponent();
        FontSizeTextBox.Text = roomMembersObject.FontSize.ToString();
        // FontSizeSlider.Value = currentFontSize;
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
        roomMembersObject.RoomMembersText.FontFamily = new FontFamily(selectedFont);
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
}