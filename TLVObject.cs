using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHost
{
    class TLVObject
    {
        Dictionary<string, string> tlvDic = new Dictionary<string, string>();
        
        public bool Exist(string tag)
        {
            return tlvDic.ContainsKey(tag);
        }

        private int parse_tlvstring(string tlv)
        {

            return 0;
        }

        public bool parse_tlvBCD(byte[] tlv, int tlv_len)
        {
            return true;
        }

        public void save_tlv(string tlv)
        {
  
        }

        public void save_tvstr(string tag, string value)
        {
            tlvDic.Add(tag, value);
        }

    }
}
