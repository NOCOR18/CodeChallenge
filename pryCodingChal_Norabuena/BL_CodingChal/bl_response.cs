using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_CodingChal;

namespace BL_CodingChal
{
    public class bl_response
    {
        public void GetResults(string query)
        {
            ado_response a = new ado_response();
            a.GetResult(query);
        }
    }
}
