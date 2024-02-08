using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawn : MonoBehaviour
{
    public GameObject spearPrefab;
    public Transform spawn;

    public void CreateSpear()
    {
        Instantiate(spearPrefab, spawn.position, spawn.rotation);
    }
}
