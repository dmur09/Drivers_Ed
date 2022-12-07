using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePickupsAndObs : MonoBehaviour
{
    public PlaceAtStart PlaceAtStart;
    public SpriteRenderer Mushroom;
    public SpriteRenderer Beer;
    public SpriteRenderer Redbull;
    public List<SpriteRenderer> Shapes; 
    
    void Start()
    {
        PlaceAtStart.Place(Mushroom, Beer, Redbull, Shapes);
    }
}
