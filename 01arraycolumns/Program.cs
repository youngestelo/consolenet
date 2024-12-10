const int M = 5, N = 5; // Строки и столбики
int[,] BasicArray = new int[M, N];

Console.WriteLine("Первоначальный массив: ");

Console.ForegroundColor = ConsoleColor.Magenta; // Выводим номер столбика для удобства
for (int i = 1; i < N + 1; ++i)
    Console.Write($"{i}\t");
Console.ResetColor();

Console.WriteLine();
for (int i = 0; i < M; ++i) // Заполняем массив случайными числами и выводим значения
{
    for (int j = 0; j < N; ++j)
    {
        BasicArray[i, j] = Random.Shared.Next(10, 50);
        Console.Write($"{BasicArray[i, j]}\t");
    }
    Console.WriteLine();
}

int InputColumnSwitch, InputColumnSwitchTo; // Столбики для перестановки
Console.Write("\n\nКакой столбик желаете поменять?\nВаш выбор: ");
InputColumnSwitch = Convert.ToInt16(Console.ReadLine()); // Конвертируем число после ввода

if (InputColumnSwitch > N || InputColumnSwitch < 1) { Console.Write("Ошибка!"); return; } // Заканчиваем программу если значения выходят за границы

Console.Write($"\n{InputColumnSwitch}-й меняем на столбик под номером...\nВаш выбор: ");
InputColumnSwitchTo = Convert.ToInt16(Console.ReadLine()); // Конвертируем число после ввода

if (InputColumnSwitchTo > N || InputColumnSwitchTo < 1) { Console.Write("Ошибка!"); return; }

--InputColumnSwitch; --InputColumnSwitchTo; // Отнимаем от пользовательских столбиков 1, чтобы была возможность обращаться к массиву
for (int i = 0; i < M; ++i) // Используем кортеж и меняем значения местами
    (BasicArray[i, InputColumnSwitch], BasicArray[i, InputColumnSwitchTo]) = (BasicArray[i, InputColumnSwitchTo], BasicArray[i, InputColumnSwitch]);

Console.WriteLine("\nМассив с перестановкой столбиков: ");
for (int i = 0; i < M; ++i) // Выводим новый массив
{
    for (int j = 0; j < N; ++j)
        Console.Write($"{BasicArray[i, j]}\t");
    Console.WriteLine();
}