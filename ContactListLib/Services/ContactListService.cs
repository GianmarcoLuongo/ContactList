using System;
using System.Collections.ObjectModel;
using ContactListLib.ViewModels;
using ContactListLib.Models;

namespace ContactListLib.Services;

public static class ContactListService
{
    public static ObservableCollection<KeyValuePair<string,Contact>> ContactListDictionary { get; set; } = BlackBoard.ContactListDictionary;
    
}