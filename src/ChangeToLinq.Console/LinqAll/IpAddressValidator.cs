namespace ChangeToLinq.Console.LinqAll;

public static class IpAddressValidator
{
    public static bool DeclarativeIsValidIpv4(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        string[] segments = input.Split('.');
        const int max = 255;
        const int totalSegment = 4;
        IEnumerable<string> reservedNumber = ["0.0.0.0", "10.0.0.0", "255.255.255.255"];

        return segments.Length == totalSegment
            && !reservedNumber.Contains(input)
            && NoLeadingZero(segments)
            && IsValidNumber(segments);

        static bool NoLeadingZero(IEnumerable<string> strings) =>
            strings.Where(x => x.Length > 1).All(x => x.First() != '0');

        static bool IsValidNumber(IEnumerable<string> strings) =>
            strings.All((s) => int.TryParse(s, out int number) && ValidRange(number));

        static bool ValidRange(int number) => number <= max && number >= 0;
    }

    public static bool ImperativeIsValidIpv4(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        string[] segments = input.Split('.');
        const int max = 255;
        const int totalSegment = 4;
        IEnumerable<string> reservedNumbers = ["0.0.0.0", "10.0.0.0", "255.255.255.255"];

        if (segments.Length != totalSegment)
            return false;

        foreach (string reservedNumber in reservedNumbers)
        {
            if (input == reservedNumber)
                return false;
        }

        foreach (string segment in segments)
        {
            if (segment.Length > 1 && segment[0] == '0')
                return false;

            if (!int.TryParse(segment, out int number))
                return false;

            if (number > max || number < 0)
                return false;
        }

        return true;
    }
}
