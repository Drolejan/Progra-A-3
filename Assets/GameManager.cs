using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puntos,pantallaInicial,pantallaGame,pantallaGameOver;
    void Start()
    {
        Time.timeScale = 0;//Empezamos el juego en Pausa
    }

    public void startGame()
    {
        Time.timeScale = 1;//Comenzamos el Juego
        StartCoroutine(rutinaPuntos());
        pantallaInicial.SetActive(false);//Apagamos pInicial
        pantallaGame.SetActive(true);//Prendemos pGame
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        StopAllCoroutines();
        pantallaGame.SetActive(false);//Apagamos pGame
        pantallaGameOver.SetActive(true);//Prendemos pGameOver
    }

    public void resetGame()
    {
        Time.timeScale = 1;
        StartCoroutine(rutinaPuntos());
        pantallaGameOver.SetActive(false);//Apagamos pGameOver
        pantallaGame.SetActive(true);//Prendemos pGame
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
