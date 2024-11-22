using System.Windows;
using ATMApp;
using static ATMApplication.ATMApplication;

public partial class Login : Window
{
    private BankAccount account;
    private readonly object StatementTextBlock;

    public Login(BankAccount account, object statementTextBlock)
    {
        object value = InitializeComponent();
        this.account = account;
        StatementTextBlock = account.GetStatement();
        StatementTextBlock = statementTextBlock;
    }

    private object InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void DepositButton_Click(object sender, RoutedEventArgs e)
    {
        // Implement deposit logic
    }

    private void WithdrawButton_Click(object sender, RoutedEventArgs e)
    {
        // Implement withdraw logic
    }

    private void TransactionsButton_Click(object sender, RoutedEventArgs e)
    {
        // Implement transaction history display
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
