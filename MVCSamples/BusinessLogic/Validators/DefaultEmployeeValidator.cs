using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{

    public class DefaultEmployeeValidator : Validator<Employee>
    {
        public override void ValidateProperty(string propertyName, Employee obj)
        {
            RemoveError(propertyName);
            switch (propertyName)
            {
                case "Position":
                    ValidatePosition(obj);
                    break;
                default:
                    break;
            }
        }
        private void ValidatePosition(Employee obj)
        {
            if (obj != null && obj.Position != null)
            {
                using (var ctx = new BuyMoriaContext())
                {
                    var positions = ctx.Employees.Select(e => e.Position).Distinct();
                    var IsCurrentPosition = positions.Contains(obj.Position);
                    if (!IsCurrentPosition)
                    {
                        AddError("Position", "Not a valid position - please use an existing position");
                    }
                }
            }
        }
    }



}
