using System;
using System.Collections.ObjectModel;

namespace ContactListClient.Models;

public static class ProxyBlackBoard
{   
    public static bool FirstTimeCreation { get; set;} = false;
    public static ObservableCollection<Contact> ContactList {get; set;}
    /*
    public BlackBoard(bool firstTimeCreation,ObservableCollection<Contact> listaContatti)
    {
        FirstTimeCreation = firstTimeCreation;
        ListaContatti = listaContatti;
    }
    */
}