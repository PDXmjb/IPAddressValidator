namespace Solution
{
    using System;
    using System.Linq;
    class Kata
    {
        public static bool is_valid_IP(string ipAddress)
        {
            var octets = ipAddress.Split('.');

            // If the given string is empty or of the wrong length, it is invalid.
            var valid = ipAddress == String.Empty || octets.Length != 4 ? false : true;

            foreach (var o in octets.Where(x => x != String.Empty))
            {
                int i = 0;
                var isInt = Int32.TryParse(o, out i);
                var hasLeadingZero = o[0] == '0' && i > 0;
                var isOutsideOfBounds = i < 0 || i > 255;
                var containsSpaces = o.Contains(' ');

                // String has to a) be an integer; b) not have a leading zero if it's a number,
                // c) be from 0-255; d) contain no spaces.
                if (!isInt || hasLeadingZero || isOutsideOfBounds || containsSpaces)
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }
    }
}