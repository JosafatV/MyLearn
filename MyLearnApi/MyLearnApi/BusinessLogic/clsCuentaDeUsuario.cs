﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models;


namespace MyLearnApi.BusinessLogic
{
    public class clsCuentaDeUsuario
    {
        public static bool login(int username, string password)
        {
            using (MyLearnDBEntities entities = new MyLearnDBEntities())
            {
                return entities.USUARIO.Any(user => user.Id == username && user.Contrasena == password);
            }
        }
    }
}