using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallFlow
{
    public class Base_Logic :  IDisposable
    {
        protected CallFlowContext DB;

        public Base_Logic()
        {
            DB = new CallFlowContext();
        }

        public void Dispose() { }
    }
}
