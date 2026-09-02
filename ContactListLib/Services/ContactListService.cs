using System;
using System.Collections.ObjectModel;
using ContactListLib.ViewModels;
using ContactListLib.Models;

namespace ContactListLib.Services;

public class ContactListService
{
    private ObservableCollection<Contact> _contactList { get; set; }

    public ContactListService()
    {
        _contactList = BlackBoard.ContactList;
    }

    public ObservableCollection<Contact> GetContactsService()
    {
        return _contactList;
    }

    
}