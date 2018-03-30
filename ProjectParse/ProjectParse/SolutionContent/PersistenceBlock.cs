using System;
using System.IO;

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
        
        /// <summary>
        /// Given a line of text this function will parse it and create a persistence block
        /// </summary>
        /// <param name="text">The text you want to parse</param>
        /// <returns>The parsed block</returns>
        internal static PersistenceBlock Parse(string text)
        {
            // Example: 
            // Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ProjectParseTests", "ProjectParseTests\ProjectParseTests.csproj", "{7E0C5121-B5D3-4A45-AACF-9623C87BADB9}"
            PersistenceBlock block = new PersistenceBlock();

            // Create a reader 
            StreamReader reader = new StreamReader(text);

            int fieldIndex = 0;
            int index = 0;
            while(!reader.EndOfStream)
            {
                int start = 0;
                int length = 0;
                char c = (char)reader.Read();
                
                if(c == '"')
                {
                    start = index;
                    do
                    {
                        index++;
                        length++;
                    } while (c == '"');

                    if(length > 0)
                    {
                        string content = text.Substring(start, length);

                        switch(fieldIndex)
                        {
                            case 0: block.typeGuid = content; break;
                            case 1: block.instanceID = content; break;
                            case 2: block.path = content; break;
                            case 3: block.typeGuid = content; break;
                        }
                        fieldIndex++;
                        if(fieldIndex > 3)
                        {
                            // All fields assigned 
                            break;
                        }
                    }
                }

                index++;
            }

            if (fieldIndex >= 3)
            {
                throw new ParseException("Unable to parse all fields of Persistence Block. Expect four but found " + fieldIndex);
            }

            return block;
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
