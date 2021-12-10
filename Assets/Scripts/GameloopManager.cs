using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameloopManager : MonoBehaviour
{
    public int collectedFruits = 0;
    public int maxFruits = 5;
    

    private void Start()
    {
        collectedFruits = 0;
    }

    public void CollectFruit()
    {
        collectedFruits += 1;
        Debug.Log(collectedFruits);

        if (collectedFruits >= maxFruits)
        {
            Debug.Log("U WIN");
        }
    }
}
