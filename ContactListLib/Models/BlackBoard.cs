using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Security.Cryptography;


namespace ContactListLib.Models;

public static class BlackBoard
{   
    public static string NameSurnameGUIDString;

    //public static ObservableCollection<string> ContactListKeys { get; set; } = new ObservableCollection<string>();

    //public static ObservableCollection<Contact> ContactList {get; set;} = new ObservableCollection<Contact>();
    
    public static ObservableCollection<KeyValuePair<string,Contact>> ContactListDictionary = new ObservableCollection<KeyValuePair<string,Contact>>();
    
    public static void AddContactKeyCreateHandler(Contact contact)
    {   
        string NameSurnameConcat = contact.Name + contact.Surname;
        byte[] NameSurnameHash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(NameSurnameConcat));
        byte[] NameSurnameGuidBytes = NameSurnameHash[..16];
        Guid NameSurnameGUID = new Guid(NameSurnameGuidBytes);
        NameSurnameGUIDString = NameSurnameGUID.ToString();
    }

    public static void AddContactToDictionaryHandler(Contact contact)
    {
        AddContactKeyCreateHandler(contact);
        ContactListDictionary.Add(new KeyValuePair<string, Contact>(NameSurnameGUIDString,contact));
    }
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