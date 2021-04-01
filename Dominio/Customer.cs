using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Customer
    {
        //------------------------------------Attributes--------------------------------
        private int idCustomer { get; set; }
        private String name { get; set; }
        private String surname { get; set; }
        private String address { get; set; }
        private int phone_number { get; set; }
        private String email { get; set; }
        private int zip_code { get; set; }

        private Manager.ManagerCustomer g;

        //------------------------------------Constructors--------------------------------
        public Customer() 
        {
            g = new Manager.ManagerCustomer();
        }

        public Customer(int idCustomer, string name, string surname, string address, int phone_number, string email, int zip_code)
        {
            this.idCustomer = idCustomer;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.phone_number = phone_number;
            this.email = email;
            this.zip_code = zip_code;
        }

        public Manager.ManagerCustomer manager()
        {
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
            return this.email;
        }

        public int getZipCode()
        {
            return zip_code;
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

        //-----------------------------------Methods-----------------------------------
        public void readAll()
        {
            g.readAllCustomers();
        }

        public void search()
        {
            g.readCustomer(this);
        }

        public void create()
        {
            g.createCustomer(this);
        }

        public void modify()
        {
            g.modifyCustomer(this);
        }

        public void delete() 
        {
            g.deleteCustomer(this);
        }
    }
}
