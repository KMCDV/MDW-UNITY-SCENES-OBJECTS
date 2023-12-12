using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneGameObject : MonoBehaviour
{
    public  int sceneNumber;
    private void Start()
    {
        Database.GameObjectsInGame.Add(gameObject);
        var x = new Czlowiek();
        x.age = 50;
        x.age++;
        x.age--;
        x.age *= 2; //100
        
        Debug.Log((++x.age).ToString()); //101
        Debug.Log(Czlowiek.Nation + $"Scena {sceneNumber}");
        Debug.Log(x.age);//101
    }
}

//SINGLETON
//SO