﻿namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        private set => _agility = Validator.Limiter(value, 0, 10);
    }

    public void Sing() 
    { 
        Console.WriteLine($"{Name} is singing."); 
        _singCount++;

        if(_singCount%3 == 0) { Agility++; }
    }

    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }

    public override int Power
    {
        get { return 8 * Level + 2 * Agility; }
    }

    public override string Info
    {
        get { return $"{Name} [{Level}][{Agility}]"; }
    }


}