using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<User> normalUserList = new List<User>();
        List<User> adminUserList = new List<User>();

        public MainWindow()
        {
            InitializeComponent();

            normalUserListBox.ItemsSource = normalUserList;
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
            normalUserListBox.SelectionChanged += OnNormalUserListBoxSelectionChanged;
            adminUserListBox.SelectionChanged += OnAdminUserListBoxSelectionChanged;
        }


        private void OnUserEmailTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnUserNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = userEmailTextBox.Text;
            Match nonWhitespaceExists = Regex.Match(currentText, @"[a-z]");
            if (nonWhitespaceExists.Success) { createNewUserButton.IsEnabled = true; }
            else { createNewUserButton.IsEnabled = false; }
        }

        private void OnConvertToNormalUserButtonClicked(object sender, RoutedEventArgs e)
        {
            if (adminUserListBox.SelectedItem != null)
            {
                User userToTransfer = (User)adminUserListBox.SelectedItem;
                TransferUserToList(userToTransfer, adminUserList, normalUserList);
            }
        }

        private void OnConvertToAdminButtonClicked(object sender, RoutedEventArgs e)
        {
            if (normalUserListBox.SelectedItem != null)
            {
                User userToTransfer = (User)normalUserListBox.SelectedItem;
                TransferUserToList(userToTransfer, normalUserList, adminUserList);
            }
        }

        private void OnRemoveSelectedUserButtonClicked(object sender, RoutedEventArgs e)
        {
            if (normalUserListBox.SelectedItem != null)
            {
                User userToRemove = (User)normalUserListBox.SelectedItem;
                normalUserList.Remove(userToRemove);
                normalUserListBox.Items.Refresh();
            }
            else if (adminUserListBox.SelectedItem != null)
            {
                User userToRemove = (User)adminUserListBox.SelectedItem;
                adminUserList.Remove(userToRemove);
                adminUserListBox.Items.Refresh();
            }
        }

        private void OnEditSelectedUserButtonClicked(object sender, RoutedEventArgs e)
        {
            User userToEdit = null;
            if (normalUserListBox.SelectedItem != null) { userToEdit = (User)normalUserListBox.SelectedItem; }
            else if (adminUserListBox.SelectedItem != null) { userToEdit = (User)adminUserListBox.SelectedItem; }
            if (userToEdit != null)
            {
                userToEdit.Name = userNameTextBox.Text;
                userToEdit.Email = userEmailTextBox.Text;
                normalUserListBox.Items.Refresh();
                adminUserListBox.Items.Refresh();
            }
        }

        private void OnNormalUserListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User userToEdit = null;
            if (normalUserListBox.SelectedItem != null)
            {
                userToEdit = (User)normalUserListBox.SelectedItem;
                displaySelectedUserNameLabel.Content = userToEdit.Name;
                displaySelectedUserEmailLabel.Content = userToEdit.Email;
                adminUserListBox.SelectedItem = null;
            }
        }
        private void OnAdminUserListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User userToEdit = null;
            if (adminUserListBox.SelectedItem != null)
            {
                userToEdit = (User)adminUserListBox.SelectedItem;
                displaySelectedUserNameLabel.Content = userToEdit.Name;
                displaySelectedUserEmailLabel.Content = userToEdit.Email;
                normalUserListBox.SelectedItem = null;
            }
        }

        private void OnCreateNewUserButtonClicked(object sender, RoutedEventArgs e)
        {
            string userName = userNameTextBox.Text;
            string userEmail = userEmailTextBox.Text;
            User newUser = new User(userName, userEmail);
            normalUserList.Add(newUser);
            normalUserListBox.Items.Refresh();
        }

        private void TransferUserToList(User objectToTransfer, List<User> fromList, List<User> toList)
        {
            toList.Add(objectToTransfer);
            fromList.Remove(objectToTransfer);
            normalUserListBox.Items.Refresh();
            adminUserListBox.Items.Refresh();
        }
    }
}
