using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHost
{
    class Tool
    {
        public byte[] StringToBCD(string s)
        {
            if (s.Length % 2 != 0)
            {
                // Add a leading zero if the string has an odd length
                s = "0" + s;
            }

            int s_len = s.Length;
            byte[] output = new byte[s_len / 2];

            for (int i = 0; i < s.Length; i += 2)
            {
                // Convert each pair of characters into a byte
                output[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            }

            return output;
        }

        public string BCDToString(byte[] bcd)
        {
            StringBuilder sb = new StringBuilder(bcd.Length * 2);
            foreach (byte b in bcd)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }
    }
}

