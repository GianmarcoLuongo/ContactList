using System;
using System.Collections.ObjectModel;
using System.Windows;
using ContactListLib.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ContactListLib.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text;
using System.Security.Cryptography;
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
    public ICommand RemoveContactCommand { get; set; }


public void SaveContactCommandHandler()
{
    if (_selectedViewModelContact == null)
    {
        bool exists = false;
        
        /*
            foreach (KeyValuePair<string,Contact> pair in BlackBoard.ContactListDictionary)
            {
                MessageBox.Show($"Collection Record Value : {pair.Key}");
            }

            MessageBox.Show($"{AddContactDialogService.ContactSelectionKeyGUIDString}");
        */
        foreach (KeyValuePair<string,Contact> contactDictEntry in BlackBoard.ContactListDictionary)
        {
            if (contactDictEntry.Value.Name == Name &&
                contactDictEntry.Value.Surname == Surname)
            {
                contactDictEntry.Value.Telephone = Telephone;
                exists = true;
                AddContactDialogService.SelectedItemResetHandler();
                RequestClose?.Invoke();
                //_selectedViewModelContact = null;
                break;
            }
        }

        if (!exists)
        {
            //BlackBoard.ContactList.Add(new Contact(Name, Surname, Telephone));
            BlackBoard.AddContactToDictionaryHandler(new Contact(Name,Surname,Telephone));
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

    public void RemoveContactCommandHandler()
    {
        {
            /*
            foreach (KeyValuePair<string,Contact> pair in BlackBoard.ContactListDictionary)
            {   
                if (AddContactDialogService.ContactSelectionKeyGUIDString == pair.Key)
                {
                    MessageBox.Show("La corrispondenza c'è");
                }
            }
            */
            var ContactListDictionaryRemoveEntry = BlackBoard.ContactListDictionary.FirstOrDefault(x => x.Key == AddContactDialogService.ContactSelectionKeyGUIDString);
            BlackBoard.ContactListDictionary.Remove(ContactListDictionaryRemoveEntry);
            
        }
        AddContactDialogService.SelectedItemResetHandler();
        RequestClose?.Invoke();
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
            if (Name!=null && Surname!=null)
            {
            Name = Name.Trim();
            Surname = Surname.Trim();
            byte[] ContactSelectionKey = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Name+Surname));
            Guid ContactSelectionKeyGUID = new Guid(ContactSelectionKey[..16]);
            AddContactDialogService.ContactSelectionKeyGUIDString = ContactSelectionKeyGUID.ToString();
            }
        SaveContactCommand = new RelayCommand(SaveContactCommandHandler);
        RemoveContactCommand = new RelayCommand(RemoveContactCommandHandler);
;    }

}