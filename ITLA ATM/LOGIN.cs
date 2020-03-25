using System;
using System.Collections.Generic;

namespace ITLA_ATM
{

    class LOGIN
    {
        public static List<C_usuarios> usuario = new List<C_usuarios>(); // este list tiene los datos de los usuarios
        public static List<C_transacciones> log_trans = new List<C_transacciones>();
        public static string nombre_banco = "Banco popular";
        public static string usuario_en_uso; //Esta variable se va a utilizar para saber cual es el usuario que esta en uso
        //con esta validaremos que el admin no realice ningun cambio a el mismo
        public static int intentos = 0;

        static void Main(string[] args)
        {
            
            usuario. Add(new C_usuarios { numero_tarjeta = "123456", nombre = "Angel", apellido = "Lopez", contra = "Pedro809", saldo = 3000, isadmin = true });
            usuario.Add(new C_usuarios { numero_tarjeta = "1234567", nombre = "Angel", apellido = "Lopez", contra = "papirata", saldo = 4000, isactive = true });
            //Aqui arriba estan algunos usuarios de prueba

            

            Menu();


        }
        public static void Menu()
        {
            try
            {
                
                Console.Clear();
                Console.WriteLine("ATM "+nombre_banco.ToUpper());
                
                Console.WriteLine("INGRESE SU NUMERO DE TARJETA");
                string tarjeta = Console.ReadLine();
                usuario_en_uso = tarjeta;
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
                                if(item.isactive == true)
                                {
                                    Console.WriteLine("BIENVENIDO");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Menu_cliente.Menu();
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
