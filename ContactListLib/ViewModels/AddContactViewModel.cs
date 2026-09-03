using System;
using System.Collections.ObjectModel;
using System.Windows;
using ContactListLib.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ContactListLib.Services;
using CommunityToolkit.Mvvm.ComponentModel;
namespace ContactListLib.ViewModels;

public class AddContactViewModel 
{   
    
    private Contact? _selectedViewModelContact { get; set; } = null;
    public Action RequestClose;
    public string? Name { get; set; }
    public string? Surname {get; set;}
    public int Telephone { get; set; }
    
    // sez. Commands
    public ICommand SaveContactCommand { get; set;}


public void SaveContactCommandHandler()
{
    if (_selectedViewModelContact == null)
    {
        bool exists = false;

        foreach (Contact contact in BlackBoard.ContactList)
        {
            if (contact.Name == Name &&
                contact.Surname == Surname)
            {
                contact.Telephone = Telephone;
                exists = true;
                AddContactDialogService.SelectedItemResetHandler();
                RequestClose?.Invoke();
                //_selectedViewModelContact = null;
                break;
            }
        }

        if (!exists)
        {
            BlackBoard.ContactList.Add(
                new Contact(Name, Surname, Telephone));
            //AddContactDialogService._selectedContact = null;
            AddContactDialogService.SelectedItemResetHandler();
            RequestClose?.Invoke();
            
        }
    }
    else
    {
        _selectedViewModelContact.Name = Name;
        _selectedViewModelContact.Surname = Surname;
        _selectedViewModelContact.Telephone = Telephone;
        AddContactDialogService.SelectedItemResetHandler();
        RequestClose?.Invoke();
        
    }
}
    public AddContactViewModel(Contact? SelectedContact)
    {   

        _selectedViewModelContact = SelectedContact;
        if(_selectedViewModelContact != null)
        {
            Name = _selectedViewModelContact.Name;
            Surname = _selectedViewModelContact.Surname;
            Telephone = _selectedViewModelContact.Telephone;
        }

        SaveContactCommand = new RelayCommand(SaveContactCommandHandler);
;    }

}