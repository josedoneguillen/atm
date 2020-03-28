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
        enum gestion_admin
        {
            crear =1,
            editar,
            listar,
            eliminar,
            volver_al_menu

        }

        public static int numero_de_trans;
        public static void Menu()
        {
            try {
                int opcion = 0;
                Console.Clear();
                Console.WriteLine("Bienvenido, " + LOGIN.usuario[LOGIN.usuario_en_uso].nombre + " " + LOGIN.usuario[LOGIN.usuario_en_uso].apellido);
                Console.WriteLine("MENU DEL ADMINISTRADOR");
                Console.WriteLine("Elija una opcion \n1-Agregar cliente \n2-Editar cliente \n3-Eliminar cliente \n4-Reiniciar contraseña \n5-Agregar Saldo");
                Console.WriteLine("6-Log de trasnacciones \n7-Configuracion del ATM \n8-Administrar usuarios \n9-Reactivacion de usuario \n10-Cerrar sesion");
                opcion = Convert.ToInt32(Console.ReadLine());
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
                        reiniciar_contra();
                        break;
                    case (int)menu_admin.agregar_saldo:
                        agregar_saldo();
                        break;
                    case (int)menu_admin.log_trans:
                        log_trans();
                        break;
                    case (int)menu_admin.configurar_atm:
                        ATM.MenuConfig();
                        break;
                    case (int)menu_admin.administrar_usuarios:
                        administrar_usuario();

                        break;
                    case (int)menu_admin.reactivar_usuarios:
                        reactivar_usuario();
                        break;
                    case (int)menu_admin.cerrar_sesion:
                        LOGIN.Menu();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida \nVOLVIENDO AL MENU . . .");
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
                    Console.ReadKey();
                    agregar_cliente();
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
                clientes.isactive = true;
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

        public static void agregar_saldo()//Aqui agragamos saldo
        {
            
            try
            {
                DateTime fecha = DateTime.Now;
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

                            case "S": //Aqui es donde se procesa la transaccion
                                
                                numero_de_trans++; 
                                Console.WriteLine("balance actual : " + item.saldo);
                                Console.WriteLine("Ingrese el monto a depositar");
                                double monto = Convert.ToDouble(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Nombre : "+item.nombre+" Apellido : "+item.apellido);
                                Console.WriteLine("Deposito : "+monto+"\nBalance anterior :"+item.saldo);
                                //Aqui debajo es donde se realiza el registro de todas las transacciones utilizando la clase de transacciones
                                LOGIN.log_trans.Add(new C_transacciones {nombre_banco = LOGIN.nombre_banco.ToUpper(), fecha_trans = Convert.ToString(fecha) ,numero_transacciones = numero_de_trans , numero_tarjeta = item.numero_tarjeta, tipo_transaccion = "Deposito", monto_transacciones = monto, balance_anterio = item.saldo, balance_nuevo = item.saldo = item.saldo + monto }) ;
                                
                                Console.WriteLine("======================================");
                                Console.WriteLine("Nuevo balance : "+item.saldo);
                                Console.ReadKey();
                                Menu();
                                

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
                        agregar_saldo();
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

        public static void log_trans() //Log de trans
        {
            try
            {
                bool encontro=false; //esta variiable la usaremos para saber si se encontro un cliente con la tarjeta digitada
                Console.Clear();
                Console.WriteLine("LOG DE TRANSACCIONES \nDigite el # de tarjeta");
                string tarjeta = Console.ReadLine();
                foreach (var item in LOGIN.log_trans)
                {
                    if(item.numero_tarjeta == tarjeta)//Aqui buscamos segun la tarjeta
                    {
                        
                        Console.WriteLine("*"+LOGIN.nombre_banco.ToUpper()+"*"+"\nTipo de transaccion : "+item.tipo_transaccion+"  Fecha  "+item.fecha_trans+"\n# de transaccion : "+item.numero_transacciones+"\n=========================\nCantidad depositada : "+item.monto_transacciones);
                        Console.WriteLine("Balance anterior : "+item.balance_anterio+" Nuevo balance : "+item.balance_nuevo+ "\n=========================");

                        encontro = true;//Aqui validamos que encontramos a un cliente
                    }
                    
                }

                if(encontro == false)
                {
                    Console.WriteLine("# de tarjeta no ha sido encontrado \nDesea realizar otra busqueda? S/N");
                    string aa = Console.ReadLine();
                    switch (aa)
                    {
                        case "S":
                            log_trans();
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
                else {
                    Console.ReadKey();
                    Menu();
                }
                

                
                

            }

               catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                Menu();
            }
        }
       
        public static void administrar_usuario()//Menu para editar usuarios de tipo admin
        {
            try {
                Console.Clear();
            Console.WriteLine("ADMINISTRAR USUARIO \n1-Crear admin \n2-Editar admin \n3-Listar \n4-Eliminar admin \n5-Volver al menu");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case (int)gestion_admin.crear:
                        crear_admin();
                    break;
                case (int)gestion_admin.editar:
                        editar_admin();
                    break;
                case (int)gestion_admin.listar:
                        listar_admin();
                    break;
                case (int)gestion_admin.eliminar:
                        eliminar_admin();
                    break;
                    case (int)gestion_admin.volver_al_menu:
                        Menu();
                        break;
                default:
                    Console.WriteLine("Opcion invalida . . .");
                    Console.ReadKey();
                    administrar_usuario();
                    break;
            }
                }
            catch (Exception ex)
            {
                Console.WriteLine("Error \nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                Menu();
            }

        }

        public static void crear_admin()//crear admins
        {
            try
            {
                Console.Clear();
                Console.WriteLine("CREAR ADMIN");
                Console.WriteLine("Digite numero de tarjeta del admin");
                string tarjeta = Console.ReadLine();
                while (tarjeta.Length < 16 || tarjeta.Length > 16)//Aqui verificamos que la tarjeta tenga 16 digitos//Aqui verificamos que la tarjeta tenga no menos de 16 digitos y no mas de 16 tambien

                {
                    Console.WriteLine("La numeracion de la tarjeta no es correcta, vuelva a intentarlo");
                    Console.ReadKey();
                    crear_admin();
                }
                foreach(var item in LOGIN.usuario)//Aqui validamos que la tarjeta intruducida no este en uso, de estarlo, volvera al menu
                {
                    if(item.numero_tarjeta == tarjeta)
                    {
                        Console.WriteLine("Esta tarjeta ya esta en uso");
                        Console.WriteLine("VOLVIENDO AL MENU ANTERIOR . . .");
                        administrar_usuario();
                    }
                }
                Console.WriteLine("Nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine("Digite su contraseña");
                string contrasena = Console.ReadLine();

                LOGIN.usuario.Add(new C_usuarios { numero_tarjeta = tarjeta, nombre = nombre, apellido = apellido, contra = contrasena, saldo = 0, isadmin = true });
                Console.WriteLine("NUEVO ADMIN AÑADIDO!!");
                administrar_usuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error \nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                Menu();
            }
        }

        public static void editar_admin()//Editar usuarios administradores
        {
            try
            {
                Console.Clear();
                Console.WriteLine("EDITAR ADMIN");
                Console.WriteLine("\nDigite el # de tarjeta");
                string tarjeta = Console.ReadLine();
                if(tarjeta == LOGIN.usuario[LOGIN.usuario_en_uso].numero_tarjeta)
                {
                    Console.WriteLine("UN ADMIN NO PUEDE EDITARSE A SI MISMO \nVOLVIENDO AL MENU . . .");
                    administrar_usuario();
                }
                else
                {
                    foreach(var item in LOGIN.usuario)
                    {
                        if (item.numero_tarjeta == tarjeta)//Aqui validamos que la tarjeta exista
                        {
                            if (item.isadmin == true)//Aqui validamos que sea admin para poder editarlo
                            {
                                Console.WriteLine("Nombre : "+item.nombre+" Apellido"+item.apellido+"\nDesea editar este usuario? S/N");
                                string opcion = Console.ReadLine();
                                switch (opcion)
                                {
                                    case "S":
                                        Console.WriteLine("Editar nombre del admin");
                                        item.nombre = Console.ReadLine();
                                        Console.WriteLine("Editar apellido del admin");
                                        item.apellido = Console.ReadLine();
                                        Console.WriteLine("NOMBRE Y APELLIDO DEL ADMIN EDITADOS");
                                        Console.ReadKey();
                                        administrar_usuario();
                                        break;
                                    case "N":
                                        Console.WriteLine("VOLVIENDO AL MENU ANTERIOR . . .");
                                        Console.ReadKey();
                                        administrar_usuario();
                                        break;
                                    default:
                                        Console.WriteLine("Opcion invalida \nVOLVIENDO AL MENU ANTERIOR . . .");
                                        Console.ReadKey();
                                        administrar_usuario();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Este usuario no es administrador\n VOLVIENDO AL MENU ANTERIOR. . .");
                                Console.ReadKey();
                                administrar_usuario();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error \nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                Menu();
            }
        }

        public static void listar_admin()//Listar administradores
        {
            try
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE USUARIOS ADMINISTRADORES");
                Console.WriteLine("");
                foreach(var item in LOGIN.usuario)
                {
                    if (item.isadmin == true)
                    {
                        Console.WriteLine("# numero de tarjeta : "+item.numero_tarjeta+"\n Nombre : "+item.nombre+" Apellido : "+item.apellido);
                        Console.WriteLine("====================================");
                    }
                    
                }
                
                Console.WriteLine("VOLVIENDO AL MENU ANTERIOR . . .");
                Console.ReadKey();
                administrar_usuario();
            }
         catch (Exception ex)
            {
                Console.WriteLine("Error \nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                Menu();
            }
        }

        public static void eliminar_admin()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("ELIMINAR USUARIO ADMIN \nDigite el # de tarjeta");
                string tarjeta = Console.ReadLine();
                if(tarjeta == LOGIN.usuario[LOGIN.usuario_en_uso].numero_tarjeta)
                {
                    Console.WriteLine("UN USUARIO NO PUEDE ELIMINARSE EL MISMO \nVOLVIENDO AL MENU . . .");
                    Console.ReadKey();
                    administrar_usuario();
                }
                else
                {
                    int contador = 0;
                foreach (var item in LOGIN.usuario)
                {
                    if(item.numero_tarjeta == tarjeta)//este valida el nuemro de tarjeta
                    {
                            if(item.isadmin == true) //este valida que el usuario sea un admin, porque si no lo es entonces lo va a enviar al menu anterior
                            {
                                Console.WriteLine("Nombre : " + item.nombre + " Apellido : " + item.apellido);
                                Console.WriteLine("Seguro que desea eliminar este usuario? S/N");
                                string a = Console.ReadLine();
                                switch (a)
                                {
                                    case "S":
                                        LOGIN.usuario.RemoveAt(contador);
                                        Console.WriteLine("USUARIO REMOVIDO DE MANERA EXITOSA");
                                        Console.ReadKey();
                                        administrar_usuario();
                                        break;
                                    case "N":
                                        Console.WriteLine("VOLVIENDO AL MENU ANTERIOR . . .");
                                        Console.ReadKey();
                                        administrar_usuario();
                                        break;
                                    default:
                                        Console.WriteLine("Opcion invalida.\nVOLVIENDO AL MENU ANTERIOR . . .");
                                        Console.ReadKey();
                                        administrar_usuario();
                                        break;
                                }
                            }
                            else//aqui viene si el usuario no es un administrados
                            {
                                Console.WriteLine("Este usuario no es un administrador\nVOLVIENDO AL MENU ANTERIOR . . .");
                                Console.ReadKey();
                                administrar_usuario();
                            }
                        
                    }
                       
                        contador++;
                }
                 //si la tarjeta es invalida, le mostrata este mensaje
                    {
                        Console.WriteLine("Este tarjeta no ha podido ser encontrada.\nVOLVIENDO AL MENU ANTERIOR . . .");
                        Console.ReadKey();
                        administrar_usuario();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error \nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                Menu();
            }
        }

        public static void reactivar_usuario()
        {
            try {
                Console.Clear();
            Console.WriteLine("REACTIVAR USUARIO \nDigete el # de tarjeta del usuario");
            string tarjeta = Console.ReadLine();
            int contador = 0;
            foreach (var item   in LOGIN.usuario)
            {
                if(item.numero_tarjeta == tarjeta)
                {
                    if(item.isactive == true)
                    {
                        Console.WriteLine("Este cliente ya estaba activo\nVOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Nombre : " + item.nombre + " Apellido : " + item.apellido);
                        Console.WriteLine("Esta seguro que desea reactivar este usuario? S/N");
                        string opcion = Console.ReadLine().ToUpper();
                        switch (opcion)
                        {
                            case "S":
                                item.isactive = true;
                                    Console.WriteLine("Usuario ha sido reactivado \nVOLVIENDO AL MENU . . .");
                                    Console.ReadKey();
                                    Menu();
                                    break;
                            case "N":
                                Console.WriteLine("VOLVIENDO AL MENU . . .");
                                Console.ReadKey();
                                Menu();
                                break;
                            default:
                                Console.WriteLine("OPCION INVALIDA\nVOLVIENDO AL MENU . . .");
                                Console.ReadKey();
                                Menu();
                                break;
                        }
                    }
                }
                contador++;
            }
            Console.WriteLine("Tarjeta no ha podido ser encontrada\nVOLVIENDO AL MENU . . .");
            Console.ReadKey();
            Menu();
            
        }
            catch (Exception ex)
            {
                Console.WriteLine("Error \nVOLVIENDO AL MENU . . .");
                Console.ReadKey();
                Menu();
            }
        }
    }
}





