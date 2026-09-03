using System;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using ContactListLib.Models;
using ContactListLib.Views;

namespace ContactListLib.Services;

public static class AddContactDialogService
{
    private static Contact? _selectedContact {get; set;}
    
    public static void AddContactDialogServiceSpawner(bool modal, String name, String surname)
    {   

        if (name != null && surname != null)
        {
            // Trova l'elemento se esiste in BlackBox ed aggiorna ViewModel per editare
            
            foreach (var Contact in BlackBoard.ContactList)
            {
                if (Contact.Name == name && Contact.Surname == surname)
                {
                    _selectedContact  = Contact;
                    break;
                }
            }
        }
        var AddContactDialog = new AddContactDialogWindow(_selectedContact);
        if (modal) AddContactDialog.ShowDialog();
        else AddContactDialog.Show();
        _selectedContact = null;
    }

    // non viene attuata la dependency injection per il motivo che una classe statica non può essere istanziata
    // in c# le istanze delle classi sono passate per riferimento di default
    public static void AddContactDialogServiceSpawner(bool modal, Contact SelectedContact)
    {
                if (SelectedContact.Name != null && SelectedContact.Surname != null)
        {
            // Trova l'elemento se esiste in BlackBox ed aggiorna ViewModel per editare
            
            foreach (var Contact in BlackBoard.ContactList)
            {
                if (Contact.Name == SelectedContact.Name && Contact.Surname == SelectedContact.Surname)
                {
                    _selectedContact = Contact;
                    break;
                }
            }
        }
        var AddContactDialog = new AddContactDialogWindow(_selectedContact);
        if (modal) AddContactDialog.ShowDialog();
        else AddContactDialog.Show();
    }


}
