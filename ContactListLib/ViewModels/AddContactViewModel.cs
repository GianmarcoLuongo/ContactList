using System;
using System.Collections.ObjectModel;
using ContactListLib.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ContactListLib.Services;
namespace ContactListLib.ViewModels;

public class AddContactViewModel 
{   
    private Contact? _existingContact { get; set; }
    public Action RequestClose;
    public string? Name { get; set; }
    public string? Surname {get; set;}
    public int Telephone { get; set; }
    
    // sez. Commands
    public ICommand SaveContactCommand { get; set;}
    public void SaveContactCommandHandler()
    {

        if (_existingContact == null)
        {
            BlackBoard.ContactList.Add(new Contact(Name,Surname,Telephone));
            
            RequestClose.Invoke();
        }
        else
        {
            _existingContact.Name = Name;
            _existingContact.Surname = Surname;
            _existingContact.Telephone = Telephone;
            




            RequestClose.Invoke();
        }

    }
    public AddContactViewModel(Contact? ExistingContact)
    {
        _existingContact = ExistingContact;
        if(_existingContact != null)
        {
            Name = _existingContact.Name;
            Surname = _existingContact.Surname;
            Telephone = _existingContact.Telephone;
        }
        SaveContactCommand = new RelayCommand(SaveContactCommandHandler);
;    }

}