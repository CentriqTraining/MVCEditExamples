using BusinessLogic.Models;
using BusinessLogic.Validators;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IocComponents
{
    public class ValidationConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            //  This config module causes NInject to inject the class
            //  DefaultEmployeeValidator into the employee object
            //  to provide business rules for POSITION  
            Bind<Validator<Employee>>().To<DefaultEmployeeValidator>();
        }
    }

   
}
