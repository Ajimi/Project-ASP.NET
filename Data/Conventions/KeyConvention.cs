using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Conventions
{
    class KeyConvention: Convention
    {

        public KeyConvention()
        {
            Properties<short>().Configure(t => t.IsKey());
        }
    }
}
