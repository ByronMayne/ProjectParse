using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ProjectParse.SolutionContent;

namespace ProjectParseTests
{
    [TestClass]
    public class SolutionTests
    {
        [TestMethod]
        [Description("We should get an exception if we try to read a solution that does not exist.")]
        public void ReadMissingException()
        {
            Exception thrownException = null;
            try
            {
                Solution.Read("C://SolutionTests/InvalidSln.sln");
            }
            catch (Exception e)
            {
                thrownException = e;
            }
            string error = "We should have thrown a file not found exception as we sent an invalid path";
            Assert.IsInstanceOfType(thrownException, typeof(FileNotFoundException), error);
        }
    }
}
