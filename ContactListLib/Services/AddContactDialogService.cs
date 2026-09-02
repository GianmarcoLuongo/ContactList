using System;
using ContactListLib.Views;

namespace ContactListLib.Services;

public class AddContactDialogService : IAddContactDialogService
{
    public void AddContactDialogServiceSpawner(bool modal, String cognome, String nome)
    {
        var AddContactDialog = new AddContactDialogWindow();
        if (cognome != null && nome != null)
        {
            // Trova l'elemento se esiste in BlackBox ed aggiorna ViewModel per editare
            
        }
        if (modal) AddContactDialog.ShowDialog();
        else AddContactDialog.Show();
    }
}
