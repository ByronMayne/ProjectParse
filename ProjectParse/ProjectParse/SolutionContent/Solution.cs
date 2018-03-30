using System;
using System.IO;

namespace ProjectParse.SolutionContent
{
    public class Solution
    {
        private static readonly string[] supportedExtensions;

        private string _filePath;
        private string _name;
        private string _extension;
        private string _visualStudioVersion;
        private string _minimumVisualStudioVersion;

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
        /// Gets or sets the visual studio version
        /// </summary>
        public string visualStudioVersion
        {
            get { return _visualStudioVersion; }
            set { _visualStudioVersion = value; }
        }

        /// <summary>
        /// Gets or sets the minimum visual studio version.
        /// </summary>
        public string minimumVisualStudioVersion
        {
            get { return _minimumVisualStudioVersion; }
            set { _minimumVisualStudioVersion = value; }
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
            _blocks = new PersistenceBlocks(this);
        }

        /// <summary>
        /// Initializes our static values.
        /// </summary>
        static Solution()
        {
            supportedExtensions = new string[] { ".sln" };
        }

        /// <summary>
        /// Creates a new instance of a Solution by parsing a existing one
        /// from disk.
        /// </summary>
        /// <param name="filePath"></param>
        private Solution(string filePath)
        {
            _blocks = new PersistenceBlocks(this);
            _extension = Path.GetExtension(filePath);
            // Make sure it's supported
            ValidateSolutionExtension(_extension);
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
        public static Solution Create(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name", "You must give a name when creating a new solution");
            }
            Solution newSolution = new Solution();
            newSolution._name = name;
            newSolution._filePath = string.Empty;
            return newSolution;
        }

        /// <summary>
        /// Checks to make sure that the extension is supported and if it's not
        /// we throw an exception
        /// </summary>
        /// <param name="extension">The extension you want to check</param>
        /// <exception cref="System.IO.FileLoadException"/>
        private void ValidateSolutionExtension(string extension)
        {
            for(int i = 0; i < supportedExtensions.Length; i++)
            {
                if(string.Equals(supportedExtensions[i], extension, StringComparison.Ordinal))
                {
                    return; 
                }
            }

            string message = "Unable to Solution as it has an unsupported extension of '" + extension + "'. The supported types are ";
            message += string.Join(", ", supportedExtensions);
            throw new FileLoadException(message);
        }
    }
}
