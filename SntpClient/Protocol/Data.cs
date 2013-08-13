using System;
using System.Collections.Generic;

/// <summary>
/// A class that represents a SNTP packet.
/// See http://www.faqs.org/rfcs/rfc2030.html for full details of protocol.
/// </summary>
namespace SntpClient.Protocol
{
    public class Data
    {
        private byte[] data;
        private static readonly DateTime Epoch = new DateTime(1900, 1, 1);

        public const int MaximumLength = 68;
        public const int MinimumLength = 48;

        private const byte LeapIndicatorMask = 0xC0;
        private const byte LeapIndicatorOffset = 6;

        private const byte VersionNumberComplementMask = 0xC7;
        private const byte VersionNumberMask = 0x38;
        private const byte VersionNumberOffset = 3;

        private const byte ModeComplementMask = 0xF8;
        private const byte ModeMask = 0x07;

        internal Data(byte[] bytearray)
        {
            if (bytearray.Length >= MinimumLength && bytearray.Length <= MaximumLength)
                data = bytearray;
            else
                throw new ArgumentOutOfRangeException(
                    "Byte Array",
                    string.Format(
                    "Byte array must have a length between {0} and {1}.",
                    MinimumLength, MaximumLength));
        }

        internal Data()
            : this(new byte[48])
        { }
    }
}
