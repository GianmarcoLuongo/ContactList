using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactListClient.Models;
using ContactListClient.ViewModels;
using ContactListLib.Services;
namespace ContactListClient.Views;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{   

    public MainWindow()
    {   

        InitializeComponent();

        DataContext = new MainViewModel(ContactListGrid);
        
    }
    protected override void OnClosing(CancelEventArgs e)
    {
        // Ciclo per tutte le finestre aperte e chiuderle
        foreach (Window window in Application.Current.Windows)
        {
            if (window != this)
            {
                window.Close();
            }
        }

        base.OnClosing(e);
    }

    private void ContactListGridLostFocus(object sender,RoutedEventArgs e)
    {
        ContactListGrid.SelectedItem = new Contact(null,null,0);
    }

    private void ContactListGrid_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        var selected = ContactListGrid.SelectedItem;

        MessageBox.Show($"Tipo SelectedItem: {selected?.GetType().FullName}");
    }

}