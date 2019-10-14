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
        bool userCreationNameAccepted = false;
        bool userCreationEmailAccepted = false;

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
            string currentText = userEmailTextBox.Text;
            if (EmailRequirementSuccesful(currentText))
            {
                userCreationEmailAccepted = true;
                if (userCreationNameAccepted)
                {
                    createNewUserButton.IsEnabled = true;
                    if (normalUserListBox.SelectedItem != null || adminUserListBox.SelectedItem != null)
                    {
                        editSelectedUserButton.IsEnabled = true;
                    }
                }
            }
            else
            {
                userCreationEmailAccepted = false;
                createNewUserButton.IsEnabled = false;
                editSelectedUserButton.IsEnabled = false;
            }
        }

        private void OnUserNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = userNameTextBox.Text;
            if (UserNameRequirementSuccesfull(currentText))
            {
                userCreationNameAccepted = true;
                if (userCreationEmailAccepted)
                {
                    createNewUserButton.IsEnabled = true;
                    if (normalUserListBox.SelectedItem != null || adminUserListBox.SelectedItem != null)
                    {
                        editSelectedUserButton.IsEnabled = true;
                    }
                }
            }
            else
            {
                userCreationNameAccepted = false;
                createNewUserButton.IsEnabled = false;
                editSelectedUserButton.IsEnabled = false;
            }
        }

        private void OnConvertToNormalUserButtonClicked(object sender, RoutedEventArgs e)
        {
            if (adminUserListBox.SelectedItem != null)
            {
                User userToTransfer = (User)adminUserListBox.SelectedItem;
                TransferUserToList(userToTransfer, adminUserList, normalUserList);
                convertToNormalUserButton.IsEnabled = false;
            }
        }

        private void OnConvertToAdminButtonClicked(object sender, RoutedEventArgs e)
        {
            if (normalUserListBox.SelectedItem != null)
            {
                User userToTransfer = (User)normalUserListBox.SelectedItem;
                TransferUserToList(userToTransfer, normalUserList, adminUserList);
                convertToAdminButton.IsEnabled = false;
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
            ClearDisplayInfoLabels();
            DeselectUser();
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
                ClearDisplayInfoLabels();
                ClearTextBoxes();
                normalUserListBox.Items.Refresh();
                adminUserListBox.Items.Refresh();
                DeselectUser();
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
                convertToAdminButton.IsEnabled = true;
                convertToNormalUserButton.IsEnabled = false;
                removeSelectedUserButton.IsEnabled = true;
            }
            else
            {
                editSelectedUserButton.IsEnabled = false;
                removeSelectedUserButton.IsEnabled = false;
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
                convertToNormalUserButton.IsEnabled = true;
                convertToAdminButton.IsEnabled = false;
                removeSelectedUserButton.IsEnabled = true;
            }
            else
            {
                editSelectedUserButton.IsEnabled = false;
                removeSelectedUserButton.IsEnabled = false;
            }
        }

        private void OnCreateNewUserButtonClicked(object sender, RoutedEventArgs e)
        {
            string userName = userNameTextBox.Text;
            string userEmail = userEmailTextBox.Text;
            User newUser = new User(userName, userEmail);
            normalUserList.Add(newUser);
            ClearTextBoxes();
            normalUserListBox.Items.Refresh();
            DeselectUser();
            ClearDisplayInfoLabels();
        }

        private void DeselectUser()
        {
            normalUserListBox.SelectedItem = null;
            adminUserListBox.SelectedItem = null;
            convertToAdminButton.IsEnabled = false;
            convertToNormalUserButton.IsEnabled = false;
        }

        private void TransferUserToList(User userToTransfer, List<User> fromList, List<User> toList)
        {
            toList.Add(userToTransfer);
            fromList.Remove(userToTransfer);
            ClearDisplayInfoLabels();
            normalUserListBox.Items.Refresh();
            adminUserListBox.Items.Refresh();
        }

        private void ClearTextBoxes()
        {
            userNameTextBox.Clear();
            userEmailTextBox.Clear();
        }

        private void ClearDisplayInfoLabels()
        {
            displaySelectedUserNameLabel.Content = null;
            displaySelectedUserEmailLabel.Content = null;
        }

        private bool UserNameRequirementSuccesfull(string currentText)
        {
            Match nonWhitespaceExists = Regex.Match(currentText, @"\S");
            return nonWhitespaceExists.Success;
        }

        private bool EmailRequirementSuccesful(string currentText)
        {
            Match emailRequirement = Regex.Match(currentText, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
            + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            return emailRequirement.Success;
        }
    }
}
