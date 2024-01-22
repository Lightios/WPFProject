namespace WPFProject.Models;

public class TextParametersStorage
{
    public System.Windows.Media.FontFamily FontFamily { get; set; }
    public double FontSize { get; set; }
    public System.Windows.Media.Brush FontColor { get; set; }
    public string Text { get; set; }
    
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
}