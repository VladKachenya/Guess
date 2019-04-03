using System;
using GuessCore.Interfaсes;

namespace GuessCore.Converters
{
    public class ToIntConverter : IConverter<int>
    {
        public int Convert(string str)
        {
            int res;
            try
            {
                res = int.Parse(str);
            }
            catch
            {
                throw new Exception($"Значение {str} не является числом");
            }
            return res;
        }
    }
}