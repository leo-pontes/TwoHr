using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TwoHr.Pages;

public class Index_Tests : TwoHrWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
