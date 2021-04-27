using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Manager
{
    class Auxiliary
    {
        public Auxiliary() { }

        public static int obtainSelectedOnComboBox(System.Windows.Controls.ComboBox cbo)
        {
            DataRowView row = (DataRowView)cbo.SelectedItem;
            DataRow data = row.Row;
            Object[] objData = data.ItemArray;
            decimal obtainData = (decimal)objData[0];
            int dat = (int)obtainData;
            return dat;
        }

    }
}
