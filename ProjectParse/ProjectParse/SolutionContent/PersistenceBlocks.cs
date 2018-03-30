using System.Collections;
using System.Collections.Generic;

namespace ProjectParse.SolutionContent
{
    public class PersistenceBlocks : IEnumerable<PersistenceBlock>
    {
        /// <summary>
        /// This list of all blocks included in this project;
        /// </summary>
        private IList<PersistenceBlock> _blocks;

        /// <summary>
        /// Creates a new instance of a persistence blocks
        /// </summary>
        internal PersistenceBlocks(Solution soloution)
        {
            _blocks = new List<PersistenceBlock>();
        }

        /// <summary>
        /// Returns back the number of blocks we have in this solution.
        /// </summary>
        public int count
        {
            get { return _blocks.Count; }
        }

        /// <summary>
        /// Adds a new persistence block to the solution.
        /// </summary>
        /// <returns>True if the block was added and false if it already existed.</returns>
        public bool Add(PersistenceBlock block)
        {
            if (_blocks.Contains(block))
            {
                return false;
            }

            _blocks.Add(block);
            return true;
        }


        /// <summary>
        /// Removes a persistence block from the solution.
        /// </summary>
        /// <param name="block">THe block you want to remove</param>
        /// <returns>True if the block was remove and false if it was not.</returns>
        public bool Remove(PersistenceBlock block)
        {
            for (int i = 0; i < _blocks.Count; i++)
            {
                if (_blocks[i] == block)
                {
                    _blocks.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Allows the user to iterate over all blocks.
        /// </summary>
        public IEnumerator<PersistenceBlock> GetEnumerator()
        {
            return _blocks.GetEnumerator();
        }

        /// <summary>
        /// Allows the user to iterate over all blocks.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _blocks.GetEnumerator();
        }
    }
}
