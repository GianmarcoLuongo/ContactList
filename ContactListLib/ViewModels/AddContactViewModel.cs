using System;
using System.Collections.ObjectModel;
using ContactListLib.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
namespace ContactListLib.ViewModels;

public class AddContactViewModel 
{   
    
    public Action RequestClose;
    public string Name { get; set; }
    public string Surname {get; set;}
    public int Telephone { get; set; }
    
    // sez. Commands
    public ICommand SaveContactCommand { get; set;}
    public void SaveContactCommandHandler()
    {

        BlackBoard.ContactList.Add(new Contact(Name,Surname,Telephone));
        RequestClose.Invoke();
    }
    public AddContactViewModel()
    {
        // prova aggiunta commento 
        SaveContactCommand = new RelayCommand(SaveContactCommandHandler);
;    }

}