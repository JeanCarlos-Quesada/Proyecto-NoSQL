using DAL;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_NoSQL
{
    public class Worker
    {
        private ConnectionCliente connectionCliente = new ConnectionCliente();
        private ConnectionEmpleado connectionEmpleado = new ConnectionEmpleado();
        public Worker()
        {
            var laOpcion = string.Empty;
            while (laOpcion != "X")
            {
                DesplegarMenuPrincipal();
                laOpcion = LeaLaOpcion();
                switch (laOpcion)
                {
                    case "1":
                        DesplegarMenuCliente();
                        laOpcion = LeaLaOpcion();
                        switch (laOpcion)
                        {
                            case "1":
                                GetAllClientes();
                                break;
                            case "2":
                                Console.WriteLine("Digite le ID del cliente:");
                                long idCliente = long.Parse(Console.ReadLine());
                                GetClienteById(idCliente);
                                break;
                            case "3":
                                Console.WriteLine("Digite la identificación del cliente:");
                                String identificacion = Console.ReadLine();
                                GetClienteByidentificacion(identificacion);
                                break;
                            case "4":
                                Cliente cliente = new Cliente();
                                Console.WriteLine("Digite la identificación del cliente:");
                                cliente.identificacion = Console.ReadLine();
                                Console.WriteLine("Digite el nombre del cliente:");
                                cliente.nombre = Console.ReadLine();
                                Console.WriteLine("Digite el teléfono del cliente:");
                                cliente.telefono = Console.ReadLine();
                                Console.WriteLine("Digite el email del cliente:");
                                cliente.email = Console.ReadLine();

                                InsertCliente(cliente);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        DesplegarMenuEmpleado();
                        laOpcion = LeaLaOpcion();
                        switch (laOpcion)
                        {
                            case "1":
                                GetAllEmpleados();
                                break;
                            case "2":
                                Console.WriteLine("Digite le ID del empleado:");
                                long idEmpleado = long.Parse(Console.ReadLine());
                                GetEmpleadoById(idEmpleado);
                                break;
                            case "3":
                                Console.WriteLine("Digite la identificación del empleado:");
                                String identificacion = Console.ReadLine();
                                GetEmpleadoByidentificacion(identificacion);
                                break;
                            case "4":
                                Empleado empleado = new Empleado();
                                Console.WriteLine("Digite la identificación del empleado:");
                                empleado.identificacion = Console.ReadLine();
                                Console.WriteLine("Digite el nombre del empleado:");
                                empleado.nombre = Console.ReadLine();
                                Console.WriteLine("Digite el genero del empleado:");
                                empleado.genero = Console.ReadLine()[0];
                                Console.WriteLine("Digite el teléfono del empleado:");
                                empleado.telefono = Console.ReadLine();
                                Console.WriteLine("Digite el email del empleado:");
                                empleado.email = Console.ReadLine();
                                empleado.fechaContratacion = DateTime.Now;

                                InsertEmpleado(empleado);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":

                        break;
                    case "4":

                        break;       
                    default:
                        break;
                }
            }
        }

        #region cliente
        public void GetAllClientes()
        {
            var clientes = connectionCliente.GetAll().OrderBy(s => s.idCliente).ToList();
            if (clientes != null)
            {
                imprimirCliente(clientes);
            }
            else
            {
                Console.WriteLine("No se encontraron clientes");
            }
        }

        public void GetClienteById(long idCliente)
        {
            var clientes = connectionCliente.GetByIdCliente(idCliente).OrderBy(s => s.idCliente).ToList();
            if (clientes != null)
            {
                imprimirCliente(clientes);
            }
            else
            {
                Console.WriteLine("No se encontro el clientes");
            }
        }

        public void GetClienteByidentificacion(String identificacion)
        {
            var clientes = connectionCliente.GetByIdentificacion(identificacion).OrderBy(s => s.idCliente).ToList();
            if (clientes != null)
            {
                imprimirCliente(clientes);
            }
            else
            {
                Console.WriteLine("No se encontro el clientes");
            }
        }

        public void InsertCliente(Cliente cliente)
        {
            var logrado = connectionCliente.insertCliente(cliente);
            if (logrado)
            {
                Console.WriteLine("\nEl cliente se agrego correctamente \n");
                var tmp = connectionCliente.GetByIdentificacion(cliente.identificacion).OrderBy(s => s.idCliente).ToList();
                imprimirCliente(tmp);
            }
            else
            {
                Console.WriteLine("No se logro agregar el cliente");
            }
        }

        public void imprimirCliente(List<Cliente> clientes)
        {
            if (clientes.Count != 0)
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(String.Format("ID del Cliente: {0}\nIdentificación: {1}\nNombre: {2}\nTeléfono: {3}\nEmail: {4}\n",
                        cliente.idCliente, cliente.identificacion, cliente.nombre, cliente.telefono, cliente.email));
                }
            }
            else
            {
                Console.WriteLine("No se encontraron clientes");
            }
        }

        #endregion cliente

        #region empleado
        public void GetAllEmpleados()
        {
            var empleados = connectionEmpleado.GetAll().OrderBy(s => s.idEmpleado).ToList();
            if (empleados != null)
            {
                imprimirEmpleado(empleados);
            }
            else
            {
                Console.WriteLine("No se encontraron empleados");
            }
        }

        public void GetEmpleadoById(long idEmpleado)
        {
            var empleados = connectionEmpleado.GetByIdEmpleado(idEmpleado).OrderBy(s => s.idEmpleado).ToList();
            if (empleados != null)
            {
                imprimirEmpleado(empleados);
            }
            else
            {
                Console.WriteLine("No se encontro el empleados");
            }
        }

        public void GetEmpleadoByidentificacion(String identificacion)
        {
            var empleados = connectionEmpleado.GetByIdentificacion(identificacion).OrderBy(s => s.idEmpleado).ToList();
            if (empleados != null)
            {
                imprimirEmpleado(empleados);
            }
            else
            {
                Console.WriteLine("No se encontro el empleados");
            }
        }

        public void InsertEmpleado(Empleado empleado)
        {
            var logrado = connectionEmpleado.insertEmpleado(empleado);
            if (logrado)
            {
                Console.WriteLine("\nEl empleado se agrego correctamente \n");
                var tmp = connectionEmpleado.GetByIdentificacion(empleado.identificacion).OrderBy(s => s.idEmpleado).ToList();
                imprimirEmpleado(tmp);
            }
            else
            {
                Console.WriteLine("No se logro agregar el cliente");
            }
        }

        public void imprimirEmpleado(List<Empleado> empleados)
        {
            if (empleados.Count != 0)
            {
                foreach (var empleado in empleados)
                {
                    Console.WriteLine(String.Format("ID del Empleado: {0}\nIdentificación: {1}\nNombre: {2}\nGenero: {3}\nTeléfono: {4}\nEmail: {5}\nFecha de Contratación: {6}\n",
                        empleado.idEmpleado, empleado.identificacion, empleado.nombre,empleado.genero, empleado.telefono, empleado.email,empleado.fechaContratacion.ToString("dd/MM/yyyy")));
                }
            }
            else
            {
                Console.WriteLine("No se encontraron empleados");
            }
        }

        #endregion empleado

        private void DesplegarMenuPrincipal()
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1.  Menu Cliente");
            Console.WriteLine("2.  Menu Empleado");
            Console.WriteLine("3.  Menu Vehículo");
            Console.WriteLine("4.  Menu Pedido");
            Console.WriteLine("X.  Salir");
        }

        private void DesplegarMenuCliente()
        {
            Console.WriteLine("Menu Cliente");
            Console.WriteLine("1.  Listar todos los clientes");
            Console.WriteLine("2.  Buscar cliente por idCliente");
            Console.WriteLine("3.  Buscar cliente por identificación");
            Console.WriteLine("4.  Insertar un cliente");
            Console.WriteLine("X.  Salir");
        }

        private void DesplegarMenuEmpleado()
        {
            Console.WriteLine("Menu Empleado");
            Console.WriteLine("1.  Listar todos los empleados");
            Console.WriteLine("2.  Buscar empleado por idEmpleado");
            Console.WriteLine("3.  Buscar empleado por identificación");
            Console.WriteLine("4.  Insertar un empleado");
            Console.WriteLine("X.  Salir");
        }

        private string LeaLaOpcion()
        {
            string elResultado = Console.ReadLine();
            return elResultado;
        }
    }
}
