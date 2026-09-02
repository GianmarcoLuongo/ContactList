using System;
using System.Collections.ObjectModel;

namespace ContactListLib.Models;

public static class BlackBoard
{   
    public static ObservableCollection<Contact> ContactList {get; set;} = new ObservableCollection<Contact>();
    /*
    public BlackBoard(bool firstTimeCreation,ObservableCollection<Contact> listaContatti)
    {
        FirstTimeCreation = firstTimeCreation;
        ListaContatti = listaContatti;
    }
    */

    // I contatti sono molto simili ad una tabella di DB. Questo significa che in genere
    // il dato va gestito con key + value ossia un dizionario.
    // Avendo Nome e Cognome un modo semplice per ottenere una chiave è "Cognome % Nome"
}