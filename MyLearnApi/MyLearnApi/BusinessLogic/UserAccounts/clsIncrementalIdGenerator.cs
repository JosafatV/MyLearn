using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;

namespace MyLearnApi.BusinessLogic.UserAccounts
{
    /// <summary>
    /// clase que genera un id autoincremental de tipo CHAR(100) para los usuarios
    /// en la base de datos
    /// </summary>
    public class clsIncrementalIdGenerator : clsUserIdGenerator
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        public string generateUserId()
        {
            // =  
            int li_lastGenerated = Int32.Parse(db.sp_GetLAstUserId().SingleOrDefault());
            int result = li_lastGenerated + 1;
            return result.ToString();
        }
    }
}