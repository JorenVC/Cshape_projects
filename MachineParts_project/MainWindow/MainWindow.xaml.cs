using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using Examen.ViewModels;

namespace Examen;

public partial class MainWindow : Window
{
    ViewModel_Main vm_Main;
    public MainWindow()
    {
        InitializeComponent();
        vm_Main = new ViewModel_Main();

        DataContext = vm_Main;
    }

}