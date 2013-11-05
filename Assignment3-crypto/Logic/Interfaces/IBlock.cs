using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_crypto.Logic.Interfaces
{
    public interface IBlock
    {
        string AddendPadding(string rawText, int paddingLength);
        string AppendLength(string rawTest);
    }
}
