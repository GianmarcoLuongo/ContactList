using System;
using ContactListLib.Views;

namespace ContactListLib.Services;

public interface IAddContactDialogService
{
    public  void AddContactDialogServiceSpawner(bool modal, String cognome, String nome);
}