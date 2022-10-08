using FluentAssertions;

namespace SampleTest;

public class UnitTest
{
    public static IEnumerable<object[]> TestGetPersonItemsData =>
        new List<object[]>
        {
            new object[] { new List<int> { 1, 2, 3 }, 6 }
        };

    [Theory]
    [MemberData(nameof(TestGetPersonItemsData))]
    public void match_sum_of_items_in_list(List<int> actual, int expected)
    {
        var x = 0;
        var newList = actual.Select(s => s * 3);
        actual.Select(s => x += s);
        actual.ForEach(s => x += s);

        int sum = 0;
        sum = actual.Sum();
        //Assert.Equal(sum, expected);
        sum.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestGetPersonItemsData))]
    public void do_not_match_sum_of_items_in_list(List<int> actual, int expected)
    {
        int sum = 0;
        sum = actual.Sum() + 1;
        //Assert.NotEqual(sum + 1, expected);
        sum.Should().NotBe(expected);
    }
}
