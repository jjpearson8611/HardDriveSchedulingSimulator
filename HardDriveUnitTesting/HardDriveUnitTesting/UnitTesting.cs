using System;
using HardDriveScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HardDriveUnitTesting
{
    [TestClass]
    public class UnitTesting
    {
        #region SSTFTests
        [TestMethod]
        public void SSTFTestOne()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 10, 5, 0, 5, 10 ,0,5,10,5,0,5,10,5};

            int result = Tester.SSTF(SmallTest, 13);
            int compare = 10;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void SSTFTestTwo()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 2, 3, 4, 5,6,7,8,9,10,11 };

            int result = Tester.SSTF(SmallTest, 11);
            int compare = 11;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void SSTFTestAllSameNumber()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            int result = Tester.SSTF(SmallTest, 14);
            int compare = 1;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        #endregion

        #region FCFSTests
        [TestMethod]
        public void TesterOne()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 10, 5, 0, 5, 10 };

            int result = Tester.FCFS(SmallTest, 5);
            int compare = 30;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void TesterTwo()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 2, 3, 4, 5 };

            int result = Tester.FCFS(SmallTest, 5);
            int compare = 5;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void TesterAllSameNumber()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            int result = Tester.FCFS(SmallTest, 14);
            int compare = 1;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        #endregion

        #region LOOKTests
        [TestMethod]
        public void LOOKTestOne()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 10, 5, 0, 5, 10, 0, 5, 10, 5, 0, 5, 10, 5 };

            int result = Tester.LOOK(SmallTest, 13);
            int compare = 15;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void LOOKTestTwo()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            int result = Tester.LOOK(SmallTest, 11);
            int compare = 11;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void LOOKTestAllSameNumber()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            int result = Tester.LOOK(SmallTest, 14);
            int compare = 1;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        #endregion

        #region CLOOKTests
        [TestMethod]
        public void CLOOKTestOne()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 10, 5, 0, 5, 10, 0, 5, 10, 5, 0, 5, 10, 5 };

            int result = Tester.CLOOK(SmallTest, 13);
            int compare = 25;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void CLOOKTestTwo()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            int result = Tester.CLOOK(SmallTest, 11);
            int compare = 11;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        [TestMethod]
        public void CLOOKTestAllSameNumber()
        {
            Algorithms Tester = new Algorithms();

            int[] SmallTest = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            int result = Tester.CLOOK(SmallTest, 14);
            int compare = 1;

            Assert.AreEqual(compare, result, "Correct Output");
        }
        #endregion
    }
}
