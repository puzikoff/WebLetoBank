using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions; 

namespace WebLetoBank.Utilities
{
    public class OtpReader
    {  
        public static String getOtpFromFile()
        {
            String otp = "334500";            
            //StreamReader reader = new StreamReader(@"\\VM-LETO-MTEST\Leto_sms\sms.txt");
            StreamReader reader = new StreamReader(@"\\VM-LETO-MTEST\c$\LOGS\AM\message_log.txt");
            while (!reader.EndOfStream)
            {
                otp = reader.ReadLine();                
            }
            reader.Close();
            Regex REG = new Regex("[0-9]{6,6}");
            MatchCollection mc = REG.Matches(otp);
            otp = mc[0].Value;
            return otp;
        }
    }
}
