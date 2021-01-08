using System.Collections.Generic;

namespace L2P_RPG_GOI.Helpers
{
    public static class PrintHelpers
    {
        public static string FormatMultipleStringsToMultilineString(List<string> messages)
        {
            var result = "";
            for (int i = 0; i < messages.Count; i++)
            {
                if (i != 0)
                    result += "\n";
                result += messages[i];
            }
            return result;
        }
    }
}
