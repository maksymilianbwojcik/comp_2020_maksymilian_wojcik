using Blazor.Shared;
using Xunit;

namespace Test
{
    public class NavMenuTest
    {
        [Fact]
        public void ToggleNavMenuTest()
        {
            var menu = new NavMenu();
            Assert.True(menu.CollapseNavMenu);
            Assert.Equal("collapse", menu.NavMenuCssClass);
            
            menu.ToggleNavMenu();
            Assert.False(menu.CollapseNavMenu);
            Assert.Null(menu.NavMenuCssClass);
        }
    }
}