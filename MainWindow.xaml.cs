using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Secure_Password_Storage.Logic;
using Secure_Password_Storage.Models;

namespace Secure_Password_Storage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManagerController mCon;

        public MainWindow()
        {
            InitializeComponent();

            //inits the ManagerController
            mCon = new ManagerController();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Checks Radio buttons 
            if ((bool)CURadio.IsChecked)
            {
                //Calls the function to create test accounts
                mCon.CreateTestAccounts();
            }
            else if ((bool)LoginRadio.IsChecked)
            {
                //Verify the login
                if (mCon.VerifyLogin(UserNameField.Text, PasswordField.Password))
                {
                    //if account success login
                    MessageBox.Show("Success");
                }
                else
                {
                    //else show error messageBox
                    MessageBox.Show("Error Wrong Username / Password");
                }

            }
            else
            {
                MessageBox.Show("Please Choose an option.");
            }

        }

        private void CURadio_Checked(object sender, RoutedEventArgs e)
        {
            LoginButton.Content = "Create Users";
        }

        private void LoginRadio_Checked(object sender, RoutedEventArgs e)
        {
            LoginButton.Content = "Login";
        }
    }
}
