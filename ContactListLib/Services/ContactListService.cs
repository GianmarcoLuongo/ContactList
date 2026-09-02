using System;
using System.Collections.ObjectModel;
using ContactListLib.ViewModels;
using ContactListLib.Models;

namespace ContactListLib.Services;

public static class ContactListService
{
    public static ObservableCollection<Contact> ContactList { get; set; } = BlackBoard.ContactList;

    
}