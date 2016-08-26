using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IocComponents
{
    // singleton - Stays alive throughout the web app.

    //  for more information on how NInject works, you can consult
    //  http://www.ninject.org/
    //  VISIT the DOJO
    //  http://www.ninject.org/learn.html
    public class NInjectKernel
    {
        private static NInjectKernel _Instance;
        public bool UseNullValidator { get; set; }
        private NInjectKernel() { }
        public static NInjectKernel Current
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NInjectKernel();
                }

                return _Instance;
            }
        }
        public IKernel GetKernel()
        {
            if (UseNullValidator)
            {
                return new StandardKernel(new FakeValidationConfigurationModule());
            }
            else
                return new StandardKernel(new ValidationConfigurationModule());
        }
    }

}
