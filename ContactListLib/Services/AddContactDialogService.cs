using System;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using ContactListLib.Models;
using ContactListLib.Views;

namespace ContactListLib.Services;

public static class AddContactDialogService
{
    public static Contact? _selectedContact {get; set;} = null;
    public static event Action SelectedItemReset;

    public static void SelectedItemResetHandler()
    {
        AddContactDialogService.SelectedItemReset.Invoke();
    }
    
    public static void AddContactDialogServiceSpawner(bool modal, String name, String surname)
    {   
        if (name != null && surname != null)
        {
            // Trova l'elemento se esiste in BlackBox ed aggiorna ViewModel per editare
            
            foreach (var contactDictEntry in BlackBoard.ContactListDictionary)
            {
                if (contactDictEntry.Value.Name == name && contactDictEntry.Value.Surname == surname)
                {
                    _selectedContact  = new Contact(contactDictEntry.Value.Name,contactDictEntry.Value.Surname,contactDictEntry.Value.Telephone);
                    break;
                }
            }
        }
        var AddContactDialog = new AddContactDialogWindow(_selectedContact);
        if (modal) AddContactDialog.ShowDialog();
        else AddContactDialog.Show();
        
    }

    // non viene attuata la dependency injection per il motivo che una classe statica non può essere istanziata
    // in c# le istanze delle classi sono passate per riferimento di default
    public static void AddContactDialogServiceSpawner(bool modal, Contact? SelectedContact)
    {       
        _selectedContact = null;
                if (SelectedContact.Name != null && SelectedContact.Surname != null)
        {
            // Trova l'elemento se esiste in BlackBox ed aggiorna ViewModel per editare
            
            foreach (var contactDictEntry in BlackBoard.ContactListDictionary)
            {
                if (contactDictEntry.Value.Name == SelectedContact.Name && contactDictEntry.Value.Surname == SelectedContact.Surname)
                {
                    _selectedContact = contactDictEntry.Value;
                }
            }
        }
        var AddContactDialog = new AddContactDialogWindow(_selectedContact);
        if (modal) AddContactDialog.ShowDialog();
        else AddContactDialog.Show();
        
    }


}
