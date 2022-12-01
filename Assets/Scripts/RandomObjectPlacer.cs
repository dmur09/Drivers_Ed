using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
    public GameObject ObjectPrefab;
    private bool isOkToPlace = true;
    protected int minimumSecondsToCreation = 2;
    protected int maximumSecondsToCreation = 7;
    private Coroutine timerCoroutine;

    void Update()
    {
        if (IsPlaying())
        {
            if (isOkToPlace)
            {
                timerCoroutine = StartCoroutine(CountdownUntilCreation());
                isOkToPlace = false;
            }
        }
    }

    private bool IsPlaying()
    {
        if (Game.IsRunning())
        {
            return true;
        }
        else
        {
            Reset();
            return false;
        }
    }

    private void Reset()
    {
        isOkToPlace = true;
        DeleteAllObjects();
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        
    }

    private void DeleteAllObjects()
    {
        foreach (GameObject objectToDelete in GameObject.FindGameObjectsWithTag(ObjectPrefab.tag))
        {
            Destroy(objectToDelete);
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        int secondsToWait = Random.Range(minimumSecondsToCreation, maximumSecondsToCreation + 1);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isOkToPlace = true;
    }

    public virtual void Place()
    {
        Vector3 location = SpriteTools.RandomTrackWorldLocation();
        Instantiate(ObjectPrefab, location, Quaternion.identity);
    }
}
