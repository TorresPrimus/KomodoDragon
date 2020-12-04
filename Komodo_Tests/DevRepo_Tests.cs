using DeveloperRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DevRepo_Tests
    {
        private DevRepo _repo;
        private DevContent _content;

        [TestInitialize]
        public void DefaultValues()
        {
            _repo = new DevRepo();
            _content = new DevContent("Brittany Beahan", 2, true);

            _repo.AddDevToList(_content);
        }

        //ARRANGE   //ACT   //ASSERT

        [TestMethod]
        public void AddDevToList_ShouldGetNotNull()
        {
            DevContent content = new DevContent("Richard Torres", 1, true);
            DevRepo repository = new DevRepo();

            repository.AddDevToList(content);
            DevContent contentfromDirectory = repository.GetDevContentByID(1);

            Assert.IsNotNull(contentfromDirectory);
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(1, false)]

        [TestMethod]
        public void UpdateDevContent_ShouldReturnTrue(int originalID, bool shouldUpdate)
        {
            DevContent newContent = new DevContent("Richard Torres", 1, false);

            bool updateResult = _repo.UpdateDevContent(originalID, newContent);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void RemoveDevContent_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveDevFromList(_content.IdentificationNumber);

            Assert.IsTrue(deleteResult);
        }
    }
}
