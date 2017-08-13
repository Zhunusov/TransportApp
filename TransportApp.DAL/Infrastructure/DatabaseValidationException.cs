using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.DAL.Infrastructure
{
    public class DatabaseValidationException:Exception
    {
        public string Property { get; protected set; }
        public DatabaseValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
