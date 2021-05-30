namespace Ereceipt.Application.Extensions
{
    public static class ModelExtensions
    {
        public static bool IsHexColor(this string color)
        {
            if (color is null)
                return false;
            if (color[0] != '#')
            {
                return false;
            }
            if (color.Length != 7)
                return false;
            return true;
        }
    }
}
