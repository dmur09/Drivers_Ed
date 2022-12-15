using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAtStart : MonoBehaviour
{
    public void Place(SpriteRenderer Mushroom1, SpriteRenderer Mushroom2, SpriteRenderer Mushroom3, SpriteRenderer Beer1, SpriteRenderer Beer2, 
        SpriteRenderer Beer3, SpriteRenderer PotLeaf1, SpriteRenderer PotLeaf2, SpriteRenderer PotLeaf3, SpriteRenderer Redbull1, SpriteRenderer Redbull2, 
        SpriteRenderer Redbull3, SpriteRenderer GoldCoin1, SpriteRenderer GoldCoin2, SpriteRenderer GoldCoin3, SpriteRenderer GoldCoin4, SpriteRenderer GoldCoin5, SpriteRenderer SilverCoin, 
        SpriteRenderer StopSign1, SpriteRenderer StopSign2, SpriteRenderer StopSign3, List<SpriteRenderer> Shapes)
    {
        PlaceItemRandomlyInRandomShape(Mushroom1, Shapes);
        PlaceItemRandomlyInRandomShape(Mushroom2, Shapes);
        PlaceItemRandomlyInRandomShape(Mushroom3, Shapes);
        PlaceItemRandomlyInRandomShape(Beer1, Shapes);
        PlaceItemRandomlyInRandomShape(Beer2, Shapes);
        PlaceItemRandomlyInRandomShape(Beer3, Shapes);
        PlaceItemRandomlyInRandomShape(PotLeaf1, Shapes);
        PlaceItemRandomlyInRandomShape(PotLeaf2, Shapes);
        PlaceItemRandomlyInRandomShape(PotLeaf3, Shapes);
        PlaceItemRandomlyInRandomShape(Redbull1, Shapes);
        PlaceItemRandomlyInRandomShape(Redbull2, Shapes);
        PlaceItemRandomlyInRandomShape(Redbull3, Shapes);
        PlaceItemRandomlyInRandomShape(GoldCoin1, Shapes);
        PlaceItemRandomlyInRandomShape(GoldCoin2, Shapes);
        PlaceItemRandomlyInRandomShape(GoldCoin3, Shapes);
        PlaceItemRandomlyInRandomShape(GoldCoin4, Shapes);
        PlaceItemRandomlyInRandomShape(GoldCoin5, Shapes);
        PlaceItemRandomlyInRandomShape(SilverCoin, Shapes);
        PlaceItemRandomlyInRandomShape(StopSign1, Shapes);
        PlaceItemRandomlyInRandomShape(StopSign2, Shapes);
        PlaceItemRandomlyInRandomShape(StopSign3, Shapes);
    }   

    public void PlaceItemRandomlyInRandomShape(SpriteRenderer objectToPlace, List<SpriteRenderer> shapesToPlaceIn)
    {
        SpriteRenderer areaShape = PickRandomShape(shapesToPlaceIn);
        Instantiate(objectToPlace, GetRandomPositionInShape(areaShape), Quaternion.identity);
    }
    
    public void PlaceItemInCenterOfRandomShape(SpriteRenderer objectToPlace, List<SpriteRenderer> shapesToPlaceIn)
    {
        SpriteRenderer areaShape = PickRandomShape(shapesToPlaceIn);
        Instantiate(objectToPlace, GetCenterPositionInShape(areaShape), Quaternion.identity);
    }

    private SpriteRenderer PickRandomShape(List<SpriteRenderer> shapesToPlaceIn)
    {
        return shapesToPlaceIn[Random.Range(0, shapesToPlaceIn.Count)];
    }

    public Vector2 GetCenterPositionInShape(SpriteRenderer areaShape)
    {
        Vector2 rectPos = areaShape.transform.position;
        return rectPos;
    }
    
    public Vector2 GetRandomPositionInShape(SpriteRenderer areaShape)
    {
        Vector2 rectPos = areaShape.transform.position;
        float rectHeight = areaShape.sprite.bounds.extents.y;
        float rectWidth = areaShape.sprite.bounds.extents.x;
        float xpos = rectPos.x + Random.Range(-rectWidth, rectWidth);
        float ypos = rectPos.y + Random.Range(-rectHeight, rectHeight);
        
        return new Vector2(xpos, ypos);
    }
}
