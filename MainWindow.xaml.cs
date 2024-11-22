using System;
using System.Windows;
using static ATMApplication.ATMApplication;

namespace ATMApp
{
    public partial class Login : Window
    {
        private BankAccount account;

        public Login()
        {
            InitializeComponent();

            // Sample account for testing purposes
            account = new BankAccount(101, "Curly Smith", 100.00, "123");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int accountNumber = int.Parse(AccountNumberTextBox.Text);
                string password = PasswordBox.Password;

                if (account.VerifyCredentials(accountNumber, password))
                {
                    StatementTextBlock.Text = "Login successful!";
                    StatementTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Invalid account number or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                {
                    MessageBox.Show("Please login first.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter deposit amount:", "Deposit", "0");
                if (double.TryParse(input, out double amount))
                {
                    account.Deposit(amount);
                    StatementTextBlock.Text = $"Deposit successful!\nNew Balance: ${account.Balance:F2}";
                }
                else
                {
                    MessageBox.Show("Invalid amount entered.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                {
                    MessageBox.Show("Please login first.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Placeholder for the withdrawal logic
                // You can add withdrawal logic here once it's implemented.

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

