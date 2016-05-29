using System;
using Algorithms.Permutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PermuntationAlgorithmTests
    {
        [TestMethod]
        public void Test_Sequence_One()
        {
            string characters = "143652";
            Algorithm permutations = new Algorithm(characters);
        }
        [TestMethod]
        public void Test_Sequence_Two()
        {
            string characters = "1436527";
            Algorithm permutations = new Algorithm(characters);
        }
    }
}
