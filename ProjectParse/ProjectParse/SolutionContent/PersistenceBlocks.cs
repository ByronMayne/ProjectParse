using System.Collections.Generic;

namespace ProjectParse.SolutionContent
{
    public class PersistenceBlocks
    {
        /// <summary>
        /// This list of all blocks included in this project;
        /// </summary>
        private IList<PersistenceBlock> _blocks;

        /// <summary>
        /// Creates a new instance of a persistence blocks
        /// </summary>
        internal PersistenceBlocks(Soloution soloution)
        {
            _blocks = new List<PersistenceBlock>();
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
    }
}
