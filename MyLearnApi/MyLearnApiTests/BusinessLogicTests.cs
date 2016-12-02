using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLearnApiTests
{
    [TestClass]
    public class BusinessLogicTests
    {
        [TestMethod]
        public void Test_CursosPorProfesor()
        {
            //Create values fo the test
            string idProfesor = "13";
            int index = 1;

            //Call the method ad obtain it's resulting list
            //List<CURSO_POR_PROFESOR> lst = getCursosProfesor(idProfesor, index);

            //Test the obtained list
           // Assert.IsNotNull(lst, "Success");
        }

        /*
                [TestMethod]
                public void Test_isTotalPuntajeValido()
                {
                    //Create list of badges for the test
                    List<BADGE> Badges = new List<BADGE>();         
                    BADGE TestBadge1 = new BADGE();
                    BADGE TestBadge2 = new BADGE();
                    BADGE TestBadge3 = new BADGE();

                    clsCursosLogic cl = new clsCursosLogic();

                    Assert.Equals(TestBadge1. = 50);


                }
           */
    }
}
