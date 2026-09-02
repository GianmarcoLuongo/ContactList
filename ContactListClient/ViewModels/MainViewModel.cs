using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ContactListLib.Models;
using ContactListLib.Services;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
namespace ContactListClient.ViewModels;
public class MainViewModel
{
    // sez properties to bind to view
    

    public ObservableCollection<Contact> ContactList {get; set;}

    // sez services
    private  AddContactDialogService _addContactDialogService { get; set;}
    
    private ContactListService _ContactListService { get; set; }
    // sez commands
    public ICommand? AddContactCommand { get; set; }


    public void AddContactCommandHandler()
    {
        _addContactDialogService.AddContactDialogServiceSpawner(false, null, null);
    }



    public MainViewModel(
        AddContactDialogService addContactDialogService,
        ContactListService ContactListService
        )
    {   
        _addContactDialogService = addContactDialogService;
        _ContactListService = ContactListService;

        AddContactCommand = new RelayCommand(AddContactCommandHandler);
        //MessageBox.Show("Istance of MainViewModel created");

        
        ContactList = ContactListService.GetContactsService();


    }

}