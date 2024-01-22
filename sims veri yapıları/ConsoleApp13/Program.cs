using System;
using System.Collections.Generic;

class SimCharacter
{
    public string Name { get; set; }
    public int Age { get; set; }

    public SimCharacter(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} - Age: {Age}";
    }
}

class SimFamily
{
    public string FamilyName { get; set; }
    public List<SimCharacter> Members { get; set; } = new List<SimCharacter>();

    public SimFamily(string familyName)
    {
        FamilyName = familyName;
    }

    public void AddFamilyMember(SimCharacter member)
    {
        Members.Add(member);
    }

    public void RemoveFamilyMember(SimCharacter member)
    {
        Members.Remove(member);
    }

    public override string ToString()
    {
        return $"Family: {FamilyName}";
    }
}

class SimsWorld
{
    public List<SimCharacter> AllCharacters { get; set; } = new List<SimCharacter>();
    public List<SimFamily> AllFamilies { get; set; } = new List<SimFamily>();

    public void CreateNewFamily(string familyName)
    {
        SimFamily newFamily = new SimFamily(familyName);
        AllFamilies.Add(newFamily);
    }

    public void CreateNewCharacter(string name, int age)
    {
        SimCharacter newCharacter = new SimCharacter(name, age);
        AllCharacters.Add(newCharacter);
    }

    public void AddCharacterToFamily(string characterName, string familyName)
    {
        SimCharacter character = AllCharacters.Find(c => c.Name == characterName);
        SimFamily family = AllFamilies.Find(f => f.FamilyName == familyName);

        if (character != null && family != null)
        {
            family.AddFamilyMember(character);
            Console.WriteLine($"{characterName} successfully added to {familyName}.");
        }
        else
        {
            Console.WriteLine($"Character '{characterName}' or family '{familyName}' not found.");
        }
    }

    public void RemoveCharacterFromFamily(string characterName, string familyName)
    {
        SimCharacter character = AllCharacters.Find(c => c.Name == characterName);
        SimFamily family = AllFamilies.Find(f => f.FamilyName == familyName);

        if (character != null && family != null)
        {
            family.RemoveFamilyMember(character);
            Console.WriteLine($"{characterName} successfully removed from {familyName}.");
        }
        else
        {
            Console.WriteLine($"Character '{characterName}' or family '{familyName}' not found.");
        }
    }

    public void DisplayWorldInfo()
    {
        Console.WriteLine("Sims World Information:");

        foreach (var family in AllFamilies)
        {
            Console.WriteLine(family);
            foreach (var member in family.Members)
            {
                Console.WriteLine($"  - {member}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        SimsWorld simsWorld = new SimsWorld();

        while (true)
        {
            Console.WriteLine("\n----- Sims World Console App -----");
            Console.WriteLine("1. Sims Dünyası Bilgilerini Görüntüle");
            Console.WriteLine("2. Yeni Aile Oluştur");
            Console.WriteLine("3. Yeni Karakter Ekle");
            Console.WriteLine("4. Karakteri Aileye Ekle");
            Console.WriteLine("5. Aileden Karakteri Çıkar");
            Console.WriteLine("6. Çıkış");
            Console.Write("Lütfen bir seçenek girin (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    simsWorld.DisplayWorldInfo();
                    break;

                case "2":
                    Console.Write("Yeni aile adını girin: ");
                    string newFamilyName = Console.ReadLine();
                    simsWorld.CreateNewFamily(newFamilyName);
                    Console.WriteLine($"'{newFamilyName}' adında yeni bir aile oluşturuldu.");
                    break;

                case "3":
                    Console.Write("Yeni karakter adını girin: ");
                    string newCharacterName = Console.ReadLine();
                    Console.Write("Yeni karakter yaşını girin: ");
                    if (int.TryParse(Console.ReadLine(), out int newCharacterAge))
                    {
                        simsWorld.CreateNewCharacter(newCharacterName, newCharacterAge);
                        Console.WriteLine($"'{newCharacterName}' adında yeni bir karakter oluşturuldu.");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz yaş formatı. Karakter oluşturma başarısız.");
                    }
                    break;

                case "4":
                    Console.Write("Eklenecek karakterin adını girin: ");
                    string characterToAdd = Console.ReadLine();
                    Console.Write("Eklenecek ailenin adını girin: ");
                    string familyToAdd = Console.ReadLine();
                    simsWorld.AddCharacterToFamily(characterToAdd, familyToAdd);
                    break;

                case "5":
                    Console.Write("Çıkarılacak karakterin adını girin: ");
                    string characterToRemove = Console.ReadLine();
                    Console.Write("Çıkarılacak ailenin adını girin: ");
                    string familyToRemove = Console.ReadLine();
                    simsWorld.RemoveCharacterFromFamily(characterToRemove, familyToRemove);
                    break;

                case "6":
                    Console.WriteLine("Uygulamadan çıkılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
