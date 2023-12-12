using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Czlowiek
{
    public static string Nation = "POLAK";
    public int age;
    public string firstName;
    public string lastName;
}

public static class Database
{
    public static List<GameObject> GameObjectsInGame = new List<GameObject>();
}
