using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ContactListLib.Models;
using ContactListLib.Services;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
namespace ContactListClient.ViewModels;
public partial class MainViewModel : ObservableObject
{
    // sez properties to bind to view
    [ObservableProperty]
    private  KeyValuePair<string,Contact> _contactDictEntry;
    public ObservableCollection<KeyValuePair<string,Contact>> ContactListDictionary {get; set;}
    private DataGrid _contactListGrid {get; set; }

    // sez commands
    public ICommand? AddContactCommand { get; set; }


    public void AddContactCommandHandler()
    {
        
        //AddContactDialogService.AddContactDialogServiceSpawner(true, SelectedContact?.Name, SelectedContact?.Surname);
        // passo il contatto selezionato direttamente
        //AddContactDialogService.AddContactDialogServiceSpawner(true,_contactDictEntry.Value);
        AddContactDialogService.AddContactDialogServiceSpawner(true,_contactDictEntry.Value.Name,_contactDictEntry.Value.Surname);


    }

    public void SelectedItemResetSubscriber()
    {
        _contactDictEntry = new KeyValuePair<string,Contact>("",new Contact(null,null,0));
    }


    public MainViewModel(DataGrid ContactListGrid)
    {   

        _contactListGrid = ContactListGrid;
        _contactDictEntry = new KeyValuePair<string,Contact>("",new Contact(null,null,0));
        AddContactCommand = new RelayCommand(AddContactCommandHandler);
        ContactListDictionary = ContactListService.ContactListDictionary; 
        AddContactDialogService.SelectedItemReset += SelectedItemResetSubscriber; 

    }

}