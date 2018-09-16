using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static float[] feu = { 1, 1.5f, 0.5f, 0.9f, 0.9f };
    private static float[] glace = { 0.5f, 1, 0.9f, 1.5f, 0.9f };
    private static float[] air = { 1.5f, 0.9f, 1, 0.5f, 0.9f };
    private static float[] terre = { 0.9f, 0.5f, 1.5f, 1, 0.9f };
    private static float[] neutre = { 0.9f, 0.9f, 0.9f, 0.9f, 1 };
    public static float[][] eTab = { feu, glace, air, terre, neutre };

    [SerializeField]
    public static GameObject[] alltowers;
    public static Tour neutral = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.neutre, alltowers[0]);
    public static Tour fire = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.feu, alltowers[1]);
    public static Tour ice = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.eau, alltowers[4]);
    public static Tour nature = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.terre, alltowers[2]);
    public static Tour wind = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.air, alltowers[3]);
    public static List<Tour> toursAchetables = new List<Tour> { neutral, fire, ice, nature, wind };
}
