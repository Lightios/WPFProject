using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFProject.Controls;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private RoomNumberObject roomNumberObject;
        private LogoObject logoObject;
        
        
        public MainWindow()
        {
            InitializeComponent();
            
            roomNumberObject = new RoomNumberObject();
            logoObject = new LogoObject();
            
            roomNumberObject.SetPosition(10, 20);
            logoObject.SetSize(100, 200);
        }
    }
}