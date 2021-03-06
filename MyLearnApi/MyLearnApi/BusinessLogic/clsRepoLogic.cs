﻿
using MyLearnApi.Models;
using MyLearnApi.Models.DriveIntegration;
using System.Data.Entity.Infrastructure;
using System.IO;
using MyLearnApi.Models.TwitterIntegration;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLearnApi.BusinessLogic.UserAccounts
{
    public class clsRepoLogic
    {

        private static MyLearnDBEntities db = new MyLearnDBEntities();
        private static clsTwitterConn pobj_twittConn = new clsTwitterConn();
        
        /// <summary>
        /// almancena las credenciales de google drive de un usuario
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        public static DriveCredentials createNewDriveCredentials(DriveCredentials cred)
        {
            db.DriveCredentials.Add(cred);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //si ya existe
                if (db.DriveCredentials.Find(cred.UserId) != null )
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

        
            return cred;
        }

        public static TWITTER_CREDENTIALS createNewTwitterCredentials(TWITTER_CREDENTIALS cred)
        {
            db.TWITTER_CREDENTIALS.Add(cred);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //si ya existe
                if (db.TWITTER_CREDENTIALS.Find(cred.UserId) != null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }


            return cred;
        }

        /// <summary>
        /// twitea un badge y le cambia el estado aalardeado "R"
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombreEstudiante"></param>
        /// <param name="idBadge"></param>
        /// <param name="idCurso"></param>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        public string twittBadge(string idUsuario,string nombreEstudiante, int idBadge, int idCurso, int idProyecto)
        {

            BADGE lobj_badge = db.BADGE.Find(idBadge);
            BADGE_POR_PROYECTO bpp = db.BADGE_POR_PROYECTO.Find(idBadge,idProyecto);
            bpp.Estado = "R";
            db.Entry(bpp).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {                
               throw;   
            }


            TWITTER_CREDENTIALS cred = db.TWITTER_CREDENTIALS.Find(idUsuario);
            CURSO curso = db.CURSO.Find(idCurso);//id
            //get tokens of the database
            if (cred != null)
            {
                //defaut application tokens
                pobj_twittConn.setConsumerKey("BsJg0w7pVCPWUMO6LJ4KGlAGu");
                pobj_twittConn.setConsumerSecret("JD2DPyEq3gnroWOa1Iu4UtpxgzImEZ1lMi6Y0SiDgk9fHpC5ml");
                //set user tokens
                pobj_twittConn.setUserAccessToken(cred.AccessToken);
                pobj_twittConn.setUserAccessSecret(cred.AccessTokenSecret);
                // pobj_twittConn.setUserAccessToken("1327984718-gkh5tjiC5sFvOm8Ui4Eefwd2tiLuVFge07RXdzK");
                //pobj_twittConn.setUserAccessSecret("Y0EBtEWitIz0XUmIXn0KE7Narf2boTfnDJ88jfQHlMk0X");
                //sends twitt and return the twitt
                string twitt = nombreEstudiante + " ganó " + RemoveWhitespace(lobj_badge.Nombre) + " en " +curso.Nombre;
                return pobj_twittConn.twitt(twitt);
            }
            //error no credentials
            else
                return "No twitter credentials for user : " + idUsuario ;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreTrabajo"></param>
        /// <returns></returns>
        public string twittSubasta(string nombreTrabajo)     
        {
          
            //defaut application tokens
            pobj_twittConn.setConsumerKey("BsJg0w7pVCPWUMO6LJ4KGlAGu");
            pobj_twittConn.setConsumerSecret("JD2DPyEq3gnroWOa1Iu4UtpxgzImEZ1lMi6Y0SiDgk9fHpC5ml");
            //set tokens of XMP twitter account
            pobj_twittConn.setUserAccessToken("804453874409107456-jp4oC99qlNsEAKzDpP6KVb5mJqMkMkV");
            pobj_twittConn.setUserAccessSecret("V8s9IYvvfdI1HX2moYsIu27V62VVbNtm0h79RqCZuicK4");
            //sends twitt and return the twitt
            string twitt = "Hay un nuevo proyecto: " + nombreTrabajo;


            return pobj_twittConn.twitt(twitt);
           

        }
        /// <summary>
        /// remove withe spaces
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }


        /// <summary>
        /// uploads the file and returns the WebContentLink
        /// </summary>
        /// <returns></returns>
        public static  string uploadFile(Stream byteArray,string IdUsuario, string fileName, string contentType)
        {
            
            DriveCredentials cred = db.DriveCredentials.Find(IdUsuario);
            //get tokens of the database
            if (cred != null)
            {
                //set tokens to the drive connection
                clsDriveConn.access_token = cred.AccessToken;
                clsDriveConn.refresh_token = cred.RefreshToken;

            }
            //sube el archivoy devuelve el content link
            return clsDriveConn.getContentLink(fileName, contentType, byteArray);
        }


    }
}