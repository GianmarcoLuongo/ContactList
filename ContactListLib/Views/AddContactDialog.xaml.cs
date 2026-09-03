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
using ContactListLib.Models;

namespace ContactListLib.Views;

public partial class AddContactDialogWindow : Window
{   
    private Contact? _selectedContact { get; set; }
    public AddContactDialogWindow(Contact? SelectedContact)
    {
        InitializeComponent();
        _selectedContact =  SelectedContact;
        var addContactViewModel = new AddContactViewModel(_selectedContact);
        DataContext = addContactViewModel;
        

        // subscribe for closing window
        addContactViewModel.RequestClose += () => 
        {
            this.Close();
        };
    
    }

}