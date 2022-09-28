using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puntos;
    void Start()
    {
        StartCoroutine(rutinaPuntos());
    }

    public void spawnPoints()
    {
        Vector2 posRandom = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        Instantiate(puntos,posRandom,Quaternion.identity);
    }

    IEnumerator rutinaPuntos()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            spawnPoints();
        }
    }
}
