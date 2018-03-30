using System;

namespace ProjectParse.SolutionContent
{
    public struct PersistenceBlock
    {
        public string guid;
        public string typeGuid;
        public string instanceID;
        public string path;

        /// <summary>
        /// Checks to see if a block equals this one.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is PersistenceBlock))
            {
                return false;
            }
            PersistenceBlock block = (PersistenceBlock)obj;
            return block == this;
        }

        /// <summary>
        /// Gets the hashcode for this persistence block.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 947402346;
            unchecked
            {
                hash ^= guid.GetHashCode();
                hash ^= typeGuid.GetHashCode();
                hash ^= instanceID.GetHashCode();
                hash ^= path.GetHashCode();
            }
            return hash;
        }

        public static bool operator ==(PersistenceBlock lhs, PersistenceBlock rhs)
        {
            bool isEqual = string.Equals(lhs.guid, rhs.guid, StringComparison.Ordinal);
            isEqual &= string.Equals(lhs.typeGuid, rhs.typeGuid, StringComparison.Ordinal);
            isEqual &= string.Equals(lhs.instanceID, rhs.instanceID, StringComparison.Ordinal);
            isEqual &= string.Equals(lhs.path, rhs.path, StringComparison.Ordinal);
            return isEqual;
        }

        public static bool operator !=(PersistenceBlock lhs, PersistenceBlock rhs)
        {
            bool isEqual = string.Equals(lhs.guid, rhs.guid, StringComparison.Ordinal);
            isEqual &= string.Equals(lhs.typeGuid, rhs.typeGuid, StringComparison.Ordinal);
            isEqual &= string.Equals(lhs.instanceID, rhs.instanceID, StringComparison.Ordinal);
            isEqual &= string.Equals(lhs.path, rhs.path, StringComparison.Ordinal);
            return !isEqual;
        }
    }
}
