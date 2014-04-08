using System;
using HardDriveScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HardDriveUnitTesting
{
    [TestClass]
    public class UnitTesting
    {
        #region FCFSTests
        [TestMethod]
        public void SSTFTestOne()
        {
            Algorithms FCFSTest = new Algorithms();

            int[] SmallTest = { 10, 5, 0, 5, 10 ,0,5,10,5,0,5,10,5};

            int result = FCFSTest.SSTF(SmallTest, 13);
            int compare = 10;

            Assert.AreEqual(compare, result, "FCFS Estimates Correctly");
        }
        [TestMethod]
        public void SSTFTestTwo()
        {
            Algorithms FCFSTest = new Algorithms();

            int[] SmallTest = { 1, 2, 3, 4, 5,6,7,8,9,10,11 };

            int result = FCFSTest.SSTF(SmallTest, 11);
            int compare = 11;

            Assert.AreEqual(compare, result, "FCFS Estimates Correctly");
        }
        [TestMethod]
        public void SSTFTestAllSameNumber()
        {
            Algorithms FCFSTest = new Algorithms();

            int[] SmallTest = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            int result = FCFSTest.SSTF(SmallTest, 14);
            int compare = 1;

            Assert.AreEqual(compare, result, "FCFS Estimates Correctly");
        }
        #endregion
        #region FCFSTests
        [TestMethod]
        public void FCFSTestOne()
        {
            Algorithms FCFSTest = new Algorithms();

            int[] SmallTest = { 10, 5, 0, 5, 10 };

            int result = FCFSTest.FCFS(SmallTest, 5);
            int compare = 30;

            Assert.AreEqual(compare, result, "FCFS Estimates Correctly");
        }
        [TestMethod]
        public void FCFSTestTwo()
        {
            Algorithms FCFSTest = new Algorithms();

            int[] SmallTest = { 1, 2, 3, 4, 5 };

            int result = FCFSTest.FCFS(SmallTest, 5);
            int compare = 5;

            Assert.AreEqual(compare, result, "FCFS Estimates Correctly");
        }
        [TestMethod]
        public void FCFSTestAllSameNumber()
        {
            Algorithms FCFSTest = new Algorithms();

            int[] SmallTest = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            int result = FCFSTest.FCFS(SmallTest, 14);
            int compare = 1;

            Assert.AreEqual(compare, result, "FCFS Estimates Correctly");
        }
        #endregion

    }
}
