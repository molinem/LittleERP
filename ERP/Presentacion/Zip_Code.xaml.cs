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
using System.Windows.Shapes;

namespace ERP.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Zip_Code.xaml
    /// </summary>
    public partial class Zip_Code : Window
    {
        public Zip_Code()
        {
            InitializeComponent();
        }

        private void dgCodigoPostal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = dgCodigoPostal.SelectedItem;
            Console.WriteLine("------------------- "+row.ToString());
        }
    }
}
