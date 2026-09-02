using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ContactListLib.Models;
using ContactListLib.Services;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.Cryptography.X509Certificates;
namespace ContactListClient.ViewModels;
public class MainViewModel
{
    // sez properties to bind to view
    
    public  Contact? SelectedContact { get; set; } = new Contact(null,null,0);
    public ObservableCollection<Contact> ContactList {get; set;}

    // sez commands
    public ICommand? AddContactCommand { get; set; }

    public void AddContactCommandHandler()
    {
        AddContactDialogService.AddContactDialogServiceSpawner(true, SelectedContact?.Name, SelectedContact?.Surname);
        SelectedContact = null;
    }



    public MainViewModel()
    {   

        AddContactCommand = new RelayCommand(AddContactCommandHandler);
        //MessageBox.Show("Istance of MainViewModel created");

        ContactList = ContactListService.ContactList;        
    }

}