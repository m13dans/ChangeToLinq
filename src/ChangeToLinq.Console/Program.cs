using static ChangeToLinq.Console.LinqAll.IpAddressValidator;

Console.WriteLine("Enter Ipv4 address : ");

string? userInput = "10.055.123.1";
Console.WriteLine($"User Input is {userInput}");

string imperativeResponse = ImperativeIsValidIpv4(userInput)
    ? $"{userInput} is valid Ipv4 Address with Imperative"
    : $"{userInput} is NOT valid Ipv4 Address with Imperative";

Console.WriteLine(imperativeResponse);

string declarativeResponse = DeclarativeIsValidIpv4(userInput)
    ? $"{userInput} is valid Ipv4 Address with Declarative"
    : $"{userInput} is NOT valid Ipv4 Address with Declarative";

Console.WriteLine(declarativeResponse);
