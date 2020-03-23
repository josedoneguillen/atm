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
        enum edit_cliente
        {
            volver_intentar=1,
            volver_menu
        }
        enum reiniciar_contrasena
        {
            reiniciar =1,
            cliente_incorrecto
        }
        public static void Menu()
        {
            try {
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
                        editar_cliente();
                        break;
                    case (int)menu_admin.eliminar_cli:
                        eliminar_cliente();
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
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                Menu();
            }
            Console.ReadKey();
        }
        public static void agregar_cliente()//Aqui agregamos a los cliente
        {
            try {
                Console.Clear();
                Console.WriteLine("AGREGAR UN CLIENTE \n# de la tarjeta");
                string tarjeta = Console.ReadLine();
                while (tarjeta.Length < 16 || tarjeta.Length > 16)//Aqui verificamos que la tarjeta tenga no menos de 16 digitos y no mas de 16 tambien

                {
                    Console.WriteLine("La numeracion de la tarjeta no es correcta, vuelva a intentarlo");
                    tarjeta = Console.ReadLine();
                }
                foreach (var item in LOGIN.usuario)
                {
                    if (item.numero_tarjeta == tarjeta)
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

            catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                Menu();
            }
        }
        public static void editar_cliente() // editar clientes
        {
            try {
                Console.Clear();
                Console.WriteLine("EDITAR CLIENTE \nINGRESE EL # DE LA TARJETA");
                string tarjeta = Console.ReadLine();
                while (tarjeta.Length < 16 || tarjeta.Length > 16)//Aqui verificamos que la tarjeta tenga no menos de 16 digitos y no mas de 16 tambien

                {
                    Console.WriteLine("Este numero de tarjeta no cumple con el maximo o minimo de caracteres");
                    Console.ReadKey();
                    editar_cliente();
                }
                foreach (var item in LOGIN.usuario)//Aqui buscamos la tarjeta que fue digitada
                {
                    if (item.numero_tarjeta == tarjeta)
                    {
                        Console.WriteLine("Nombre : " + item.nombre + " Apellido : " + item.apellido + " # de tarjeta : " + item.numero_tarjeta);
                        Console.WriteLine("Nuevo nombre");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Nuevo apellido");
                        string apellido = Console.ReadLine();
                        item.nombre = nombre;
                        item.apellido = apellido;
                        Console.WriteLine("USUARIO EDITADO CON EXITO!!");
                        Menu();
                    }

                }
                Console.WriteLine("# de tarjeta no existe \n1-Nueva busqueda \n2-Ir al menu anterior");
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case (int)edit_cliente.volver_intentar:
                        editar_cliente();
                        break;
                    case (int)edit_cliente.volver_menu:
                        Menu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                Menu();
            }

        }

        public static void eliminar_cliente()//Eliminar cliente
        {
            try {
                Console.Clear();
                Console.WriteLine("ELIMINAR CLIENTE \nDigite el # de tarjeta");
                string tarjeta = Console.ReadLine();
                int contador = 0;
                foreach (var item in LOGIN.usuario)
                {

                    if (item.numero_tarjeta == tarjeta)
                    {
                        Console.WriteLine("Seguro que desea eliminar este usuario?\nS/N");
                        string opcion = Console.ReadLine();
                        switch (opcion)
                        {
                            case "S":
                                LOGIN.usuario.RemoveAt(contador);
                                Console.WriteLine("CLIENTE ELIMINADO!!");
                                Menu();
                                break;
                            case "N":
                                Menu();
                                break;
                        }
                    }
                    contador++;
                }
                Console.WriteLine("Esta tarjeta no existe \nDesea volver a intentarlo? S/N");
                string opcion2 = Console.ReadLine();
                switch (opcion2)
                {
                    case "S":
                        eliminar_cliente();
                        Menu();
                        break;
                    case "N":
                        Menu();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                Menu();
            }
            
        }
        public static void reiniciar_contra()//Aqui reiniciamos la contraseña
        {
            try
            {
                Console.Clear();
                Console.WriteLine("REINICIAR CONTRASEÑA \nDigite el # de tarjeta del cliente");
                string tarjeta = Console.ReadLine();
                foreach (var item in LOGIN.usuario)//aqui recorremos todas las terjeta a ver si encontramos la que queremo
                {
                    if (item.numero_tarjeta == tarjeta)
                    {
                        Console.WriteLine("Nomber : "+item.nombre+" Apellido : "+item.apellido);
                        Console.WriteLine("Este es el cliente correcto? S/N");
                        string a = Console.ReadLine();
                        switch (a)//Aqui le confirmamos al cliente si los datos cainciden con el cliente que busca
                        {
                            case "S"://si es correcto, cambiamos la contrasena
                                Console.WriteLine("Digite la nueva contraseña");
                                string nueva_contra = Console.ReadLine();
                                item.contra = nueva_contra;
                                Console.WriteLine("CONTRASEÑA CONFIGURADA");
                                Menu();
                                break;
                            case "N"://si no es correcto volvemos al menu
                                Console.WriteLine("VOLVIENDO AL MENU . . .");
                                Console.ReadKey();
                                Menu();
                                break;
                            default:
                                Console.WriteLine("OPCION INVALIDA");
                                Console.WriteLine("VOLVIENDO AL MENU . . .");
                                Console.ReadKey();
                                Menu();
                                break;
                        }
                    }
                }
                //Si no encontramos coincidencia, entonces salimos del bucle y preguntamos lo siguiente
                Console.WriteLine("# de tarjeta no ha sido encontrado \nDesea realizar otra busqueda? S/N");
                string aa = Console.ReadLine();
                switch (aa)
                {
                    case "S":
                        reiniciar_contra();
                        break;
                    case "N":

                        Console.WriteLine("VOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("OPCION INVALIDA");
                        Console.WriteLine("VOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        Menu();
                        break;
                }
            }
               catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                Menu();
            }
        }

        public static void agregar_saldo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("AGREGAR SALDO \nDigite el # de tarjeta");
                string tarjeta = Console.ReadLine();
                foreach (var item in LOGIN.usuario)
                {
                    if(item.numero_tarjeta == tarjeta)
                    {
                        Console.WriteLine("Nombre : " + item.nombre + " Apellido : " + item.apellido);
                        Console.WriteLine("Cliente corrento? S/N");
                        string a = Console.ReadLine();
                        switch (a)
                        {
                            case "S":
                                //Aqui va lo que pasa si el cliente es correcto
                                break;
                            case "N":
                                Console.WriteLine("VOLVIENDO AL MENU . . .");
                                Console.ReadKey();
                                Menu();
                                break;
                        }
                    }
                }
                //Si no encontramos coincidencia, entonces salimos del bucle y preguntamos lo siguiente
                Console.WriteLine("# de tarjeta no ha sido encontrado \nDesea realizar otra busqueda? S/N");
                string aa = Console.ReadLine();
                switch (aa)
                {
                    case "S":
                        reiniciar_contra();
                        break;
                    case "N":

                        Console.WriteLine("VOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("OPCION INVALIDA");
                        Console.WriteLine("VOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        Menu();
                        break;
                }

            }
               catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                Menu();
            }
        }
    }
}





