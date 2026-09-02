using System;
using CommunityToolkit.Mvvm.ComponentModel;
namespace ContactListLib.Models;

public partial class Contact : ObservableObject
{
    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private string? _surname;
    [ObservableProperty]
    private int _telephone;
    public Contact(string? name, string? surname, int telephone)
    {
        _name = name;
        _surname = surname;
        _telephone = telephone;
    }
}

