﻿using System;
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

        /* Declaracion de estructura de denominaciones */

        public struct Denominacion {
            public int denominacion { get; set; }
            public int cantidad { get; set; }
        }

        /* Declaracion de lista de denominaciones */
        public static List<Denominacion> Denominaciones = new List<Denominacion>();

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
                        
                        break;

                    case (int)MenuClientEnum.DEPOSITAR:
                        DepositarEfectivo();
                        break;

                    case (int)MenuClientEnum.COMPRAR_TARJETA:
                        
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
        public static void cambiar_nombre_banco()//ESTA OPCION SERA AÑADIDA A LAS CONFIGURACIONES DEL ATM
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
        public static void papeletas_200_1000()
        {
            try
            {
                int retiro = 0, prueba, multiplo;

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

        // Metodo para ver balance del cliente
        public static void ConsultarBalance() 
        {
            // Imprimir balance disponible por el cliente
            Console.WriteLine("Su balance es de RD$ " + LOGIN.usuario[LOGIN.usuario_en_uso].saldo);
        }

        // Metodo para ver balance del cliente
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

            }
            catch (Exception e) {
                Console.WriteLine(e.Message + "VOLVIENDO AL MENU...");
                MenuCliente();
            }

            
        }
    }
}
