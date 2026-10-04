using System;

interface IAbility
{
    void Use(string characterName);
}

class PhysicalAttack : IAbility
{
    public void Use(string characterName)
    {
        Console.WriteLine($"{characterName} использует физическую атаку!");
    }
}

class FireAttack : IAbility
{
    public void Use(string characterName)
    {
        Console.WriteLine($"{characterName} использует огненную атаку!");
    }
}

class IceAttack : IAbility
{
    public void Use(string characterName)
    {
        Console.WriteLine($"{characterName} использует ледяную атаку!");
    }
}

abstract class Character
{
    protected IAbility ability;
    protected string name;

    public Character(string name, IAbility ability)
    {
        this.name = name;
        this.ability = ability;
    }

    public virtual void UseAbility()
    {
        ability.Use(name);
    }
}

class Warrior : Character
{
    public Warrior(IAbility ability) : base("Воин", ability)
    {
    }
}

class Mage : Character
{
    public Mage(IAbility ability) : base("Маг", ability)
    {
    }
}

class Archer : Character
{
    public Archer(IAbility ability) : base("Лучник", ability)
    {
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("=== RPG ===");

        // Создаём объекты способностей
        IAbility physicalAttack = new PhysicalAttack();
        IAbility fireAttack = new FireAttack();
        IAbility iceAttack = new IceAttack();

        // Воин
        Character warrior1 = new Warrior(physicalAttack);
        warrior1.UseAbility();

        Character warrior2 = new Warrior(fireAttack);
        warrior2.UseAbility();

        // Маг
        Character mage1 = new Mage(fireAttack);
        mage1.UseAbility();

        Character mage2 = new Mage(iceAttack);
        mage2.UseAbility();

        // Лучник
        Character archer1 = new Archer(physicalAttack);
        archer1.UseAbility();

        Character archer2 = new Archer(iceAttack);
        archer2.UseAbility();
    }
}