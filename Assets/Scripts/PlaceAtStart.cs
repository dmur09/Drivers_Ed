using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAtStart : MonoBehaviour
{
    public void Place(SpriteRenderer Mushroom, SpriteRenderer Beer, SpriteRenderer Redbull,
        List<SpriteRenderer> Shapes)
    {
        PlaceItemRandomlyInRandomShape(Mushroom, Shapes);
        PlaceItemRandomlyInRandomShape(Beer, Shapes);
        PlaceItemRandomlyInRandomShape(Redbull, Shapes);
    }   

    public void PlaceItemRandomlyInRandomShape(SpriteRenderer objectToPlace, List<SpriteRenderer> shapesToPlaceIn)
    {
        SpriteRenderer areaShape = PickRandomShape(shapesToPlaceIn);
        //objectToPlace.transform.position = GetRandomPositionInShape(areaShape);
        Instantiate(objectToPlace, GetRandomPositionInShape(areaShape), Quaternion.identity);
    }
    
    public void PlaceItemInCenterOfRandomShape(SpriteRenderer objectToPlace, List<SpriteRenderer> shapesToPlaceIn)
    {
        SpriteRenderer areaShape = PickRandomShape(shapesToPlaceIn);
        objectToPlace.transform.position = GetCenterPositionInShape(areaShape);
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
