using System;
using System.Collections.ObjectModel;
using ContactListLib.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ContactListLib.Services;
namespace ContactListLib.ViewModels;

public class AddContactViewModel 
{   

    private Contact? _selectedContact { get; set; }
    public Action RequestClose;
    public string? Name { get; set; }
    public string? Surname {get; set;}
    public int Telephone { get; set; }
    
    // sez. Commands
    public ICommand SaveContactCommand { get; set;}
public void SaveContactCommandHandler()
{
    if (_selectedContact == null)
    {
        bool exists = false;

        foreach (Contact contact in BlackBoard.ContactList)
        {
            if (contact.Name == Name &&
                contact.Surname == Surname)
            {
                contact.Telephone = Telephone;
                exists = true;
                break;
            }
        }

        if (!exists)
        {
            BlackBoard.ContactList.Add(
                new Contact(Name, Surname, Telephone));

            RequestClose?.Invoke();
        }
    }
    else
    {
        _selectedContact.Name = Name;
        _selectedContact.Surname = Surname;
        _selectedContact.Telephone = Telephone;

        RequestClose?.Invoke();
    }
}
    public AddContactViewModel(Contact? SelectedContact)
    {
        _selectedContact = SelectedContact;
        if(_selectedContact != null)
        {
            Name = _selectedContact.Name;
            Surname = _selectedContact.Surname;
            Telephone = _selectedContact.Telephone;
        }

        SaveContactCommand = new RelayCommand(SaveContactCommandHandler);
;    }

}