using System;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using ContactListLib.Models;
using ContactListLib.Views;

namespace ContactListLib.Services;

public static class AddContactDialogService
{
    private static Contact? _existingContact { get; set;} = null;

    
    public static void AddContactDialogServiceSpawner(bool modal, String name, String surname)
    {   

        if (name != null && surname != null)
        {
            // Trova l'elemento se esiste in BlackBox ed aggiorna ViewModel per editare
            
            foreach (var Contact in BlackBoard.ContactList)
            {
                if (Contact.Name == name && Contact.Surname == surname)
                {
                    _existingContact = Contact;
                    break;
                }
            }
        }
        var AddContactDialog = new AddContactDialogWindow(_existingContact);
        if (modal) AddContactDialog.ShowDialog();
        else AddContactDialog.Show();
    }
}
