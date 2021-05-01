using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public static bool correctDni(TextBox txtDni)
        {
            //8 dígits 1 letter)
            string patron = "[A-HJ-NP-SUVW][0-9]{7}[0-9A-J]|\\d{8}[TRWAGMYFPDXBNJZSQVHLCKE]|[X]\\d{7}[TRWAGMYFPDXBNJZSQVHLCKE]|[X]\\d{8}[TRWAGMYFPDXBNJZSQVHLCKE]|[YZ]\\d{0,7}[TRWAGMYFPDXBNJZSQVHLCKE]";
            string sRemp = "";
            bool ret = false;
            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(patron);
            sRemp = rgx.Replace(txtDni.Text.ToString().ToUpper(), "OK");
            if (sRemp == "OK") ret = true;

            //Check is letter is correct
            if (ret)
            {
                string data = txtDni.Text.ToString().ToUpper();
                string readLetter = data.Substring(data.Length - 1, 1);

                int nifNum = int.Parse(data.Substring(0, data.Length - 1));

                string correctLetter = getLetter(nifNum % 23);
                if (!correctLetter.Equals(readLetter))
                {
                    ret = false;
                }
            }
            return ret;
        }


        //Méthod that return correct letter of DNI
        public static string getLetter(int id)
        {
            Dictionary<int, String> letters = new Dictionary<int, string>();
            letters.Add(0, "T");
            letters.Add(1, "R");
            letters.Add(2, "W");
            letters.Add(3, "A");
            letters.Add(4, "G");
            letters.Add(5, "M");
            letters.Add(6, "Y");
            letters.Add(7, "F");
            letters.Add(8, "P");
            letters.Add(9, "D");
            letters.Add(10, "X");
            letters.Add(11, "B");
            letters.Add(12, "N");
            letters.Add(13, "J");
            letters.Add(14, "Z");
            letters.Add(15, "S");
            letters.Add(16, "Q");
            letters.Add(17, "V");
            letters.Add(18, "H");
            letters.Add(19, "L");
            letters.Add(20, "C");
            letters.Add(21, "K");
            letters.Add(22, "E");
            return letters[id];
        }

        public static bool correctName(TextBox txtName)
        {
            bool ok = true;

            string name = txtName.Text;
            if (name != null)
            {
                if (name.Length < 30)
                {
                    if (!name.Equals(""))
                    {
                        for (int i = 0; i < name.Length; i++)
                        {
                            char car = name[i];
                            if (Char.IsDigit(car))
                            {
                                ok = false;
                            }
                        }

                        if (name.Contains("'"))
                        {
                            ok = false;
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }


        public static bool correctSurname(TextBox txtSurname)
        {
            bool ok = true;

            string surname = txtSurname.Text;
            if (surname != null)
            {
                if (surname.Length < 20)
                {
                    if (!surname.Equals(""))
                    {
                        for (int i = 0; i < surname.Length && ok; i++)
                        {
                            char car = surname[i];
                            if (Char.IsDigit(car))
                            {
                                ok = false;
                            }
                        }

                        if (surname.Contains("'"))
                        {
                            ok = false;
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }


        public static bool correctAddress(TextBox txtAddress)
        {
            bool ok = true;

            string address = txtAddress.Text;
            if (address != null)
            {
                if (address.Length <= 30)
                {
                    if (!address.Equals(""))
                    {
                        if (address.Contains("'"))
                        {
                            ok = false;
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }

            }
            else
            {
                ok = false;
            }
            return ok;
        }

        public static bool correctPhone(TextBox txtPhone)
        {
            bool ok = true;

            string phone = txtPhone.Text;
            if (phone != null)
            {
                try
                {
                    int number = int.Parse(phone);
                }
                catch (FormatException f)
                {
                    ok = false;
                }
            }

            return ok;
        }

        public static bool correctEmail(TextBox txtEmail)
        {
            bool ok = true;

            string email = txtEmail.Text;
            if (email != null)
            {
                if (email.Length < 30)
                {
                    if (email.Contains("'"))
                    {
                        ok = false;
                    }
                    else
                    {
                        int cont = 0;
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i].Equals('@') || email[i].Equals('.'))
                            {
                                cont++;
                            }
                        }

                        if (cont > 1)
                        {
                            email = txtEmail.Text;
                        }
                    }
                }
                else
                {
                    ok = false;
                }
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        public static bool okData()
        {
            bool ok = true;

            return ok;
        }
    }
}
