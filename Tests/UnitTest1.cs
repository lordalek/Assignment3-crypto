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
    }
}
