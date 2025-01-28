const ushort warriorHealth  = 30; // const
const ushort archerHealth   = 27;

const ushort warriorDamage  = 7;
const ushort archerDamage   = 10;

const ushort warriorDefence = 4;
const ushort archerDefence  = 2;

const sbyte warriorScatter  = 3;
const sbyte archerScatter   = 3;

const ushort squadSize = 3;


List<Warrior> Warriors = []; // init warrior's army
List<Archer> Archers = []; // init archer's army

for (int Counter = 0; Counter < squadSize; ++Counter)
{
    Warriors.Add(new Warrior(warriorHealth, warriorDamage, warriorDefence, warriorScatter));
    Archers.Add(new Archer(archerHealth, archerDamage, archerDefence, archerScatter));
}

do // simulation
{
    DisplayUnits();
    Console.WriteLine();
    ActionWarriors();
    Console.WriteLine();
    ActionArchers();

    Console.ResetColor();

    Thread.Sleep(3000);

} while (VerifyWarriors() && VerifyArchers());

Console.Clear();
DisplayUnits();

// funcs
bool VerifyWarriors()
{
    foreach (Warrior Current in Warriors.ToList())
    { if (!Current.Alive) Warriors.Remove(Current); }

    if (Warriors.Count > 0) return true;
    return false;
}

bool VerifyArchers()
{
    foreach (Archer Current in Archers.ToList())
    { if (!Current.Alive) Archers.Remove(Current); }

    if (Archers.Count > 0) return true;
    return false;
}


void DisplayUnits()
{
    Console.Clear(); Console.WriteLine("\x1b[3J");
    for (int Counter = 0; Counter < Warriors.Count; ++Counter)
    { Console.WriteLine($"[{Counter}]  Warrior [{Warriors[Counter].Health} HP]"); }

    Console.WriteLine();

    for (int Counter = 0; Counter < Archers.Count; ++Counter)
    { Console.WriteLine($"[{Counter}]  Archer [{Archers[Counter].Health} HP]"); }
}


void ActionWarriors()
{
    for (int Counter = 0; Counter < Warriors.Count; ++Counter)
    {
        ushort toAttack = (ushort)Random.Shared.Next(0, Archers.Count);
        Warriors[Counter].Attack(Archers[toAttack], toAttack);
    }
}

void ActionArchers()
{
    for (int Counter = 0; Counter < Archers.Count; ++Counter)
    {
        ushort toAttack = (ushort)Random.Shared.Next(0, Warriors.Count);
        Archers[Counter].Attack(Warriors[toAttack], toAttack);
    }
}

// classes
class Unit
{
    public ushort Health;
    public ushort Damage;
    public ushort DefencePower;

    public sbyte  Scatter;

    public bool   Alive;
    
    public Unit(ushort Health, ushort Damage, ushort DefencePower, sbyte Scatter)
    {
        this.Health = Health; 
        this.Damage = Damage;
        this.DefencePower = DefencePower;

        this.Scatter = Scatter; 
        Alive = true;
    }    

    public virtual void Attack(Unit Target, ushort _Index)
    {
        ushort toDeal = (ushort)Random.Shared.Next(Damage - Scatter, Damage + Scatter);
        if (Target.Defence()) { Console.WriteLine($"Unit blocked attack! [-{Target.DefencePower}]"); toDeal -= Target.DefencePower; }

        if (Target.Health >= toDeal && Target.Health - toDeal != 0)
        {
            Target.Health -= toDeal;
            Console.WriteLine($"Dealt {toDeal} damage! Remaining Health: {Target.Health}");
        }
        else
        {
            Console.WriteLine($"Dealt {toDeal} damage! Elimination!");
            Target.Alive = false;
        }
        Console.WriteLine();
    }

    public virtual bool Defence() => Random.Shared.Next(0, 3) == 0;

}

class Archer : Unit
{
    public Archer(ushort Health, ushort Damage, ushort DefencePower, sbyte Scatter) : base(Health, Damage, DefencePower, Scatter) {}


    public override void Attack(Unit warrior, ushort warriorIndex)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Thread.Sleep(1000); Console.WriteLine($"Archer charges at [{warriorIndex}] Warrior!");

        Thread.Sleep(1000); base.Attack(warrior, warriorIndex);
    }
}

class Warrior : Unit
{
    public Warrior(ushort Health, ushort Damage, ushort DefencePower, sbyte Scatter) : base(Health, Damage, DefencePower, Scatter) { }


    public override void Attack(Unit archer, ushort archerIndex)
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        Thread.Sleep(1000); Console.WriteLine($"Warrior charges at [{archerIndex}] Archer!");

        Thread.Sleep(1000); base.Attack(archer, archerIndex);
    }
}
