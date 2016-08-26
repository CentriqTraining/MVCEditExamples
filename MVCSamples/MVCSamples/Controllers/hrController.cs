using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCSamples.Controllers
{
    public class hrController : ApiController
    {
        // GET api/hr/5
        public IEnumerable<object> Get(string term)
        {
            //  A quick WEB API method to bring back all the positions that match
            //  with what the user has typed in so far (autosuggest mode)
            //  returns IEnumerable<anon-type { string label, string value }>
            using (var db = new BuyMoriaContext())
            {
                var positions = db.Employees.
                    Where(e 
                        => e.Position.ToLower().Contains(term.ToLower())).
                    Select(e => new 
                            { 
                                label = e.Position, 
                                value = e.Position 
                            }).
                    Distinct();
                return positions.ToList();
            }
        }
    }
}
