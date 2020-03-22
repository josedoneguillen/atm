using System;
using System.Collections.Generic;

namespace ITLA_ATM
{

    class Program
    {
        public static List<C_usuarios> usuario = new List<C_usuarios>(); // este list tiene los datos de los usuarios


        static void Main(string[] args)
        {

            usuario.Add(new C_usuarios { numero_tarjeta = "123456", nombre = "Angel", apellido = "Lopez", contra = "Pedro809", saldo = 3000, isadmin = true });
            usuario.Add(new C_usuarios { numero_tarjeta = "1234567", nombre = "Angel", apellido = "Lopez", contra = "papirata", saldo = 4000 });
            //Aqui arriba estan algunos usuarios de prueba



            Menu();


        }
        public static void Menu()
        {
            try
            {
                Console.WriteLine("ATM");
                Console.WriteLine("INGRESE SU NUMERO DE TARJETA");
                string tarjeta = Console.ReadLine();
                foreach (var item in usuario)
                {
                    if (item.numero_tarjeta == tarjeta)//Aqui validamos las tarjetas existentes, con las que tenemos en el sistema
                    {
                        Console.WriteLine("Digite la contraseña");
                        string contra = Console.ReadLine();
                        if (item.contra == contra)
                        {
                            if (item.isadmin == true)//Aqui validamos si la persona es un administrador
                            {
                                Console.WriteLine("BIENVENIDO");
                                Console.ReadKey();
                                Console.Clear();
                                Menu_admin.Menu();
                            }
                            else if (item.isadmin == false)//si es un cliente se ira al menu de clientes
                            {
                                Console.WriteLine("BIENVENIDO");
                                Console.ReadKey();
                                Console.Clear();
                                Menu_cliente.Menu();
                            }



                        }
                        else
                        {
                            Console.WriteLine("Contraseña invalida, vuelva a intentarlo");
                            Console.ReadKey();
                            Console.Clear();
                            Menu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usuario invalido, vuelva a intentarlo");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Dato erroneo");
            }
        }
    }
}
