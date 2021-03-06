using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Dominio.Manager;

namespace ERP.Dominio
{
    class Customer
    {
        //------------------------------------Attributes--------------------------------
        private int idCustomer { get; set; }
        private String dni { get; set; }
        private String name { get; set; }
        private String surname { get; set; }
        private String address { get; set; }
        private int phone_number { get; set; }
        private String email { get; set; }
        private int zip_code { get; set; }

        private static ManagerCustomer g;

        //------------------------------------Constructors--------------------------------
        public Customer(int idCustomer, String dni,String name, String surname, String address, int phone_number, String email, int zip_code)
        {
            this.dni = dni;
            this.idCustomer = idCustomer;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.phone_number = phone_number;
            this.email = email;
            this.zip_code = zip_code;
        }

        public Customer(String name, String dni, String surname, String address, int phone_number, String email, int zip_code)
        {
            this.dni = dni;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.phone_number = phone_number;
            this.email = email;
            this.zip_code = zip_code;
        }

        public static ManagerCustomer manager()
        {
            if (g == null)
                g = new ManagerCustomer();

            return g;
        }

        //-----------------------------------Getters-----------------------------------
        public int getIdCustomer()
        {
            return idCustomer;
        }

        public String getName()
        {
            return name;
        }

        public String getSurname()
        {
            return surname;
        }

        public String getAddress()
        {
            return address;
        }

        public int getPhoneNumber()
        {
            return phone_number;
        }

        public String getEmail()
        {
            return email;
        }

        public int getZipCode()
        {
            return zip_code;
        }

        public String getDni()
        {
            return dni;
        }

        //-----------------------------------Setters-----------------------------------
        public void setId(int idCustomer) 
        {
            this.idCustomer = idCustomer;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setSurname(String surname)
        {
            this.surname = surname;
        }

        public void setAddress(String address)
        {
            this.address = address;
        }

        public void setPhoneNumber(int phone_number)
        {
            this.phone_number = phone_number;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public void setZipCode(int zip_code)
        {
            this.zip_code = zip_code;
        }

        public void setDni(String dni)
        {
            this.dni = dni;
        }

        //-----------------------------------Methods-----------------------------------
        public static void readAll()
        {
            manager().readAllCustomers();
        }

        public void search()
        {
            manager().readCustomer(this);
        }

        public void create()
        {
            manager().createCustomer(this);
        }

        public void modify()
        {
            manager().modifyCustomer(this);
        }

    }
}
