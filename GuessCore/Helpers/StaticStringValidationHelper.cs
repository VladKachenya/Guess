using System.Text.RegularExpressions;

namespace GuessCore.Helpers
{
    public static class StaticStringValidationHelper
    {
       private static readonly Regex RegexForNameValidation = new Regex(@"^[a-zA-Z0-9_]*$");
        public static bool NameValidation(string name)
        {
            return RegexForNameValidation.Match(name).Success;
        }
    }
}