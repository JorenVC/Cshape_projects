using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Examen_JorenVanCalster.ViewModels;

namespace Examen_JorenVanCalster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ViewModel_Main vm_main;
        public MainWindow()
        {
            InitializeComponent();
            vm_main = new ViewModel_Main();

            DataContext = vm_main;
        }
    }
}
