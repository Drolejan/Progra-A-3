using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puntos,avocados,poisons,pantallaInicial,pantallaGame,pantallaGameOver;
    [SerializeField] playerControl funcionesPlayer;
    void Start()
    {
        Time.timeScale = 0;//Empezamos el juego en Pausa
    }

    public void startGame()
    {
        Time.timeScale = 1;//Comenzamos el Juego
        StartCoroutine(rutinaPuntos());
        StartCoroutine(rutinaTimePU());
        StartCoroutine(rutinaEnemies());
        pantallaInicial.SetActive(false);//Apagamos pInicial
        pantallaGame.SetActive(true);//Prendemos pGame
        funcionesPlayer.updateData();
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        StopAllCoroutines();
        pantallaGame.SetActive(false);//Apagamos pGame
        pantallaGameOver.SetActive(true);//Prendemos pGameOver
        funcionesPlayer.updateData();
    }

    public void resetGame()
    {
        Time.timeScale = 1;
        StartCoroutine(rutinaPuntos());
        StartCoroutine(rutinaTimePU());
        StartCoroutine(rutinaEnemies());
        pantallaGameOver.SetActive(false);//Apagamos pGameOver
        pantallaGame.SetActive(true);//Prendemos pGame
        funcionesPlayer.resetGame();
    }

    public void mainMenu()
    {
        pantallaGameOver.SetActive(false);//Apagamos pGameOver
        pantallaInicial.SetActive(true);//Prendemos pGame
        funcionesPlayer.resetGame();
    }

    public void spawnPoints()
    {
        Vector2 posRandom = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        GameObject punto = Instantiate(puntos,posRandom,Quaternion.identity);
        Destroy(punto,3);//Destruir cada 3 segundos
    } 
    public void spawnTimeAvocados()
    {
        Vector2 posRandom = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f));
        GameObject punto = Instantiate(avocados,posRandom,Quaternion.identity);
        Destroy(punto,2.5f);//Destruir cada 2 segundos
    }

    public void spawnPoison()
    {
        Vector2 posRandom = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        GameObject punto = Instantiate(poisons, posRandom, Quaternion.identity);
        Destroy(punto, 1.5f);//Destruir cada 2 segundos
    }

    IEnumerator rutinaPuntos()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            spawnPoints();
        }
    }
    
    IEnumerator rutinaTimePU()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            spawnTimeAvocados();
        }
    }

    IEnumerator rutinaEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            spawnPoison();
        }
    }
}
