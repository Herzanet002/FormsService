using System.Text.RegularExpressions;

namespace MailService.Helpers
{
    public static class MailServiceHelper
    {
        public static string GetJsonFromHtml(this string htmlText)
        {
            var jsonRegex = new Regex("{(.*?)}", RegexOptions.Compiled);
            var jsonString = jsonRegex.Match(htmlText).Value;

            var unescaped = Regex.Unescape(jsonString);
            var withoutQuot = Regex.Replace(unescaped, "&quot;", @"""").Trim();

            return withoutQuot;
        }
    }
}