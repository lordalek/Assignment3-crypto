using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3_crypto.Logic.Interfaces;
using System.Numerics;

namespace Assignment3_crypto.Logic.BackEndLogic
{
    public class Hasher : IBlock
    {
        #region IBlock Members

        public string AddendPadding(string rawText)
        {
            rawText = rawText.Insert(0, "1");
            while (rawText.Length % 1024 != 896)
            {
                rawText = rawText.Insert(1, "0");
            }

            return rawText;
        }

        public string AppendLength(string rawText, string paddedText)
        {
            var formerSize = Convert.ToString(rawText.Length, 2);
            while (formerSize.Length < 128)
                formerSize = formerSize.Insert(0, "1");
            paddedText += formerSize;
            return paddedText;
        }

        public string[] GetHashBuffer()
        {
            var buffer = new string[8];
            buffer[0] = "0110101000001001111001100110011111110011101111001100100000000000";
            buffer[1] = "1011101101100111101011101000010110000100110010101010100000000000";
            buffer[2] = "0011110001101110111100110111001011111110100101001111100000000000";
            buffer[3] = "1010010101001111111101010011101001011111000111010011100000000000";
            buffer[4] = "0101000100001110010100100111111110101101111001101000000000000000";
            buffer[5] = "1001101100000101011010001000110000101011001111100111000000000000";
            buffer[6] = "0001111110000011110110011010101111111011010000011011110100000000";
            buffer[7] = "0101101111100000110011010001100100010011011111100010000000000000";
            return buffer;
        }

        #endregion
    }
}
