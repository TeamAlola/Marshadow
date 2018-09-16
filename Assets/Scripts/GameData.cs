using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    
    public float[,] eTab = { { 1, 1.5f, 0.5f, 0.9f, 0.9f },
                               { 0.5f, 1, 0.9f, 1.5f, 0.9f } , 
                               { 1.5f, 0.9f, 1, 0.5f, 0.9f },
                               { 0.9f, 0.5f, 1.5f, 1, 0.9f },
                               { 0.9f, 0.9f, 0.9f, 0.9f, 1 }};

    [SerializeField]
    public static GameObject[] alltowers;
    public static List<Tour> toursAchetables = new List<Tour> { new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.neutre, alltowers[0]),
                                                                new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.feu, alltowers[1]),
                                                                new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.eau, alltowers[4]),
                                                                new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.terre, alltowers[2]),
                                                                new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.air, alltowers[3]) };
    
    
}
