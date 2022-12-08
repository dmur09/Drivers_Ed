using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePickupsAndObs : MonoBehaviour
{
    public PlaceAtStart PlaceAtStart;
    public SpriteRenderer Mushroom1;
    public SpriteRenderer Mushroom2;
    public SpriteRenderer Mushroom3;
    public SpriteRenderer Beer1;
    public SpriteRenderer Beer2;
    public SpriteRenderer Beer3;
    public SpriteRenderer PotLeaf1;
    public SpriteRenderer PotLeaf2;
    public SpriteRenderer PotLeaf3;
    public SpriteRenderer Redbull1;
    public SpriteRenderer Redbull2;
    public SpriteRenderer Redbull3;
    public SpriteRenderer GoldCoin1;
    public SpriteRenderer GoldCoin2;
    public SpriteRenderer GoldCoin3;
    public SpriteRenderer GoldCoin4;
    public SpriteRenderer GoldCoin5;
    public SpriteRenderer SilverCoin;
    public SpriteRenderer Crosswalk;
    public List<SpriteRenderer> Shapes; 
    
    void Start()
    {
        PlaceAtStart.Place(Mushroom1, Mushroom2, Mushroom3, Beer1, Beer2, Beer3, PotLeaf1, PotLeaf2, PotLeaf3, Redbull1, 
            Redbull2, Redbull3, GoldCoin1, GoldCoin2, GoldCoin3, GoldCoin4, GoldCoin5, SilverCoin, Crosswalk, Shapes);
    }
}
