using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ProjectParse.SolutionContent;

namespace ProjectParseTests
{
    [TestClass]
    public class SolutionTests
    {
        private string projectDirectory
        {
            get
            {
                string directory = Directory.GetCurrentDirectory();
                return directory += "\\..\\..\\..\\";
            }
        }

        private string solutionExamplesDirectory
        {
            get { return projectDirectory + "\\ProjectParseTests\\TestFiles\\"; }
        }

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

        [TestMethod]
        [Description("We should get an exception if we try to send in a file that exists but has the wrong extension")]
        public void ReadUnsupportedExtensionCheck()
        {
            Exception thrownException = null;
            try
            {
                // Get the first cs file 
                string file = Directory.GetFiles(projectDirectory, "*.cs", SearchOption.AllDirectories)[0];
                // Read it (since it's valid but the wrong extension.
                Solution.Read(file);
            }
            catch (Exception e)
            {
                thrownException = e;
            }
            string error = "We should have thrown a File Load Exception as we have a real file but wrong extension.";
            Assert.IsInstanceOfType(thrownException, typeof(FileLoadException), error);
        }

        [TestMethod]
        [Description("We should be able to load a solution if it's valid")]
        public void ReadSolution()
        {
            Console.WriteLine("Project Directory: " + projectDirectory);
            string slnPath = Directory.GetFiles(projectDirectory, "*.sln", SearchOption.TopDirectoryOnly)[0];
            Console.WriteLine("SlnPath: " + slnPath);
            Solution solution = Solution.Read(slnPath);
            Assert.IsNotNull(solution, "We created a valid solution path however we did not create a Solution instance");
        }

        [TestMethod]
        [Description("When we create a solution but don't give it a name we should get argument null exception")]
        public void CreateSolution()
        {
            Exception caughtException = null;
            try
            {
                Solution.Create(null);
            }
            catch (Exception e)
            {
                caughtException = e;
            }

            Assert.IsInstanceOfType(caughtException, typeof(ArgumentException), "We should have got an exception for naming an Solution null");
            caughtException = null;
            try
            {
                Solution.Create(string.Empty);
            }
            catch (Exception e)
            {
                caughtException = e;
            }
            Assert.IsInstanceOfType(caughtException, typeof(ArgumentException), "We should have got an exception for naming an Solution an empty string");
        }

        [TestMethod]
        [Description("When we create a solution but don't give it a name we should get argument null exception")]
        public void ParsePersistenceBlocks()
        {
            string solutionPath = solutionExamplesDirectory + "BasicSolution.sln";
            Console.WriteLine("Examples Dir: " + solutionPath);
            Solution parsedSolution = Solution.Read(solutionPath);
            Assert.AreEqual(2, parsedSolution.blocks.count, "We should have parsed out two projects");

            foreach(PersistenceBlock block in parsedSolution.blocks)
            {
                Console.WriteLine("Parsed: " + block.ToString());
            }
        }
    }
}
