using RefactorMaybe.Console.LinqAll;

namespace RefactorMaybe.Test.LinqAll;

public class IpAddressValidatorTest
{
    [InlineData("abc.123.123.214", false)]
    [InlineData("192.123.155.214.190", false)]
    [InlineData("-20.123.155.214", false)]
    [InlineData("   ", false)]
    [InlineData("0.023.123.123", false)]
    [InlineData(null, false)]
    [MemberData(nameof(ReservedNumbers))]
    [Theory]
    public void Ip4Address_With_Invalid_Input_Will_Fail_With_Declarative_Paradigm(
        string? input,
        bool expected
    )
    {
        bool sut = IpAddressValidator.DeclarativeIsValidIpv4(input);

        Assert.Equal(expected, sut);
    }

    [InlineData("192.168.100.200", true)]
    [InlineData("1.1.1.1", true)]
    [InlineData("1.0.0.0", true)]
    [InlineData("0.123.123.123", true)]
    [Theory]
    public void Accept_Ip4Address_With_Valid_Input_With_Declarative_Paradigm(
        string? input,
        bool expected
    )
    {
        bool sut = IpAddressValidator.DeclarativeIsValidIpv4(input);

        Assert.Equal(expected, sut);
    }

    [InlineData("abc.123.123.214", false)]
    [InlineData("192.123.155.214.190", false)]
    [InlineData("-20.123.155.214", false)]
    [InlineData("   ", false)]
    [InlineData("0.023.123.123", false)]
    [InlineData(null, false)]
    [MemberData(nameof(ReservedNumbers))]
    [Theory]
    public void Ip4Address_With_Invalid_Input_Will_Fail_With_Imperative_Paradigm(
        string? input,
        bool expected
    )
    {
        bool sut = IpAddressValidator.ImperativeIsValidIpv4(input);

        Assert.Equal(expected, sut);
    }

    [InlineData("192.168.100.200", true)]
    [InlineData("1.1.1.1", true)]
    [InlineData("1.0.0.0", true)]
    [InlineData("0.123.123.123", true)]
    [Theory]
    public void Accept_Ip4Address_With_Valid_Input_With_Imperative_Paradigm(
        string? input,
        bool expected
    )
    {
        bool sut = IpAddressValidator.ImperativeIsValidIpv4(input);

        Assert.Equal(expected, sut);
    }

    public static List<object[]> ReservedNumbers()
    {
        IEnumerable<string> reservedNumbers = ["0.0.0.0", "10.0.0.0", "255.255.255.255"];
        return reservedNumbers.Select(x => new object[] { x, false }).ToList();
    }
}
