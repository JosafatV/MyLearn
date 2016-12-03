using System;
using System.Linq;
using System.Collections.Generic;
using MyLearnApi.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLearnApi.Models;
using MyLearnApi.BusinessLogic.UserAccounts;

namespace MyLearnApiTests
{
    [TestClass]
    public class UnitTest1
    {

        //verifica que se encripte una contraseña de manera correcta
        [TestMethod]
        public void Test_Encription()
        {
            string Sal = BCrypt.GenerateSalt();
            string myPassword = "1234abcd";
            string myHash = BCrypt.HashPassword(myPassword, Sal);

            Assert.AreNotEqual(myPassword, myHash);
            Assert.AreEqual(myHash, BCrypt.HashPassword(myPassword, Sal));
        }

        //verifica que la revisión de las contraseñas funcione de manera correcta
        [TestMethod]
        public void Test_CheckPassword()
        {
            string Sal = BCrypt.GenerateSalt();
            string myPassword = "qwerty123";
            string wrongPassword = "fghj1234";
            string myHash = BCrypt.HashPassword(myPassword, Sal);

            Assert.AreEqual(true, BCrypt.CheckPassword(myPassword, myHash));
            Assert.AreEqual(false, BCrypt.CheckPassword(wrongPassword, myHash));
        }

        //verifica que se generan sales diferentes 
        [TestMethod]
        public void Test_SaltGeneration()
        {
            string Sal = BCrypt.GenerateSalt();
            string Sal2 = BCrypt.GenerateSalt();
            string Sal3 = BCrypt.GenerateSalt();
            string Sal4 = BCrypt.GenerateSalt();

            Assert.AreNotEqual(Sal, Sal2);
            Assert.AreNotEqual(Sal2, Sal3);
            Assert.AreNotEqual(Sal3, Sal4);
        }

        //revisa los métodos de análisis de visual studio
        [TestMethod]
        public void Test_idProfesor()
        {
            string idProfesor = "13";
            Assert.AreSame("13", idProfesor);
            Assert.AreEqual("13", idProfesor);
        }

        //prueba que se realice el twitt de manera correcta
        [TestMethod]
        public void Test_twittSubasta()
        {
            
            clsRepoLogic repo = new clsRepoLogic();
            string Twitter = repo.twittSubasta("Unit Test");

            Assert.IsNotNull(Twitter);
        }

        //revisa el método de paginación
        [TestMethod]
        public void Test_PaginarLista20()
        {
            int index = 0;
            byte offset = 20;
            List<object> chapters = new List<object>();
            chapters.Add("DA"); chapters.Add("LT");
            chapters.Add("EC"); chapters.Add("IW");
            chapters.Add("WS"); chapters.Add("SW");
            chapters.Add("IF"); chapters.Add("NL");
            chapters.Add("BA"); chapters.Add("IH");
            chapters.Add("LT"); chapters.Add("WE");
            chapters.Add("UM"); chapters.Add("DG");
            chapters.Add("TS"); chapters.Add("LW");
            chapters.Add("WB"); chapters.Add("SM");
            chapters.Add("RG"); chapters.Add("AL");
            chapters.Add("AC"); chapters.Add("AS");
            chapters.Add("GK"); chapters.Add("AM");

            List<object> expectedlist = new List<object>();
            expectedlist.Add("DA"); expectedlist.Add("LT");
            expectedlist.Add("EC"); expectedlist.Add("IW");
            expectedlist.Add("WS"); expectedlist.Add("SW");
            expectedlist.Add("IF"); expectedlist.Add("NL");
            expectedlist.Add("BA"); expectedlist.Add("IH");
            expectedlist.Add("LT"); expectedlist.Add("WE");
            expectedlist.Add("UM"); expectedlist.Add("DG");
            expectedlist.Add("TS"); expectedlist.Add("LW");
            expectedlist.Add("WB"); expectedlist.Add("SM");
            expectedlist.Add("RG"); expectedlist.Add("AL");

            List<object> list = clsAlgoritmoPaginacion.paginar(chapters, index, offset);
            Assert.AreEqual(24, chapters.Count);
            Assert.AreEqual(20, expectedlist.Count);
            Assert.AreEqual(20, list.Count);

            List<object> lista = expectedlist.Except(list).ToList();
            List<object> listb = list.Except(expectedlist).ToList();
            Assert.AreEqual(lista.Count, listb.Count);
        }

        //revisa el método de paginación para diferentes casos específicos
        [TestMethod]
        public void Test_PaginarLista7()
        {
            int index = 0;
            int index2 = 1;
            int index3 = 3;
            byte offset = 7;
            List<object> chapters = new List<object>();
            chapters.Add("DA"); chapters.Add("LT");
            chapters.Add("EC"); chapters.Add("IW");
            chapters.Add("WS"); chapters.Add("SW");
            chapters.Add("IF"); chapters.Add("NL");
            chapters.Add("BA"); chapters.Add("IH");
            chapters.Add("LT"); chapters.Add("WE");
            chapters.Add("UM"); chapters.Add("DG");
            chapters.Add("TS"); chapters.Add("LW");
            chapters.Add("WB"); chapters.Add("SM");
            chapters.Add("RG"); chapters.Add("AL");
            chapters.Add("AC"); chapters.Add("AS");
            chapters.Add("GK"); chapters.Add("AM");

            List<object> expectedlist = new List<object>();
            expectedlist.Add("DA"); expectedlist.Add("LT");
            expectedlist.Add("EC"); expectedlist.Add("IW");
            expectedlist.Add("WS"); expectedlist.Add("SW");
            expectedlist.Add("IF");

            List<object> expectedlist2 = new List<object>();
            expectedlist2.Add("NL");
            expectedlist2.Add("BA"); expectedlist2.Add("IH");
            expectedlist2.Add("LT"); expectedlist2.Add("WE");
            expectedlist2.Add("UM"); expectedlist2.Add("DG");

            List<object> expectedlist3 = new List<object>();
            expectedlist3.Add("AS");
            expectedlist3.Add("GK"); expectedlist3.Add("AM");

            List<object> list = clsAlgoritmoPaginacion.paginar(chapters, index, offset);
            List<object> list2 = clsAlgoritmoPaginacion.paginar(chapters, index2, offset);
            List<object> list3 = clsAlgoritmoPaginacion.paginar(chapters, index3, offset);

            Assert.AreEqual(24, chapters.Count);
            Assert.AreEqual(7, expectedlist.Count);
            Assert.AreEqual(7, expectedlist2.Count);
            Assert.AreEqual(3, expectedlist3.Count);
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual(7, list2.Count);
            Assert.AreEqual(3, list3.Count);

            List<object> lista = expectedlist.Except(list).ToList();
            List<object> listb = list.Except(expectedlist).ToList();
            Assert.AreEqual(lista.Count, listb.Count);

            lista = expectedlist2.Except(list2).ToList();
            listb = list2.Except(expectedlist2).ToList();
            Assert.AreEqual(lista.Count, listb.Count);

            lista = expectedlist3.Except(list3).ToList();
            listb = list3.Except(expectedlist3).ToList();
            Assert.AreEqual(lista.Count, listb.Count);
        }

        //verifica que los badge se cuenten de manera correcta
        [TestMethod]
        public void Test_ContarBadges()
        {
            BADGE bdge = new BADGE();
            bdge.Id = 1;
            bdge.IdCurso = 3;
            bdge.Nombre = "testbadge1";
            bdge.Puntaje = 25;

            BADGE bdge2 = new BADGE();
            bdge2.Id = 2;
            bdge2.IdCurso = 3;
            bdge2.Nombre = "testbadge2";
            bdge2.Puntaje = 25;

            BADGE bdge3 = new BADGE();
            bdge3.Id = 3;
            bdge3.IdCurso = 3;
            bdge3.Nombre = "testbadge3";
            bdge3.Puntaje = 50;

            List<BADGE> listBadge = new List<BADGE>();
            listBadge.Add(bdge);
            listBadge.Add(bdge2);
            listBadge.Add(bdge3);

            Byte b25 = 25;
            Byte b50 = 50;

            Assert.AreEqual(b25, bdge.Puntaje);
            Assert.AreEqual(b25, bdge2.Puntaje);
            Assert.AreEqual(b50, bdge3.Puntaje);

            clsCursosLogic curso = new clsCursosLogic();
            Assert.IsTrue(curso.isTotalPuntajeValido(listBadge));

        }

        //verifica quese agrega una respuesta de manera correcta
        [TestMethod]
        public void Test_AgregarRespuesta()
        {
            MENSAJE mns = new MENSAJE();
            mns.Id = 1;
            mns.Contenido = "Unit Test sent as message";
            mns.NombreEmisor = "The Emperor of Mankind";

            RESPUESTA res = new RESPUESTA();
            res.Id = 1;
            res.MensajeRaiz = 1;
            res.NombreEmisor = "Malcador The Sigilite";
            
            mns.RESPUESTA.Add(res);

            Assert.AreEqual(res.Contenido, mns.RESPUESTA.First<RESPUESTA>().Contenido);
        }
    }
}