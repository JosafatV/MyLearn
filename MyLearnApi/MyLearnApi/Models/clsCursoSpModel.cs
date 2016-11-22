using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearnApi.Models
{
    public class clsCursoSpModel
    {
        public int idCurso;
        public string IdProfesor;
        public string Nombre;
        public string Codigo;
        public int IdUniversidad;
        public byte NotaMinima;
        public DateTime FechaInicio;
        public int NumeroGrupo;
    }
}