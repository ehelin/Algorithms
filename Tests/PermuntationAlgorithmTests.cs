using Algorithms.Permutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PermuntationAlgorithmTests
    {
        [TestMethod]
        public void Test_Sequence_One_A()
        {
            string result = RunTest("1,2");
            Assert.AreEqual("2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_One_B()
        {
            string result = RunTest("11,222");
            Assert.AreEqual("222-11", result);
        }

        [TestMethod]
        public void Test_Sequence_Two_A()
        {
            string result = RunTest("1,3,2");
            Assert.AreEqual("3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Two_B()
        {
            string result = RunTest("122,35,12");
            Assert.AreEqual("122-35-12", result);
        }

        [TestMethod]
        public void Test_Sequence_Three_A()
        {
            string result = RunTest("1,4,3,2");
            Assert.AreEqual("4-3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Three_B()
        {
            string result = RunTest("231,44,253,2");
            Assert.AreEqual("253-231-44-2", result);
        }

        [TestMethod]
        public void Test_Sequence_Four_A()
        {
            string result = RunTest("1,4,5,3,2");
            Assert.AreEqual("5-4-3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Four_B()
        {
            string result = RunTest("21,4,524,3,12");
            Assert.AreEqual("524-21-12-4-3", result);
        }

        [TestMethod]
        public void Test_Sequence_Five_A()
        {
            string result = RunTest("6,1,4,5,3,2");
            Assert.AreEqual("6-5-4-3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Five_B()
        {
            string result = RunTest("21,4,524,3,12");
            Assert.AreEqual("524-21-12-4-3", result);
        }

        [TestMethod]
        public void Test_Sequence_Six_A()
        {
            string result = RunTest("6,7,1,4,5,3,2");
            Assert.AreEqual("7-6-5-4-3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Six_B()
        {
            string result = RunTest("21,4,524,3,12");
            Assert.AreEqual("524-21-12-4-3", result);
        }

        [TestMethod]
        public void Test_Sequence_Seven_A()
        {
            string result = RunTest("6,7,1,4,5,3,2,8");
            Assert.AreEqual("8-7-6-5-4-3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Seven_B()
        {
            string result = RunTest("6,7,12,4,53,3124,2,86");
            Assert.AreEqual("3124-86-53-12-7-6-4-2", result);
        }

        [TestMethod]
        public void Test_Sequence_Eight_A()
        {
            string result = RunTest("6,7,1,4,5,9,3,2,8");
            Assert.AreEqual("9-8-7-6-5-4-3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Eight_B()
        {
            string result = RunTest("6,1247,13,4,5,1249,3,212,81");
            Assert.AreEqual("1249-1247-212-81-13-6-5-4-3", result);
        }

        [TestMethod]
        public void Test_Sequence_Nine_A()
        {
            string result = RunTest("6,7,1,10,4,5,9,3,2,8");
            Assert.AreEqual("10-9-8-7-6-5-4-3-2-1", result);
        }
        [TestMethod]
        public void Test_Sequence_Nine_B()
        {
            string result = RunTest("62532,7,1,1230,42,5,9,325,2,81231");
            Assert.AreEqual("81231-62532-1230-325-42-9-7-5-2-1", result);
        }

        private string RunTest(string characters)
        {
            Algorithm a = new Algorithm(characters, false);
            string result = a.RunReturnValue();

            return result;
        }
    }
}
