using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;


namespace MyLearnApi.BusinessLogic
{
    public class clsAreaDeTrabajoLogic
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

      
        /// <summary>
        /// Algoritmo que extrae los objetos mensaje de los objetos mensajes_por_trabajo
        /// </summary>
        /// <param name="idTrabajo"> id del trabajo del que se quiere obtener todos los comentarios </param>
        /// <returns></returns>
        public List<MENSAJE> getListaMensajesDeTrabajo(int idTrabajo)
        {
           
            //se obtiene la lista de mensajes pro trabajo
            List<MENSAJE_POR_TRABAJO> lobj_mensajesPorTrabajo = db.MENSAJE_POR_TRABAJO.Where(men => men.IdTrabajo == idTrabajo)
                .OrderByDescending(men => men.IdMensaje)
                .ToList<MENSAJE_POR_TRABAJO>();
            //lista de resultado
            List<MENSAJE> lobj_result = new List<MENSAJE>();
            //extrae los mensajes
            for (int li_x = 0; li_x < lobj_mensajesPorTrabajo.Count; li_x++ )
            {
                MENSAJE lobj_temp = lobj_mensajesPorTrabajo[li_x].MENSAJE;
                lobj_result.Add(lobj_temp);
            }
          
            return lobj_result ;
        }
        
        /// <summary>
        /// agrega mensaje a un trabajo
        /// </summary>
        /// <param name="mensaje"> el mensaje </param>
        /// <param name="idTrabajo"> trabajo</param>
        /// <returns></returns>
        public bool agregarMensajeATrabajo(MENSAJE mensaje, int idTrabajo)
        { 
            //guarda el menssaje y el la tabla mensaje por proyecto relaciona el mensaje al proyecto
            db.SP_Insertar_Mensaje_Trabajo(mensaje.Contenido, mensaje.Adjunto, idTrabajo);    
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;   
            }
            return true;
        }
        /// <summary>
        /// responde cualquier mensaje
        /// </summary>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        public RESPUESTA responderMensaje(RESPUESTA respuesta)
        {
            db.SP_Insertar_Respuesta(respuesta.MensajeRaiz, respuesta.Contenido, respuesta.Adjunto);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return respuesta;
        }

    

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
           
        }

        
    }
}