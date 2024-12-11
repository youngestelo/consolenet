using PlainRandom;

// Для удобства!
bool UseLowerCharacters = true;     // Использовать в заполнении нижний регист ?
bool UseCapitalCharacters = false;  // Использовать в заполнении верхний регист ?
bool UseIntegerCharacters = false;  // Использовать в заполнении числа ?
bool UseSpecialCharacters = false;  // Использовать в специальные символы !@#$%^&* ?
ushort SampleStringLength = 10;     // Длина создаваемой строки

string SampleString = StringRandom.CreateString(SampleStringLength, UseLowerCharacters, UseCapitalCharacters, UseIntegerCharacters, UseSpecialCharacters);
Console.ForegroundColor = ConsoleColor.Cyan; 
Console.WriteLine($"Сгенерированная строка: {SampleString}");

// Для удобства!
string InstanceString = "Меня зовут Василий";   // Существующая строка
ushort StartsFrom = 11;                         // Начать измнение с этого индекса
ushort EndsIn = (ushort) InstanceString.Length; // Закончить изменение на этом индексе

Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write($"\nИзначальная строка: {InstanceString}");
InstanceString = StringRandom.EditString(InstanceString, StartsFrom, EndsIn, UseLowerCharacters, UseCapitalCharacters, UseIntegerCharacters, UseSpecialCharacters);
Console.Write($"\nСтрока после измения: {InstanceString}");

// Генерация чисел
int SampleInteger = NumeralRandom.CreateInteger(0, 100);
double SampleDouble = NumeralRandom.CreateDouble(0, 5);
float SampleFloat = NumeralRandom.DoubleToFloat(NumeralRandom.CreateDouble(0, 5));

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n\nInteger: {SampleInteger}\nDouble: {SampleDouble}\nFloat: {SampleFloat}");
Console.ResetColor();
