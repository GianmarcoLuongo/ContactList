using System.Text;
using System.Windows;
using System.ComponentModel;
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
using ContactListLib.Services;

namespace ContactListLib.Views;

public partial class AddContactDialogWindow : Window
{   
    private Contact? _selectedDialogContact { get; set; }
    public AddContactDialogWindow(Contact? SelectedContact)
    {   

        InitializeComponent();
        _selectedDialogContact =  SelectedContact;
        var addContactViewModel = new AddContactViewModel(_selectedDialogContact);
        DataContext = addContactViewModel;
        

        // subscribe for closing window
        addContactViewModel.RequestClose += () => 
        {
            AddContactDialogService.SelectedItemResetHandler();
            this.Close();
            //_selectedDialogContact = null;
            
        };
    
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        AddContactDialogService.SelectedItemResetHandler();
    }
}