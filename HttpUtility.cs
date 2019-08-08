using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Http_Utility
{
    public static class HttpUtility
    {
        public static string GetInputValueFromId(string html, string inputId)
        {
            var pattern = $"<input.*?id=[\"']{inputId}[\"'].*?value=[\"'](.*?)[\"']";
            var match = Regex.Match(html, pattern);
            if (!match.Success)
            {
                throw new Exception("Regex mismatch.");
            }
            return match.Groups[1].Value;
        }

        public static string GetInputValueFromName(string html, string inputName)
        {
            var pattern = $"<input.*?name=[\"']{inputName}[\"'].*?value=[\"'](.*?)[\"']";
            var match = Regex.Match(html, pattern);
            if (!match.Success)
            {
                throw new Exception("Regex mismatch.");
            }
            return match.Groups[1].Value;
        }

        public static string GetInputNameFromId(string html, string inputId)
        {
            var pattern = $"<input.*?id=[\"']{inputId}[\"'].*?name=[\"'](.*?)[\"']";
            var match = Regex.Match(html, pattern);
            if (!match.Success)
            {
                throw new Exception("Regex mismatch.");
            }
            return match.Groups[1].Value;
        }

        public static List<KeyValuePair<string, string>> GetFormInputValues(string html)
        {
            var valuePairs = new List<KeyValuePair<string, string>>();
            var matches = Regex.Matches(html, "input.*?name=[\\\"'](.*?)[\\\"'].*?value=[\\\"'](.*?)[\\\"']");
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    valuePairs.Add(new KeyValuePair<string, string>(m.Groups[1].Value, m.Groups[2].Value));
                }
            }

            return valuePairs;
        }

        public static string GetRecaptchaSiteKey(string html)
        {
            var reg = new Regex("data-sitekey=\"(.*?)\"");
            return reg.IsMatch(html) ? reg.Match(html).Groups[1].Value : null;
        }
    }
}
