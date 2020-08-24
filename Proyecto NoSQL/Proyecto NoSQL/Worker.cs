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
        private ConnectionVehiculo connectionVehiculo = new ConnectionVehiculo();
        private ConnectionPedido connectionPedido = new ConnectionPedido();

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
                            case "5":
                                GetAllClientes();
                                Console.WriteLine("Digite le ID del cliente:");
                                idCliente = long.Parse(Console.ReadLine());
                                GetClienteById(idCliente);
                                Console.WriteLine("Digite el teléfono del cliente:");
                                String telefono = Console.ReadLine();
                                UpdateTelefonoCliente(idCliente, telefono);
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
                                empleado.genero = Console.ReadLine()[0]+"";
                                Console.WriteLine("Digite el teléfono del empleado:");
                                empleado.telefono = Console.ReadLine();
                                Console.WriteLine("Digite el email del empleado:");
                                empleado.email = Console.ReadLine();
                                empleado.fechaContratacion = DateTime.Now;

                                InsertEmpleado(empleado);
                                break;
                            case "5":
                                GetAllEmpleados();
                                Console.WriteLine("Digite le ID del empleado:");
                                idEmpleado = long.Parse(Console.ReadLine());
                                GetEmpleadoById(idEmpleado);
                                Console.WriteLine("Digite la nueva fecha (dd/mm/yyyy):");
                                String fecha = Console.ReadLine();
                                UpdateFechaContratacionEmpleado(idEmpleado, fecha);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        DesplegarMenuVehiculo();
                        laOpcion = LeaLaOpcion();
                        switch (laOpcion)
                        {
                            case "1":
                                GetAllVehiculos();
                                break;
                            case "2":
                                Console.WriteLine("Digite le ID del vehiculo:");
                                long idVehiculo = long.Parse(Console.ReadLine());
                                GetVehiculoById(idVehiculo);
                                break;
                            case "3":
                                Console.WriteLine("Digite la fecha de inicio (dd/mm/yyyy):");
                                String fecha = Console.ReadLine();
                                GetPedidosByFechaInicio(fecha);
                                break;
                            case "4":
                                Console.WriteLine("Digite la marca:");
                                String marca = Console.ReadLine();
                                GetVehiculoByMarca(marca);
                                break;
                            case "5":
                                Console.WriteLine("Digite el año:");
                                String year = Console.ReadLine();
                                GetVehiculoByYear(year);
                                break;
                            case "6":
                                //Insert
                                break;
                            case "7":
                                GetAllVehiculos();
                                Console.WriteLine("Digite le ID del vehículo:");
                                idVehiculo = long.Parse(Console.ReadLine());
                                GetVehiculoById(idVehiculo);
                                Empleado empleado = new Empleado();
                                Console.WriteLine("Digite la identificación del empleado:");
                                empleado.identificacion = Console.ReadLine();
                                Console.WriteLine("Digite el nombre del empleado:");
                                empleado.nombre = Console.ReadLine();
                                Console.WriteLine("Digite el genero del empleado:");
                                empleado.genero = Console.ReadLine()[0]+"";
                                Console.WriteLine("Digite el teléfono del empleado:");
                                empleado.telefono = Console.ReadLine();
                                Console.WriteLine("Digite el email del empleado:");
                                empleado.email = Console.ReadLine();
                                UpdateRegistardoPor(idVehiculo, empleado);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        DesplegarMenuPedido();
                        laOpcion = LeaLaOpcion();
                        switch (laOpcion)
                        {
                            case "1":
                                GetAllPedidos();
                                break;
                            case "2":
                                Console.WriteLine("Digite le ID del pedido:");
                                long idPedido = long.Parse(Console.ReadLine());
                                GetPedidoById(idPedido);
                                break;
                            case "3":
                                Console.WriteLine("Digite la fecha de inicio (dd/mm/yyyy):");
                                String fecha = Console.ReadLine();
                                GetPedidosByFechaInicio(fecha);
                                break;
                            case "4":
                                GroupByEmpleado();
                                break;
                            case "5":
                                //Insert
                                break;
                            case "6":
                                GetAllPedidos();
                                Console.WriteLine("Digite le ID del pedido:");
                                idPedido = long.Parse(Console.ReadLine());
                                GetPedidoById(idPedido);
                                Console.WriteLine("Digite el nuevo estado (1/0):");
                                int estado = Int32.Parse(Console.ReadLine());
                                UpdateEstadoPedido(idPedido, estado);
                                break;
                            default:
                                break;
                        }
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

        public void UpdateTelefonoCliente(long idCliente, String telefono)
        {
            var logrado = connectionCliente.UpdateTelefonoCliente(idCliente, telefono);
            if (logrado)
            {
                Console.WriteLine("\nEl cliente se actualizo correctamente \n");
                GetClienteById(idCliente);
            }
            else
            {
                Console.WriteLine("No se logro actualizar el cliente");
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

        public void UpdateFechaContratacionEmpleado(long idEmpleado, String fecha)
        {
            int day = Int32.Parse(fecha[0] + "" + fecha[1]);
            int month = Int32.Parse(fecha[3] + "" + fecha[4]);
            int year = Int32.Parse(fecha[6] + "" + fecha[7] + "" + fecha[8] + "" + fecha[9]);
            DateTime date = new DateTime(year, month, day);

            var logrado = connectionEmpleado.UpdateFechaContratacionEmpleado(idEmpleado, date);
            if (logrado)
            {
                Console.WriteLine("\nEl empleado se actualizo correctamente \n");
                GetEmpleadoById(idEmpleado);
            }
            else
            {
                Console.WriteLine("No se logro actualizar el empleado");
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

        #region Vehiculo
        public void GetAllVehiculos()
        {
            var vehiculos = connectionVehiculo.GetAll().OrderBy(s => s.idVehiculo).ToList();
            if (vehiculos != null)
            {
                imprimirVehiculo(vehiculos);
            }
            else
            {
                Console.WriteLine("No se encontraron vehiculos");
            }
        }

        public void GetVehiculoById(long idVehiculo)
        {
            var vehiculos = connectionVehiculo.GetByidVehiculo(idVehiculo).OrderBy(s => s.idVehiculo).ToList();
            if (vehiculos != null)
            {
                imprimirVehiculo(vehiculos);
            }
            else
            {
                Console.WriteLine("No se encontraron vehiculos");
            }
        }

        public void GetVehiculoByMarca(String marca)
        {
            var vehiculos = connectionVehiculo.GetByMarca(marca).OrderBy(s => s.idVehiculo).ToList();
            if (vehiculos != null)
            {
                imprimirVehiculo(vehiculos);
            }
            else
            {
                Console.WriteLine("No se encontraron vehiculos");
            }
        }

        public void GetVehiculoByYear(String year)
        {
            var vehiculos = connectionVehiculo.GetByYearModelo(year).OrderBy(s => s.idVehiculo).ToList();
            if (vehiculos != null)
            {
                imprimirVehiculo(vehiculos);
            }
            else
            {
                Console.WriteLine("No se encontraron vehiculos");
            }
        }

        public void InsertVehiculo(Vehiculo vehiculo)
        {
            var logrado = connectionVehiculo.insertVehiculo(vehiculo);
            if (logrado)
            {
                Console.WriteLine("\nEl vehículo se agrego correctamente \n");
                var tmp = connectionVehiculo.GetAll().LastOrDefault();
                List<Vehiculo> aux = new List<Vehiculo>();
                aux.Add(tmp);
                imprimirVehiculo(aux);
            }
            else
            {
                Console.WriteLine("No se logro agregar el vehículo");
            }
        }

        public void UpdateRegistardoPor(long idVehiculo, Empleado empleado)
        {

            var logrado = connectionVehiculo.UpdateRegistardoPor(idVehiculo, empleado);
            if (logrado)
            {
                Console.WriteLine("\nEl vehículo se actualizo correctamente \n");
                GetVehiculoById(idVehiculo);
            }
            else
            {
                Console.WriteLine("No se logro actualizar el vehículo");
            }
        }

        public void imprimirVehiculo(List<Vehiculo> vehiculos)
        {
            if (vehiculos.Count != 0)
            {
                foreach (var vehiculo in vehiculos)
                {
                    Console.WriteLine(String.Format("ID del vehiculo: {0}\nFecha de Ingreso: {1}\nIdentificación Empleado: {2}\nMarca: {3}\nModelo: {4}" +
                        "\nAño: {5}\nDefectos: {6}\n",
                        vehiculo.idVehiculo, vehiculo.fechaIngreso.ToString("dd/MM/yyyy"), vehiculo.RegistardoPor.identificacion, vehiculo.Modelo.marcaVehiculo
                        , vehiculo.Modelo.modeloVehiculo, vehiculo.Modelo.yearModelo, "Defectos: \n"+String.Join("\n",vehiculo.Defectos)));
                }
            }
            else
            {
                Console.WriteLine("No se encontraron empleados");
            }
        }

        #endregion Vehiculo

        #region Pedido
        public void GetAllPedidos()
        {
            var pedidos = connectionPedido.GetAll().OrderBy(s => s.idPedido).ToList();
            if (pedidos != null)
            {
                imprimirPedido(pedidos);
            }
            else
            {
                Console.WriteLine("No se encontraron pedidos");
            }
        }

        public void GetPedidoById(long idPedido)
        {
            var pedidos = connectionPedido.GetByIdPedido(idPedido).OrderBy(s => s.idPedido).ToList();
            if (pedidos != null)
            {
                imprimirPedido(pedidos);
            }
            else
            {
                Console.WriteLine("No se encontro el pedido");
            }
        }

        public void GetPedidosByFechaInicio(String fecha)
        {
            int day = Int32.Parse(fecha[0]+""+fecha[1]);
            int month = Int32.Parse(fecha[3]+""+fecha[4]);
            int year = Int32.Parse(fecha[6]+""+fecha[7]+""+fecha[8] + "" + fecha[9]);
            DateTime date = new DateTime(year, month, day);
            var pedidos = connectionPedido.GetByFechaInicio(date).OrderBy(s => s.idPedido).ToList();
            if (pedidos != null)
            {
                imprimirPedido(pedidos);
            }
            else
            {
                Console.WriteLine("No se encontron el pedidos");
            }
        }

        public void GroupByEmpleado()
        {
            var groupBy = connectionPedido.GroupByEmpleado();
            if (groupBy != null)
            {
                if (groupBy.Count != 0)
                {
                    Console.WriteLine(String.Join("\n",groupBy));
                }
                else
                {
                    Console.WriteLine("No se encontron el pedidos");
                }
            }
            else
            {
                Console.WriteLine("No se encontron el pedidos");
            }
        }

        public void InsertPedido(Pedido pedido)
        {
            var logrado = connectionPedido.insertPedido(pedido);
            if (logrado)
            {
                Console.WriteLine("\nEl pedido se agrego correctamente \n");
                var tmp = connectionPedido.GetByIdPedido(pedido.idPedido).OrderBy(s => s.idPedido).ToList();
                imprimirPedido(tmp);
            }
            else
            {
                Console.WriteLine("No se logro agregar el pedido");
            }
        }

        public void UpdateEstadoPedido(long idPedido, int estado)
        {

            var logrado = connectionPedido.UpdateEstadoPedido(idPedido, estado);
            if (logrado)
            {
                Console.WriteLine("\nEl pedido se actualizo correctamente \n");
                GetPedidoById(idPedido);
            }
            else
            {
                Console.WriteLine("No se logro actualizar el pedido");
            }
        }

        public void imprimirPedido(List<Pedido> pedidos)
        {
            if (pedidos.Count != 0)
            {
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine(String.Format("ID del pedido: {0}\nIdentificación Cliente: {1}\nIdentificación Empleado: {2}\nFecha de Inicio: {3}\nFecha de Finalización: {4}" +
                        "\nMarca del Vehículo: {5}\nModelo del Vehículo: {6}\nEstado: {7}\n",
                        pedido.idPedido, pedido.cliente.identificacion, pedido.empleado.identificacion, pedido.fechaInicio.ToString("dd/MM/yyyy"),( pedido.fechaFinalizacion.HasValue ? pedido.fechaFinalizacion.Value.ToString("dd/MM/yyyy") : "N/A"), 
                        pedido.marcaVehiculo, pedido.modeloVehiculo, pedido.estado));
                }
            }
            else
            {
                Console.WriteLine("No se encontraron empleados");
            }
        }

        #endregion Pedido

        #region menus
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
            Console.WriteLine("5.  Actualizar el teléfono de un cliente");
            Console.WriteLine("X.  Salir");
        }

        private void DesplegarMenuEmpleado()
        {
            Console.WriteLine("Menu Empleado");
            Console.WriteLine("1.  Listar todos los empleados");
            Console.WriteLine("2.  Buscar empleado por idEmpleado");
            Console.WriteLine("3.  Buscar empleado por identificación");
            Console.WriteLine("4.  Insertar un empleado");
            Console.WriteLine("5.  Actualizar la fecha de contratación de un empleado");
            Console.WriteLine("X.  Salir");
        }

        private void DesplegarMenuVehiculo()
        {
            Console.WriteLine("Menu Vehiculo");
            Console.WriteLine("1.  Listar todos los vehiculos");
            Console.WriteLine("2.  Buscar vehiculo por idVehiculo");
            Console.WriteLine("3.  Buscar vehiculos por fecha de ingreso");
            Console.WriteLine("4.  Buscar vehiculos por marca");
            Console.WriteLine("5.  Buscar vehiculos por año");
            Console.WriteLine("6.  Insertar un vehiculo");
            Console.WriteLine("7.  Actualizar registrado por...");
            Console.WriteLine("X.  Salir");
        }

        private void DesplegarMenuPedido()
        {
            Console.WriteLine("Menu Pedido");
            Console.WriteLine("1.  Listar todos los pedidos");
            Console.WriteLine("2.  Buscar pedido por idPedido");
            Console.WriteLine("3.  Buscar pedido por fecha de inicio");
            Console.WriteLine("4.  GroupByEmpleado");
            Console.WriteLine("5.  Insertar un pedido");
            Console.WriteLine("6.  Actualizar el estado");
            Console.WriteLine("X.  Salir");
        }

        #endregion menus

        private string LeaLaOpcion()
        {
            string elResultado = Console.ReadLine();
            return elResultado;
        }
    }
}
