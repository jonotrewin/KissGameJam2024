using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGoon : MonoBehaviour
{
    [SerializeField] GameObject RedGoonPrefab;
    [SerializeField] GameObject GreenGoonPrefab;
    [SerializeField] GameObject BlueGoonPrefab;
    [SerializeField] GameObject PolivePrefab;

    //int _countOfGoonsWaiting = 0;

    float _time = 0;
    int _spawnDelay = 10;

    //[SerializeField] Transform _spawnTransform;

    //int[] spawnNumbers = new int[4];

    //Transform[] spawnTransforms = new Transform[4];

    GameObject[] GoonTypes = new GameObject[4];

    private void Start()
    {
        GoonTypes[0] = RedGoonPrefab;
        GoonTypes[1] = GreenGoonPrefab;
        GoonTypes[2] = BlueGoonPrefab;
        GoonTypes[3] = PolivePrefab;

        SpawnGoon();
        //Instantiate(RedGoonPrefab, _spawnTransform);
    }

    private void SpawnGoon()
    {
        System.Random random = new System.Random();

        // Generate a random number between 0 and 3 (inclusive)

        Instantiate(GoonTypes[random.Next(0, 4)], transform.position, Quaternion.identity);
    }

    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _spawnDelay)
        {
            SpawnGoon();

            _time = 0;
        }
    }
}
