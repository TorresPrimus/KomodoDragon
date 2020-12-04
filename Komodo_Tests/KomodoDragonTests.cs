using DeveloperRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_Tests
{
    [TestClass]
    public class KomodoDragonTests
    {
        [TestMethod]
        public void SetID_ShouldSetCorrectInt()
        {
            DevContent content = new DevContent("Richard Torres", 1, true);

            int expected = 1;
            int actual = content.IdentificationNumber;

            Assert.AreEqual(expected, actual);
        }
    }
}
