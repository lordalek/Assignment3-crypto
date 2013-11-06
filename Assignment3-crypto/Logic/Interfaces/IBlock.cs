using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_crypto.Logic.Interfaces
{
    public interface IBlock
    {
        string AddendPadding(string rawText);
        string AppendLength(string rawText, string paddedText);
        string[] GetHashBuffer();
        string[] SplitIntoBlock(string rawText);
        string CompressThreeFactors(string factor1, string factor2, string factor3);
        string XOR(string string1, string string2);
        string FlipBinaries(string rawBinary);
    }
}
