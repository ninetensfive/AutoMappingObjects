using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMappingObjects.Client.Utilities
{
    public static class InputParser
    {       
        public static string[] SplitInput(this string input)
        {
            var result = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);                 

            return result;
        }
    }
}
