using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveElements
{
    public int LevelIndex = -1;
    public float Volume = 0.0f;    
    public float PlayerPositionX = 0f;
    public float PlayerPositionY = 0f;
    public float PlayerPositionZ = 0f;
    public List<String> BooksPickup = null;
    public List<String> PeopleKnown = null;
    public List<String> PandemicItems = null;
    public List<String> CandyItems = null;
    public float Health = -10;
}
