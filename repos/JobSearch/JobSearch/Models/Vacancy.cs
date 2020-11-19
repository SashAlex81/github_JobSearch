using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.Models
{
    public class Vacancy
    {
        int id;
        string header;
        int salary;
        string organization;
        string contactPerson;
        string phone;
        string typeOfEmployment;
        string description;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }

        public string ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string TypeOfEmployment
        {
            get { return typeOfEmployment; }
            set { typeOfEmployment = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
