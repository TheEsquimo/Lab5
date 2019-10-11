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
            editSelectedUserButton.Click += OnEditSelectedUserButtonClicked;
            removeSelectedUserButton.Click += OnRemoveSelectedUserButtonClicked;
            convertToAdminButton.Click += OnConvertToAdminButtonClicked;
            convertToNormalUserButton.Click += OnConvertToNormalUserButtonClicked;
            userNameTextBox.TextChanged += OnUserNameTextBoxTextChanged;
            userEmailTextBox.TextChanged += OnUserEmailTextBoxTextChanged;
            normalUserListBox.SelectionChanged += OnUserListBoxSelectionChanged;
            adminUserListBox.SelectionChanged += OnUserListBoxSelectionChanged;

        }

        private void OnUserEmailTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnUserNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnConvertToNormalUserButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnConvertToAdminButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnRemoveSelectedUserButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnEditSelectedUserButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnUserListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
