using DAL;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_NoSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionCliente connectionCliente = new ConnectionCliente();
            connectionCliente.GetByIdentificacion("305170596");
        }
    }
}
