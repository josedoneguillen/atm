﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ITLA_ATM
{
    class C_usuarios
    {
        public string numero_tarjeta { get; set; }
        public string nombre { get; set; } 
            public string apellido{get; set;} 
            public string contra{get; set;}
        public double saldo { get; set; }
        public bool isadmin { get; set; }
        public bool isactive { get; set; }
        public void C_usuario(string tarjeta, string nomb, string apell, string cont,double sal, bool admin=false, bool acti = true )
        {
            numero_tarjeta = tarjeta;
            nombre = nomb;
            apellido = apell;
            contra = cont;
            saldo = sal;
            isadmin = admin; 
        }
    }
}
