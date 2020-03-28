using System;
using System.Collections.Generic;

namespace ITLA_ATM
{

    class LOGIN
    {
        public static List<C_usuarios> usuario = new List<C_usuarios>(); // este list tiene los datos de los usuarios
        public static List<C_transacciones> log_trans = new List<C_transacciones>();
        public static string nombre_banco = "Banco popular";
        public static int usuario_en_uso; //Esta variable se va a utilizar para saber cual es el usuario que esta en uso
        //con esta validaremos que el admin no realice ningun cambio a el mismo
        public static int intentos = 0;

        static void Main(string[] args)
        {

            // Aqui estan algunos usuarios de prueba
            usuario. Add(new C_usuarios { numero_tarjeta = "0000-0000-0000-0000", nombre = "Angel", apellido = "Lopez", contra = "0000", saldo = 3000, isadmin = true });
            usuario.Add(new C_usuarios { numero_tarjeta = "1111-1111-1111-1111", nombre = "José", apellido = "Doñe", contra = "0001", saldo = 4000, isactive = true });

            // Agregando datos a la lista de empresas de tarjetas
            ATM.EmpresaTarjetas.Add("Claro");
            ATM.EmpresaTarjetas.Add("Altice");
            ATM.EmpresaTarjetas.Add("Viva");

            // Agregando datos a la lista de montos de tarjetas
            ATM.MontosTarjetas.Add(60);
            ATM.MontosTarjetas.Add(100);
            ATM.MontosTarjetas.Add(150);
            ATM.MontosTarjetas.Add(200);
            ATM.MontosTarjetas.Add(250);


            Menu();


        }
        public static void Menu()
        {
            try
            {
                
                Console.Clear();
                Console.WriteLine("ATM "+nombre_banco.ToUpper());
                
                Console.WriteLine("INGRESE SU NUMERO DE TARJETA (####-####-####-####)");
                string tarjeta = Console.ReadLine();
                usuario_en_uso = 0;

                foreach (var item in usuario)
                {
                    if (item.numero_tarjeta == tarjeta)//Aqui validamos las tarjetas existentes, con las que tenemos en el sistema
                    {
                        Console.WriteLine("Digite la contraseña");

                        // variable string para almacenar contraseña
                        string contra ="";

                        // Ciclo do while paara validar cada letra
                        do
                        {
                            // Usar console read key para leer letra por letra en ves de escribirla en pantalla
                            ConsoleKeyInfo key = Console.ReadKey(true);

                            // Declaracion if para no borrar y validar que letra no sea enter
                            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                            {
                                /* Sumar cada letra a la variable sin escribirla en la consola */
                                contra += key.KeyChar;

                                /* Escribir un * en lugar de la letra presionada */
                                Console.Write("*");

                            }
                            // Condicion para aceptar enter y romper en ciclo
                            else if (key.Key == ConsoleKey.Enter)
                            {
                                    break;
                            }
                        } while (true);



                        if (item.contra == contra)
                        {
                            if (item.isadmin == true)//Aqui validamos si la persona es un administrador
                            {
                                Console.WriteLine(Environment.NewLine + "BIENVENIDO");
                                Console.ReadKey();
                                Console.Clear();
                                Menu_admin.Menu();

                                break;
                            }
                            else if (item.isadmin == false)//si es un cliente se ira al menu de clientes
                            {
                                if(item.isactive == true)
                                {
                                    Console.WriteLine(Environment.NewLine + "BIENVENIDO");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Menu_cliente.Menu();

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Este usuario ha sido bloqueado, por favor contactar al administrador");
                                    Console.ReadKey();
                                    Menu();
                                }
                            }



                        }
                        else
                        {
                            intentos++;
                            if(intentos == 2)
                            {
                                item.isactive = false;
                                Console.WriteLine("Este usuario ha sido bloqueado, por favor contactar al administrador");
                                Console.ReadKey();
                                intentos = 0;
                                Menu();
                            }
                            else { 
                            Console.WriteLine("Contraseña invalida, vuelva a intentarlo");
                            Console.ReadKey();
                            Console.Clear();
                            Menu();
                            }
                        }
                    }

                    usuario_en_uso++;


                }
                Console.WriteLine("# DE TARJETA INVALIDO");
                Console.ReadKey();
                Console.Clear();
                Menu();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Menu();
            }
        }
    }
}
