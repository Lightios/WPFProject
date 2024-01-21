
using System.Windows;
using WPFProject.Dialogs;
using WPFProject.Models;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DoorTag doorTag = new DoorTag();
        
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = doorTag;
            doorTag.AddContentObject(LogoObject);
            doorTag.AddContentObject(RoomMembersObject);
            doorTag.AddContentObject(RoomNumberObject);
        }
        
        private void Save(object sender, RoutedEventArgs e)
        {
            doorTag.Serialize();
        }
        
        private void Load(object sender, RoutedEventArgs e)
        {
            doorTag.Deserialize();
        }
        
        private void Print(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void EditRoomNumber(object sender, RoutedEventArgs e)
        {
            var dialog = new RoomNumberDialog(RoomNumberObject);
            dialog.ShowDialog();
        }
        
        private void EditRoomMembers(object sender, RoutedEventArgs e)
        {
            var dialog = new RoomMembersDialog(RoomMembersObject);
            dialog.ShowDialog();
        }

		private void RoomNumberObject_Loaded(object sender, RoutedEventArgs e) {

		}
	}
}