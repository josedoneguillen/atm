using System;
using System.Collections.Generic;

namespace ITLA_ATM
{

    class Program
    {
        public static List<C_usuarios> usuario = new List<C_usuarios>(); // este list tiene los datos de los usuarios

        static void Main(string[] args)
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
                            }
                            else//si es un cliente se ira al menu de clientes
                            {
                                Console.WriteLine("BIENVENIDO");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
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
