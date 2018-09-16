using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static float[] feu = { 1, 1.5f,0.5f,0.9f,0.9f };
    private static float[] glace = { 0.5f, 1, 0.9f, 1.5f, 0.9f };
    private static float[] air = { 1.5f, 0.9f, 1, 0.5f, 0.9f };
    private static float[] terre = { 0.9f, 0.5f, 1.5f, 1, 0.9f };
    private static float[] neutre = { 0.9f, 0.9f, 0.9f, 0.9f, 1 };
    public static float[][] eTab ={ feu,glace,air,terre,neutre };
    
}
