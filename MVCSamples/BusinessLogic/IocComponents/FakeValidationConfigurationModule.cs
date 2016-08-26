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
    public class FakeValidationConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            //  This module causes NInject to map all employee validators 
            //  to this null employee validator which basically 
            //  receives the call but does nothing
            Bind<Validator<Employee>>().To<NullEmployeeValidator>();
        }
    }

   
}
