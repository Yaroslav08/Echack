using Ereceipt.Application.Extensions;
using Xunit;
namespace Ereceipt.Tests.Extensions
{
    public class HexExtensionTests
    {
        [Fact]
        public void Check_Color_Is_Valid()
        {
            var color = "#1c64d9";
            var result = color.IsHexColor();
            Assert.True(result);
        }

        [Fact]
        public void Check_Color_Is_NotValid_By_Length()
        {
            var color = "#1c64d";
            var result = color.IsHexColor();
            Assert.False(result);
        }

        [Fact]
        public void Check_Color_Is_First_Symbol_NotValid()
        {
            var color = "@1c64d9";
            var result = color.IsHexColor();
            Assert.False(result);
        }

        [Fact]
        public void Check_Color_On_All_Requirements()
        {
            var color = "@1c649";
            var result = color.IsHexColor();
            Assert.False(result);
        }
    }
}