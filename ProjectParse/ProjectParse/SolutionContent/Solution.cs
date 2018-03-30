﻿
using System;
using System.IO;

namespace ProjectParse.SolutionContent
{
    public class Solution
    {
        private string _filePath;
        private string _name;
        private PersistenceBlocks _blocks;

        /// <summary>
        /// Returns the name of the solution
        /// </summary>
        public string name
        {
            get { return _name; }
        }

        /// <summary>
        /// returns the file path of the solution
        /// </summary>
        public string filePath
        {
            get { return _filePath; }
        }

        /// <summary>
        /// Gets the current persistence blocks in the project.
        /// [Persistence blocks is the formal name for the list of projects in the solution]
        /// </summary>
        public PersistenceBlocks blocks
        {
            get { return _blocks; }
        }

        /// <summary>
        /// Creates a new instance of a Solution
        /// </summary>
        private Solution()
        {

        }

        /// <summary>
        /// Creates a new instance of a Solution by parsing a existing one
        /// from disk.
        /// </summary>
        /// <param name="filePath"></param>
        private Solution(string filePath)
        {
            Parse(filePath);
        }

        /// <summary>
        /// Takes a file path and tries to parse an existing solution from disk.
        /// </summary>
        /// <param name="filePath">The file path to the existing solution.</param>
        private void Parse(string filePath)
        {

        }

        /// <summary>
        /// Reads an existing solution from disk.
        /// </summary>
        /// <param name="filePath">The path to the existing solution.</param>
        /// <returns>The loaded solution</returns>
        public static Solution Read(string filePath)
        {
            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException("Unable to find Solution at given path", filePath);
            }
            return new Solution(filePath);
        }

        /// <summary>
        /// Creates a new solution with the given name
        /// </summary>
        /// <param name="name">The name of the solution</param>
        /// <returns>The new instance that was created</returns>
        public Solution Create(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "You must give a name when creating a new solution");
            }
            Solution newSolution = new Solution();
            newSolution._name = name;
            newSolution._filePath = string.Empty;
            return newSolution;
        }
    }
}