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

namespace Password_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static bool addUpperCase;
        private static bool addNumbers;
        private static bool addSymbols;
        private static string validChars;

        #region Conditions
        static string generatePassword(int length)
        {
            // Check what checkboxes are ticked
            if (addUpperCase && addNumbers && addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890?!@#$%^&*";
            }
            else if (addUpperCase && addNumbers)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            }
            else if (addUpperCase && addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ?!@#$%^&*";
            }
            else if (addNumbers && addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyz1234567890?!@#$%^&*";
            }
            else if (addUpperCase)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            else if (addNumbers)
            {
                validChars = "abcdefghijklmnopqrstuvwxyz1234567890";
            }
            else if (addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyz?!@#$%^&*";
            }
            else
            {
                validChars = "abcdefghijklmnopqrstuvwxyz";
            }

            // Generate password
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(validChars[rnd.Next(validChars.Length)]);
            }
            return res.ToString();
        }
        #endregion

        #region Generate
        // Generate password once button is clicked
        private void btnGeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Password length
                int length = Convert.ToInt32(comboBox.Text);

                // Generate password
                string pass = generatePassword(length);

                // Show password in application
                password.Content = pass;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a password length.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Events
        // Check whether the checkbox for upper case characters is selected
        public void uppercaseCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addUpperCase = true;
        }
        private void uppercaseCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addUpperCase = false;
        }

        // Check whether the checkbox for numbers is selected
        private void numbersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addNumbers = true;
        }
        private void numbersCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addNumbers = false;
        }

        // Check whether the checkbox for symbols is selected
        private void symbolsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addSymbols = true;
        }
        private void symbolsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addSymbols = false;
        }
        #endregion
    }
}
