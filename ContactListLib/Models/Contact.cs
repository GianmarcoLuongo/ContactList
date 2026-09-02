using System;

namespace ContactListLib.Models;

public class Contact
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Telephone { get; set; }
    public Contact(string name, string surname, int telephone)
    {
        Name = name;
        Surname = surname;
        Telephone = telephone;
    }
}

