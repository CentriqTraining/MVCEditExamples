using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class NullEmployeeValidator : Validator<Employee>
    {
        public override void ValidateProperty(string propertyName, Employee obj)
        {
        }
    }
}
