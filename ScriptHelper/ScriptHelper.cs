using System.Text.RegularExpressions;


namespace QA.Tools
{
    public class ScriptHelper
    {
        #region Methods
        public static string GetDatabaseName(string script)
        {
            var match = Regex.Match(script, @"(?i)use\s+\[?(\w+)\]?");
            return GetLastCapture(match);
        }

        public static string GetStoredProcedureName(string script)
        {
            var match = Regex.Match(script, @"(?i)\bprocedure\b\s+(?:\[?dbo\]?\.)?\[?(\w+)\]?");
            return GetLastCapture(match);
        }
        #endregion


        #region Implementation
        private static string GetLastCapture(string input, string pattern, RegexOptions options = RegexOptions.None)
        {
            var match = Regex.Match(input, pattern, options);
            return GetLastCapture(match);
        }

        private static string GetLastCapture(Match match)
        {
            return match.Groups[match.Groups.Count - 1].Value;
        }
        #endregion
    }
}