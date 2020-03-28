using System;
using System.Collections.Generic;
using System.Text;

namespace ITLA_ATM
{
    class ATM
    {
        /* Declaracion de enum para menu de cliente */
        enum MenuClientEnum
        {
            RETIRAR = 1,
            DEPOSITAR,
            COMPRAR_TARJETA,
            CONSULTAR_BALANCE,
            SALIR
        }

        /* Declaracion de enum para menu de configuracion */
        enum MenuConfigEnum
        {
            CAMBIAR_NOMBRE_BANCO = 1,
            MODO_DE_DISPENSACION,
            VOLVER
        }

        /* Declaracion de lista de denominaciones */
        public static List<Denominacion> Denominaciones = new List<Denominacion>();

        /* Declaracion de estructura de denominaciones */

        public struct Denominacion {
            public int denominacion { get; set; }
            public int cantidad { get; set; }
        }

        /* Declaracion de lista de para empresas de tarjetas */
        public static List<string> EmpresaTarjetas = new List<string>();

        /* Declaracion de lista de para monto de tarjetas */
        public static List<int> MontosTarjetas = new List<int>();

        /* Metodo para desplegar menu de cliente */
        public static void MenuCliente()
        {

            try
            {
                int opcion = 0;
                Console.Clear();
                Console.WriteLine("Bienvenido, " + LOGIN.usuario[LOGIN.usuario_en_uso].nombre + " " + LOGIN.usuario[LOGIN.usuario_en_uso].apellido);
                Console.WriteLine("MENU DE CONFIGURACION DE ATM");
                Console.WriteLine("Elija una opcion \n1-Retirar efectivo \n2-Depositar efectivo  \n3-Comprar tarjeta de llamada \n4-Consultar balance \n5-Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case (int)MenuClientEnum.RETIRAR:
                        RetiroEfectivo();
                        break;

                    case (int)MenuClientEnum.DEPOSITAR:
                        DepositarEfectivo();
                        break;

                    case (int)MenuClientEnum.COMPRAR_TARJETA:
                        ComprarTarjetas();
                        break;

                    case (int)MenuClientEnum.CONSULTAR_BALANCE:
                        ConsultarBalance();
                        break;

                    case (int)MenuClientEnum.SALIR:
                        LOGIN.Menu();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida \nVOLVIENDO AL MENU . . .");
                        MenuConfig();
                        break;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nvolviendo al menu . . .");
                Console.ReadKey();
                MenuCliente();
            }
        }

        /* Metodo para desplegar menu de configuracion */
        public static void MenuConfig() 
        {
            
                try
                {
                    int opcion = 0;
                    Console.Clear();
                    Console.WriteLine("Bienvenido, " + LOGIN.usuario[LOGIN.usuario_en_uso].nombre + " " + LOGIN.usuario[LOGIN.usuario_en_uso].apellido);
                    Console.WriteLine("MENU DE CONFIGURACION DE ATM");
                    Console.WriteLine("Elija una opcion \n1-Cambiar nombre del banco \n2-Cambiar modo de dispensacion  \n3-Volver");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case (int)MenuConfigEnum.CAMBIAR_NOMBRE_BANCO:
                        cambiar_nombre_banco();
                            break;

                    case (int)MenuConfigEnum.MODO_DE_DISPENSACION:
                        papeletas_200_1000();
                        break;

                    case (int)MenuConfigEnum.VOLVER:
                        LOGIN.Menu();
                        break;
                    default:
                            Console.WriteLine("Opcion invalida \nVOLVIENDO AL MENU . . .");
                            MenuConfig();
                            break;
                    }
                }

                catch (Exception e)
                {
                Console.WriteLine(e.Message + "\nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                MenuConfig();
            }
            }

        // Metodo para cambiar nombre del banco
        public static void cambiar_nombre_banco()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Esta seguro que desea cambiar el nombre del banco? S/N");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "S":
                        Console.WriteLine("ingrese el nuevo nombre del banco");
                        string nombre = Console.ReadLine();
                        LOGIN.nombre_banco = nombre;
                        Console.WriteLine("EL NUEVO NOMBRE DEL BANCO ES :" + LOGIN.nombre_banco);
                        Console.ReadKey();
                        MenuConfig();
                        break;
                    case "N":
                        Console.WriteLine("VOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        MenuConfig();
                        break;
                    default:
                        Console.WriteLine("OPCION INVALIDA");
                        Console.WriteLine("VOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        MenuConfig();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                MenuConfig();
            }

        }

        //Metodo para cambiar dispensacion de billetes
        public static void papeletas_200_1000(int retiro = 0) 
        {
            try
            {
                int prueba, multiplo;

                prueba = retiro % 1000;
                if (prueba == 0 || prueba == 200 || prueba == 400 || prueba == 600 || prueba == 800)//Aqui decimos que si el reciduo de lo que esta arriba es uno de esos resultadod
                                                                                                    //es porque es un multiplo de mil y tiene tambien un multiplo de 200, asi que podemos procesar el cobro
                {
                    multiplo = retiro / 1000;
                    multiplo = multiplo * 1000;
                    retiro = retiro - multiplo;
                    retiro = retiro - retiro;
                    Console.WriteLine(retiro);
                }
                else if (retiro % 200 == 0) //Aqui decimos que si es un multiplo de 200 entonces el residuo sera 0 por lo cual podremos dispensar de a billites de 200
                {
                    retiro = retiro - retiro;
                    Console.WriteLine(retiro);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                MenuConfig();
            }
        }
        //Metodo para cambiar retirar efectivo
        public static void RetiroEfectivo()
        {


            //Uso de try catch para evitar errores
            try
            {
                // Solicitar al cliente la cantidad que desea depositar
                Console.WriteLine("Ingrese la cantidad a retirar:");

                // Almacenar la cantidad a retirar
                int retiro = Convert.ToInt32(Console.ReadLine());

                // Comprobar si la cuenta tiene suficiente como para realizar la compra
                if (LOGIN.usuario[LOGIN.usuario_en_uso].saldo >= retiro)
                {

                    // Imprimir resultados
                    Console.WriteLine("Monto a retirar:" + retiro);
                    Console.WriteLine("Balance Anterior:" + LOGIN.usuario[LOGIN.usuario_en_uso].saldo);

                    // Debitar cantidad del retiro de la cuenta
                    LOGIN.usuario[LOGIN.usuario_en_uso].saldo -= retiro;

                    Console.WriteLine("Nuevo Balance:" + LOGIN.usuario[LOGIN.usuario_en_uso].saldo);
                }

                // Esperar para volver
                Console.ReadKey();
                MenuCliente();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "VOLVIENDO AL MENU...");
                Console.ReadKey();
                MenuCliente();
            }


        }

        // Metodo para ver balance del cliente
        public static void ConsultarBalance() 
        {
            // Imprimir balance disponible por el cliente
            Console.WriteLine("Su balance es de RD$ " + LOGIN.usuario[LOGIN.usuario_en_uso].saldo);
        }

        // Metodo para ver depositar en la cuenta del cliente
        public static void DepositarEfectivo()
        {
            // Solicitar al cliente la cantidad que desea depositar
            Console.WriteLine("Ingrese la cantidad que desea depositar: ");

            //Uso de try catch para evitar errores
            try
            {
                double cant = Convert.ToDouble(Console.ReadLine());

                // Aumentar cantidad al saldo del cliente
                LOGIN.usuario[LOGIN.usuario_en_uso].saldo += cant;

                //Mostrar mensaje de deposito exitoso y saldo actual
                Console.WriteLine("El deposito fue exitoso");
                ConsultarBalance();

                // Esperar para volver
                Console.ReadKey();
                MenuCliente();

            }
            catch (Exception e) {
                Console.WriteLine(e.Message + "VOLVIENDO AL MENU...");
                Console.ReadKey();
                MenuCliente();
            }
        }

        // Metodo para comprar tarjetas de llamada
        public static void ComprarTarjetas()
        {

            //Uso de try catch para evitar errores
            try
            {
                // Solicitar al cliente la cantidad que desea depositar
                Console.WriteLine("Seleccione la compañía de la cual quiere comprar la tarjeta:");

                // Contador de empresa
                int EmpresaCount = 0;

                // Recorrer lista de empresas para imprimir opciones
                foreach (string empresa in EmpresaTarjetas)
                {
                    Console.WriteLine((EmpresaCount+1) + "- " + empresa);

                    // Incrementar contador
                    EmpresaCount++;

                }

                // Almacenar la opcion de empresa elegida
                int EmpresaOpcion = Convert.ToInt32(Console.ReadLine());

                // Solicitar al cliente la cantidad que desea depositar
                Console.WriteLine("Seleccione el monto de la tarjeta que quiere comprar:");

                // Contador de empresa
                int MontoCount = 0;

                // Recorrer lista de empresas para imprimir opciones
                foreach (int monto in MontosTarjetas)
                {
                    Console.WriteLine((EmpresaCount + 1) + "- " + monto);

                    // Incrementar contador
                    MontoCount++;
                }

                // Almacenar la opcion de empresa elegida
                int MontoOpcion = Convert.ToInt32(Console.ReadLine());

                // Comprobar si la cuenta tiene suficiente como para realizar la compra
                if (LOGIN.usuario[LOGIN.usuario_en_uso].saldo >= MontosTarjetas[MontoOpcion-1])
                {
                    
                    // Imprimir resultados
                    Console.WriteLine("Compañia de telefono:" + EmpresaTarjetas[EmpresaOpcion - 1]);
                    Console.WriteLine("Monto de la tarjeta:" + MontosTarjetas[MontoOpcion - 1]);
                    Console.WriteLine("Balance Anterior:" + LOGIN.usuario[LOGIN.usuario_en_uso].saldo);

                    // Debitar cantidad de la compra a la cuenta
                    LOGIN.usuario[LOGIN.usuario_en_uso].saldo -= MontosTarjetas[MontoOpcion - 1];

                    Console.WriteLine("Nuevo Balance:" + LOGIN.usuario[LOGIN.usuario_en_uso].saldo);
                }

                // Esperar para volver
                Console.ReadKey();
                MenuCliente();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "VOLVIENDO AL MENU...");
                Console.ReadKey();
                MenuCliente();
            }


        }


    }
}
