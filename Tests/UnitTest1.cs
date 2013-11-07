using System;
using Assignment3_crypto.Logic.BackEndLogic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void InsertStringWithLength64_ExpectStringWithLength896()
        {
            var hasher = new Hasher();
            var bins = "1100111100001111000011110000111100001111000011110000111100001111";
            var expandedBins = hasher.AddendPadding(bins);
            Assert.IsTrue(expandedBins.Length == 896);
        }

        [Test]
        public void AppendLengthToMessage_ExpectMessageLengthPluss128()
        {
            var hasher = new Hasher();
            var bins = "1100111100001111000011110000111100001111000011110000111100001111";
            var expandedBins = hasher.AddendPadding(bins);
            var appendedMessage = hasher.AppendLength(bins, expandedBins);
            Assert.IsTrue(appendedMessage.Length == (expandedBins.Length + 128));
        }

        [Test]
        public void Split2048BitString_ExpectTwoBlocks()
        {
            var hasher = new Hasher();
            var bins = "1100111100001111000011110000111100001111000011110000111100001111";
            var expandedBins = hasher.AddendPadding(bins);
            var appendedMessage = hasher.AppendLength(bins, expandedBins);
            var blocks = hasher.SplitIntoBlock(appendedMessage + appendedMessage);
            Assert.IsTrue(blocks.Length == 2);
        }

        [Test]
        public void XOR_1010_with_1000_expect_0111()
        {
            var hasher = new Hasher();
            Assert.AreEqual(hasher.XOR("1010", "1000"), "0010");
        }

        [Test]
        public void XOR_10101111_with_10001010_expect_0111()
        {
            var hasher = new Hasher();
            Assert.AreEqual(hasher.XOR("10101111", "10001010"), "00100101");
        }

        [Test]
        public void FLIP_1001_EXPECT_0110()
        {
            var hasher = new Hasher();
            Assert.AreEqual("0110", hasher.FlipBinaries("1001"));
        }

        [Test]
        public void Compress_1100_0101_0010()
        {
            var hasher = new Hasher();
            var compressed = hasher.CompressThreeFactors("1100", "0101", "0010");
            var a = "11000101";
            var b = "00110010";
            var xor = hasher.XOR(a, b);
            Assert.AreEqual(xor, compressed);
        }
    }
}
