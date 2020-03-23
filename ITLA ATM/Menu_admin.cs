using System;
using System.Collections.Generic;
using System.Text;

namespace ITLA_ATM
{
    class Menu_admin
    {
        enum menu_admin { agregar_cli = 1,
            editar_cli,
            eliminar_cli,
            reiniciar_contra,
            agregar_saldo,
            log_trans,
            configurar_atm,
            administrar_usuarios,
            reactivar_usuarios,
            cerrar_sesion }
        
        public static void Menu()
        {
            
            Console.Clear();
            Console.WriteLine("MENU DEL ADMINISTRADOR");
            Console.WriteLine("Elija una opcion \n1-Agregar cliente \n2-Editar cliente \n3-Eliminar cliente \n4-Reiniciar contraseña \n5-Agregar Saldo");
            Console.WriteLine("6-Log de trasnacciones \n7-Configuracion del ATM \n8-Administrar usuarios \n9-Reactivacion de usuario \n10-Cerrar sesion");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case (int)menu_admin.agregar_cli:
                    agregar_cliente();
                    break;
                case (int)menu_admin.editar_cli:
                    break;
                case (int)menu_admin.eliminar_cli:
                    break;
                case (int)menu_admin.reiniciar_contra:
                    break;
                case (int)menu_admin.agregar_saldo:
                    break;
                case (int)menu_admin.log_trans:
                    break;
                case (int)menu_admin.configurar_atm:
                    break;
                case (int)menu_admin.administrar_usuarios:
                    break;
                case (int)menu_admin.reactivar_usuarios:
                    break;
                case (int)menu_admin.cerrar_sesion:
                    LOGIN.Menu();
                    break;
            }
            Console.ReadKey();
        }
        public static void agregar_cliente()//Aqui agregamos a los cliente
        {
            Console.Clear();
            Console.WriteLine("AGREGAR UN CLIENTE \n# de la tarjeta");
            string tarjeta = Console.ReadLine();
            while (tarjeta.Length < 16 || tarjeta.Length>16)//Aqui verificamos que la tarjeta tenga no menos de 16 digitos y no mas de 16 tambien
            
            {
                Console.WriteLine("La numeracion de la tarjeta no es correcta, vuelva a intentarlo");
                tarjeta = Console.ReadLine();
            }
            foreach(var item in LOGIN.usuario)
            {
                if(item.numero_tarjeta == tarjeta)
                {
                    Console.WriteLine("Esta tarjeta ya esta registrada en el sistema");
                }
            }
            Console.WriteLine("Nombre del cliente");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido");
            string apellido = Console.ReadLine();
            Console.WriteLine("contraseña");
            string contra = Console.ReadLine();
            Console.WriteLine("Saldo inicial");
            double saldo_ini = Convert.ToDouble(Console.ReadLine());
            while (saldo_ini < 500)//Aqui declaramos el saldo minimo para apertura de la cuenta
            
            {
                int a = 0;
                Console.WriteLine("El saldo minimo es de RD$500 \n1-Digitar un nuevo saldo \n2-Volver al menu");
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)//Aqui le damos la opcion para digitar un nuevo saldo inicial o volver al menu
                {
                    case 1:
                        Console.WriteLine("Saldo inicial");
                        saldo_ini = Convert.ToDouble(Console.ReadLine());
                        break;
                    case 2:
                        Menu();
                        break;
                }
                
            }
            C_usuarios clientes = new C_usuarios(); //Creamos un objeto del tipo de la clase para poder almacenar los datos
            clientes.numero_tarjeta = tarjeta;
            clientes.nombre = nombre;
            clientes.apellido = apellido;
            clientes.contra = contra;
            clientes.saldo = saldo_ini;
            LOGIN.usuario.Add(clientes);//Aqui llenamos el list con los datos que estas almacenados en el objeto del tipo de la clase usuarios
            Console.WriteLine("\nCliente agregado con exito!!!");
            Console.ReadKey();
            Menu();

            
        }
        
        

    }
}





