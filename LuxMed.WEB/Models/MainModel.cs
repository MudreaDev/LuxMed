using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuxMed.Domain.Entities.User;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace LuxMed.Models
{
    public class MainModel
    {
        public UserData User { set; get; }
        public DbSet<UDbTable> Users { set; get; }

        public string MaskEmail(string email)
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
                displayCase = string.Format("{0}*{1}", displayCase[0], displayCase.Substring(2));
            }
            return displayCase;
        }
    }
}