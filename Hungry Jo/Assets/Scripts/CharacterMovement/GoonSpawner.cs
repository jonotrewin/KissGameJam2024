using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonSpawner : MonoBehaviour
{
    [SerializeField] GameObject RedGoonPrefab;
    [SerializeField] GameObject GreenGoonPrefab;
    [SerializeField] GameObject BlueGoonPrefab;
    [SerializeField] GameObject PolivePrefab;

    int _countOfGoonsWaiting = 0;

    float _time = 0;
    int _spawnDelay = 5;

    [SerializeField] Transform _spawnTransform;

    //int[] spawnNumbers = new int[4];

    //Transform[] spawnTransforms = new Transform[4];

    private void Start()
    {
        //SpawnGoon();
        //Instantiate(RedGoonPrefab, _spawnTransform);
    }

    //private void SpawnGoon()
    //{
    //    Instantiate
    //}

    void Update()
    {
        
    }
}
