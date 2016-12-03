using System;
using System.Collections.Generic;
using MyLearnApi.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLearnApi.BusinessLogic.UserAccounts;

namespace MyLearnApiTests
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void Test_Encription()
        {
            string Sal = BCrypt.GenerateSalt();
            string myPassword = "1234abcd";
            string myHash = BCrypt.HashPassword(myPassword, Sal);

            Assert.AreNotEqual(myPassword, myHash);
            Assert.AreEqual(myHash, BCrypt.HashPassword(myPassword, Sal));
        }

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

        [TestMethod]
        public void Test_idProfesor()
        {
            string idProfesor = "13";
            Assert.AreSame("13", idProfesor);
            Assert.AreEqual("13", idProfesor);
        }
        /*
        [TestMethod]
        public void Test_twittSubasta()
        {
            
            clsRepoLogic repo = new clsRepoLogic();
            string Twitter = repo.twittSubasta("Unit Test");

            Assert.IsNotNull(Twitter);
        }*/

        [TestMethod]
        public void Test_paginarLista20()
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
            //Assert.AreEqual(expectedlist, list);
        }

        [TestMethod]
        public void Test_paginarLista7()
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
            //Assert.AreEqual(expectedlist, list);
            //Assert.AreEqual(expectedlist2, list2);
            //Assert.AreEqual(expectedlist3, list3);
        }

        [TestMethod]
        public void Test()
        {

        }
    }
}