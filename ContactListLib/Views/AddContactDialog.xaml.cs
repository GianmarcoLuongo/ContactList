using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactListLib.ViewModels;

namespace ContactListLib.Views;

public partial class AddContactDialogWindow : Window
{
    public AddContactDialogWindow()
    {
        InitializeComponent();
        var addContactViewModel = new AddContactViewModel();
        DataContext = addContactViewModel;

        // subscribe for closing window
        addContactViewModel.RequestClose += () => this.Close();
    
    }

}