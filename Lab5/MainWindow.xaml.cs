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

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> userList = new List<User>();
        List<User> adminUserList = new List<User>();

        public MainWindow()
        {
            InitializeComponent();

            normalUserListBox.ItemsSource = userList;
            normalUserListBox.DisplayMemberPath = "Name";
            adminUserListBox.ItemsSource = adminUserList;
            adminUserListBox.DisplayMemberPath = "Name";

            createNewUserButton.Click += OnCreateNewUserButtonClicked;
        }

        private void OnCreateNewUserButtonClicked(object sender, RoutedEventArgs e)
        {
            string userName = userNameTextBox.Text;
            string userEmail = userEmailTextBox.Text;
            User newUser = new User(userName, userEmail);
            userList.Add(newUser);
            normalUserListBox.Items.Refresh();
        }
    }
}
