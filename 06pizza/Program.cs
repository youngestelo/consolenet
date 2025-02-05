
Pizza Offer = new Pizza();

while (true)
{
    try 
    {
        Offer.getCheque();
        Console.WriteLine($"Цена: ${Offer.getPrice()}\n");

        Console.WriteLine("[1] Добавить Сыр Моцарелла ($1.50)\n" +
                          "[2] Добавить Сыр Пармезан ($2.00)\n" +
                          "[3] Добавить Сыр Горгонзола ($2.20)\n\n" +
                          "[4] Добавить Пепперони ($2.00)\n" +
                          "[5] Добавить Ветчину ($1.80)\n" +
                          "[6] Добавить Бекон ($2.50)\n" +
                          "[7] Добавить Курицу ($2.00)\n" +
                          "[8] Добавить Говядину ($2.80)\n\n" +
                          "[9] Добавить Шапиньоны ($1.50)\n" +
                          "[10] Добавить Белые Грибы ($2.50)\n\n" +
                          "[11] Добавить Томаты ($1.00)\n" +
                          "[12] Добавить Перец Болгарский ($1.20)\n" +
                          "[13] Добавить Лук Красный ($1.10)\n" +
                          "[14] Добавить Маслины ($1.50)\n\n" +
                          "[15] Добавить Соус Томатный ($0.80)\n" +
                          "[16] Добавить Соус Барбекю ($1.00)\n" +
                          "[17] Добавить Соус Чесночный ($0.90)\n" +
                          "[18] Добавить Соус Песто ($1.50)\n\n" +
                          "[0] Завершить\n" +
                          "Ваш выбор: "
                          );
        sbyte menuChoice = Convert.ToSByte(Console.ReadLine());

        Offer = menuChoice switch
        {
            1 =>  new DecoratorMozzarella(Offer),
            2 =>  new DecoratorParmezan(Offer),
            3 =>  new DecoratorGorgonzola(Offer),
            4 =>  new DecoratorPepperoni(Offer),
            5 =>  new DecoratorHam(Offer),
            6 =>  new DecoratorBacon(Offer),
            7 =>  new DecoratorChicken(Offer),
            8 =>  new DecoratorBeef(Offer),
            9 =>  new DecoratorChampignons(Offer),
            10 => new DecoratorShrooms(Offer),
            11 => new DecoratorTomatoes(Offer),
            12 => new DecoratorPepper(Offer),
            13 => new DecoratorOnion(Offer),
            14 => new DecoratorOlives(Offer),
            15 => new DecoratorSauceTomato(Offer),
            16 => new DecoratorSauceBarbecue(Offer),
            17 => new DecoratorSauceGarlic(Offer),
            18 => new DecoratorSaucePesto(Offer),
            _ => throw new Exception()
        };
        Console.Clear(); Console.WriteLine("\x1b[3J");
    }
    catch (Exception) 
    { 
        Console.Clear(); 
        Console.WriteLine("\x1b[3J");

        Console.WriteLine("Ваш заказ: ");
        Offer.getCheque();
        Console.WriteLine($"Цена: ${Offer.getPrice()}");
        Console.WriteLine("Приходите ещё! :)");
        return;
    }
    catch { Console.Clear(); Console.WriteLine("\x1b[3J"); continue; }
}



class Pizza
{
    public virtual double getPrice()
    { return 1.00; }

    public virtual void getCheque()
    { Console.WriteLine("Основа для пиццы"); }
}

class DecoratorMozzarella : Pizza
{
    private Pizza Instance;

    public DecoratorMozzarella(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.50; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Сыр Моцарелла"); }
}

class DecoratorParmezan : Pizza
{
    private Pizza Instance;

    public DecoratorParmezan(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 2.00; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Сыр Пармезан"); }
}

class DecoratorGorgonzola : Pizza
{
    private Pizza Instance;

    public DecoratorGorgonzola(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 2.20; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Сыр Горгонзола"); }
}



class DecoratorPepperoni : Pizza
{
    private Pizza Instance;

    public DecoratorPepperoni(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 2.00; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Пепперони"); }
}

class DecoratorHam : Pizza
{
    private Pizza Instance;

    public DecoratorHam(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.80; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Ветчина"); }
}

class DecoratorBacon : Pizza
{
    private Pizza Instance;

    public DecoratorBacon(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 2.50; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Бекон"); }
}

class DecoratorChicken : Pizza
{
    private Pizza Instance;

    public DecoratorChicken(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 2.00; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Курица"); }
}

class DecoratorBeef : Pizza
{
    private Pizza Instance;

    public DecoratorBeef(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 2.00; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Говядина"); }
}


class DecoratorChampignons : Pizza
{
    private Pizza Instance;

    public DecoratorChampignons(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.50; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Шапиньоны"); }
}

class DecoratorShrooms: Pizza
{
    private Pizza Instance;

    public DecoratorShrooms(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 2.50; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Белые Грибы"); }
}



class DecoratorTomatoes : Pizza
{
    private Pizza Instance;

    public DecoratorTomatoes(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.00; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Томаты"); }
}

class DecoratorPepper : Pizza
{
    private Pizza Instance;

    public DecoratorPepper(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.20; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Перец Болгарский"); }
}

class DecoratorOnion : Pizza
{
    private Pizza Instance;

    public DecoratorOnion(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.10; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Лук Красный"); }
}

class DecoratorOlives : Pizza
{
    private Pizza Instance;

    public DecoratorOlives(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.50; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Маслины"); }
}



class DecoratorSauceTomato : Pizza
{
    private Pizza Instance;

    public DecoratorSauceTomato(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 0.80; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Соус Томатный"); }
}

class DecoratorSauceBarbecue : Pizza
{
    private Pizza Instance;

    public DecoratorSauceBarbecue(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.00; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Соус Барбекю"); }
}

class DecoratorSauceGarlic : Pizza
{
    private Pizza Instance;

    public DecoratorSauceGarlic(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 0.90; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Соус Чесночный"); }
}

class DecoratorSaucePesto : Pizza
{
    private Pizza Instance;

    public DecoratorSaucePesto(Pizza Instance)
    { this.Instance = Instance; }

    public override double getPrice()
    { return Instance.getPrice() + 1.50; }

    public override void getCheque()
    { Instance.getCheque(); Console.WriteLine(" -> Соус Песто"); }
}
