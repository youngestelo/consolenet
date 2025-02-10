
Console.ForegroundColor = ConsoleColor.Blue;
Container <int> sampleContainer = new Container <int> ();
Console.WriteLine(sampleContainer.vaultLength);

sampleContainer.addInstance(100);
sampleContainer.addInstance(200);
sampleContainer.addInstance(300);

sampleContainer.displayContainer();
Console.WriteLine(sampleContainer.vaultLength);

sampleContainer.deleteInstance(0);
sampleContainer.displayContainer();
Console.WriteLine(sampleContainer.vaultLength);



Console.ForegroundColor = ConsoleColor.Green;
Container <Unit> unitContainer = new Container <Unit> ();
Console.WriteLine(unitContainer.vaultLength);

unitContainer.addInstance(new ());
unitContainer.addInstance(new ());
unitContainer.addInstance(new ());

unitContainer.displayContainer();
unitContainer.getInstance(0).Health -= 50;
unitContainer.getInstance(1).Health -= 30;
unitContainer.deleteInstance(2);

Console.WriteLine(unitContainer.vaultLength);
unitContainer.displayContainer();

Console.ResetColor();



class Container <Typename>
{
    private List <Typename> vaultContainer;

    public int vaultLength
    { get => vaultContainer.Count; }

    public Container ()
    { vaultContainer = new List <Typename> (); }


    public void displayContainer()
    {
        foreach (Typename Item in vaultContainer)
        { Console.Write($"{Item?.ToString()} "); }

        Console.WriteLine();
    }

    public void addInstance (Typename Instance)
    { vaultContainer.Add(Instance); }

    public void deleteInstance (uint instanceIndex)
    { vaultContainer.RemoveAt(Convert.ToInt32(instanceIndex)); }

    public Typename getInstance (uint instanceIndex)
    { return vaultContainer.ElementAt(Convert.ToInt32(instanceIndex)); }
}


class Unit
{
    public uint Health {get; set;}

    public Unit()
    { Health = 100; }

    public override string ToString()
    { return $"Unit [{Health} HP]"; }
}