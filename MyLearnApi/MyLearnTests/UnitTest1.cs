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
        public void TestMethod1()
        {
            string idProfesor = "13";
            Assert.AreSame("13", idProfesor);
        }

        [TestMethod]
        public void Test_twittSubasta()
        {
            
            clsRepoLogic repo = new clsRepoLogic();
            string Twitter = repo.twittSubasta("Unit Testing");

            Assert.IsNotNull(Twitter);
        }

        [TestMethod]
        public void Test_getSpecificStudent()
        {
            clsStudentsLogic student = new clsStudentsLogic();
            string idStudent = "1";
            
            Assert.IsNotNull(student.getSpecificStudent(idStudent));
        }

    }
}
