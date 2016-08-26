using BusinessLogic.IocComponents;
using BusinessLogic.Validators;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    public class Employee : IDataErrorInfo
    {
        private int _ID;
        private string _FirstName;
        private string _LastName;
        private string _Position;
        private decimal _Salary;
        private DateTime? _TerminationDate;
        private Validator<Employee> _Val;

        //  This is required for NInject to be able to inject the 
        //  correct validation class declared above at runtime
        [Inject]  //  <-  Tells NInject where to Inject
        public Validator<Employee> Val
        {
            set { _Val = value; }
        }
        public Employee()
        {
            NInjectKernel.Current.GetKernel().Inject(this);  //  <-  Does the injecting
        }
      
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [StringLength(55)]
        [DisplayName("First Name")]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                _Val.ValidateProperty("FirstName", this);
            }
        }

        [DisplayName("Last Name")]
        [StringLength(55)]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                _Val.ValidateProperty("LastName", this);
            }
        }

        [StringLength(155)]
        public string Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                _Val.ValidateProperty("Position", this);
            }
        }

        [Range(0, 180)]
        public decimal Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        [DisplayFormat(ApplyFormatInEditMode = true,
                        DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [DisplayName("Termination Date")]
        public DateTime? TerminationDate
        {
            get { return _TerminationDate; }
            set { _TerminationDate = value; }
        }

        public virtual ICollection<Expense> Expenses { get; set; }

        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get { return _Val[columnName]; }
        }
    }
}