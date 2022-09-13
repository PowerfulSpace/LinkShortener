using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.LinkShortening.Service.Models.Settings
{
    public class UrlSettings
    {
        public string? OverrideUrl { get; set; } = null!;
        public int KeyLength { get; set; } = 5;
        public string KeyChars { get; set; } = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
