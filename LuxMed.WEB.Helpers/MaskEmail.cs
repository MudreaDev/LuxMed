using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LuxMed.WEB.Helpers
{
    public class MaskEmail
    {
        public string EmailMask(string email)
        {
            var displayCase = email;
            var partToBeObfuscated = Regex.Match(displayCase, @"[^@]*").Value;
            if (partToBeObfuscated.Length - 3 > 0)
            {
                var obfuscation = "";
                for (var i = 0; i < partToBeObfuscated.Length - 3; i++) obfuscation += "*";
                displayCase = String.Format("{0}{1}{2}{3}", displayCase[0], obfuscation[1], obfuscation, displayCase.Substring(partToBeObfuscated.Length - 1));
            }
            else if (partToBeObfuscated.Length - 3 == 0)
            {
                displayCase = String.Format("{0}*{1}", displayCase[0], displayCase.Substring(2));
            }
            return displayCase;
        }
    }
}
