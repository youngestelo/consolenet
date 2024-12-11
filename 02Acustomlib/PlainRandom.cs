namespace PlainRandom
{
    static public class StringRandom    // Создание случайных строк
    {
        static private Random Randomizer = new Random();    // Экземпляр класса Random
        static private string InitCollection(bool _Ul, bool _Uc, bool _Ui, bool _Us) // Определить список символов
        {
            string Collection = "abcdefghijklmnopqrstuvwxyz";
            if (!_Ul) Collection = "";
            if (_Uc) Collection += "abcdefghijklmnopqrstuvwxyz".ToUpper();
            if (_Ui) Collection += "1234567890";
            if (_Us) Collection += "!@#$%^&*";
            return Collection;
        }


        static public string CreateString(ushort StringLength = 1, // Создание строки с нуля
            bool UseLower = true,
            bool UseCapitals = false,
            bool UseIntegers = false,
            bool UseSpecial = false)
        {
            string SymbolCollection = InitCollection(UseLower, UseCapitals, UseIntegers, UseSpecial);
            string ResultString = "";

            for (short CurrentPosition = 0; CurrentPosition < StringLength; ++CurrentPosition)
            {
                ushort SymbolCollectionPosition = (ushort)Randomizer.Next(0, SymbolCollection.Length);
                ResultString += SymbolCollection[SymbolCollectionPosition];
            }
            return ResultString;

        }


        static public string EditString(string Instance, ushort StartFrom, ushort FinalPos, // Изменить существующую строку
            bool UseLower = true,
            bool UseCapitals = false,
            bool UseIntegers = false,
            bool UseSpecial = false)
        {
            string SymbolCollection = InitCollection(UseLower, UseCapitals, UseIntegers, UseSpecial);
            string ResultString = "";

            for (short CurrentPosition = 0; CurrentPosition < StartFrom; ++CurrentPosition)
                ResultString += Instance[CurrentPosition];
            for (var CurrentPosition = StartFrom; CurrentPosition < FinalPos; ++CurrentPosition)
            {
                ushort SymbolCollectionPosition = (ushort)Randomizer.Next(0, SymbolCollection.Length);
                ResultString += SymbolCollection[SymbolCollectionPosition];
            }
            for (var CurrentPosition = FinalPos; CurrentPosition < Instance.Length; ++CurrentPosition)
                ResultString += Instance[CurrentPosition];

            return ResultString;
        }

        static internal Random RandomInstance => Randomizer; // Делаем экземпляр в качестве свойства
    }

    static public class NumeralRandom // Создание случайных чисел
    {
        static private Random Randomizer = StringRandom.RandomInstance; // Получаем экземпляр Random из другого класса 

        static public int CreateInteger(int MinValue) => Randomizer.Next(MinValue, 1000000);
        static public int CreateInteger(int MinValue, int MaxValue) => Randomizer.Next(MinValue, MaxValue);

        static public double CreateDouble(double MinValue) => MinValue + Randomizer.NextDouble() * (1000000.0 - MinValue);
        static public double CreateDouble(double MinValue, double MaxValue) => MinValue + Randomizer.NextDouble() * (MaxValue - MinValue);

        static public float DoubleToFloat(double Instance) => (float) Instance;
    }
}
