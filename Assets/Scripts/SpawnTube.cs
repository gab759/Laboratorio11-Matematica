using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTube : MonoBehaviour
{
    public GameObject prefab; // El prefab a instanciar
    public float spawnInterval = 2f; // Intervalo de tiempo entre spawns
    public Transform spawnPoint; // Punto de spawn

    private float timer;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnPrefab();
            timer = spawnInterval; // Reiniciar el temporizador
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
