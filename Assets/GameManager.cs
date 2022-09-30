using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puntos,pantallaInicial,pantallaGame,pantallaGameOver;
    void Start()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(rutinaPuntos());
    }

    public void gameOver()
    {
        StopAllCoroutines();
    }

    public void spawnPoints()
    {
        Vector2 posRandom = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        GameObject punto = Instantiate(puntos,posRandom,Quaternion.identity);
        Destroy(punto,3);//Destruir cada 3 segundos
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
