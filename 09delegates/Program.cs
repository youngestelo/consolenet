try
{
    dMath dMathObject = new dMath();

    Console.Write("Введите первый операнд: ");
    int InputX = Convert.ToInt32(Console.ReadLine());

    Console.Write("Введите второй операнд: ");
    int InputY = Convert.ToInt32(Console.ReadLine());

    Console.Write("\nВыберите процеруду:\n[Если требуется несколько операций - напишите опции через пробел]\n" +
        "[1] +\n" +
        "[2] -\n" +
        "[3] *\n" +
        "[4] /\n" +
        "[5] **\n" +
        "Ваш выбор: ");
    string? InputOptions = Console.ReadLine();

    if (InputOptions is not null)
    {
        if (InputOptions.Contains(' '))
        {
            string[] splitOperations = InputOptions.Split();
            foreach (string currentSplitOperation in splitOperations)
            {
                dMathObject.RegisterOperation((dMath.Operations)Convert.ToInt32(currentSplitOperation) - 1);
            }

            foreach (var toInvoke in dMathObject.currentOperations!.GetInvocationList())
            {
                var castToInvoke = (dMath.dOperation)toInvoke;
                Console.WriteLine(castToInvoke.Invoke(InputX, InputY));
            }
            return;
        }
        else
        {
            dMathObject.RegisterOperation((dMath.Operations)Convert.ToInt32(InputOptions) - 1);
            Console.WriteLine(dMathObject.currentOperations!.Invoke(InputX, InputY));
            return;
        }
    }
    else throw new Exception();
}
catch (OverflowException)
{ 
    Console.WriteLine("Число превышает рамки Int32!"); return; 
}
catch (Exception)
{ 
    Console.WriteLine("Критическая ошибка!"); return; 
}


class dMath
{
    public delegate int dOperation(int x, int y);
    public dOperation? currentOperations;

    public enum Operations
    {
        Add,
        Subtract,
        Multiply,   
        Divide,
        Pow
    };

    private static int Add     (int x, int y) => x + y;
    private static int Subtract(int x, int y) => x - y;
    private static int Multiply(int x, int y) => x * y;
    private static int Divide  (int x, int y) => x / y;
    private static int Pow     (int x, int y) => Convert.ToInt32(Math.Pow(x, y));

    public void RegisterOperation(Operations Register)
    {
        switch (Register)
        {
            case Operations.Add:      { currentOperations += Add;      return; }
            case Operations.Subtract: { currentOperations += Subtract; return; }
            case Operations.Multiply: { currentOperations += Multiply; return; }
            case Operations.Divide:   { currentOperations += Divide;   return; }
            case Operations.Pow:      { currentOperations += Pow;      return; }
        }
    }

    public int InvokeOperation(int x, int y)
    {
        if (currentOperations is not null)
        { return currentOperations.Invoke(x, y); }

        else
        { Console.WriteLine("Неизвестная операция!"); }

        return 0;
    }
}