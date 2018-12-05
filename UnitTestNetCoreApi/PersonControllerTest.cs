using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NetCore.Controllers;
using NetCore.DataModels;
using NetCore.Helpers;
using NetCore.Interfaces;
using Moq;


namespace UnitTestNetCoreApi
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public void PersonControllerTest_Get_IsValidListReturned_OK()
        {
            List<Person> persons = new List<Person>
            {
                new Person{GivenName = "GName1" , FamilyName = "FName1" , Age = 45, Address = "Address1" },
                new Person{GivenName = "GName2" , FamilyName = "FName2" , Age = 44, Address = "Address2" }

            };

            Mock<IDatabase> mockDatabase = new Mock<IDatabase>();
            mockDatabase.Setup(m => m.GetData()).Returns(persons);
            var sut = new PersonController(mockDatabase.Object);

            // ACT
            var results = sut.GetAsync().Result;

            var resultsList = results.Value.ToList();


            // Verify
            mockDatabase.Verify(m => m.GetData(), Times.Once);
            Assert.AreEqual(2, resultsList.Count(), "Should have 2 items");
            Assert.IsTrue(CompareListsIsSameContent(persons, resultsList), "Did not return correct list");

        }

        [TestMethod]
        public void PersonControllerTest_Get_NoListReturned_OK()
        {
            List<Person> persons = null;

            Mock<IDatabase> mockDatabase = new Mock<IDatabase>();
            mockDatabase.Setup(m => m.GetData()).Returns(persons);
            var sut = new PersonController(mockDatabase.Object);

            // ACT
            var results = sut.GetAsync().Result;


            // Verify
            mockDatabase.Verify(m => m.GetData(), Times.Once);
            Assert.IsNull(results.Value, "A null list should be returned");
        }

        private bool CompareListsIsSameContent(List<Person> list1, List<Person> list2)
        {
            if (list1 == null && list2 == null)
            {
                return true;
            }
            else if (list1 == null || list2 == null)
            {
                return false;
            }


            var result = list1.Where(personExpected => list2.Any(personReturned => personExpected.IsSame(personReturned)));
            if ( result != null && result.Count() == list1.Count())
            {
                return true;
            }

            return false;
        }

    }
}
