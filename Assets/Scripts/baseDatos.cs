using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class baseDatos : MonoBehaviour
{
    GameObject contenedor;
    GameObject datosCanvas;
    public playerControl datosPlayer;
    void Start()
    {
        contenedor = GameObject.Find("Contenedor Scores");
        
    }

    public GameObject infoPlayer;
    [SerializeField]List<float> scores;
    TextMeshProUGUI textoScore;//Es probable que lo necesitemos mas tarde
    public void addPlayer()
    {
        GameObject player;
        Debug.Log("He creado un player");
        contenedor = GameObject.Find("Contenedor Scores");
        player = Instantiate(infoPlayer,contenedor.transform);
        float scoreRandom = Random.Range(0, 1000);
        scores.Add(scoreRandom);
        player.GetComponent<TextMeshProUGUI>().text = scoreRandom.ToString();
    }

    public void addMyScore(float puntos)
    {
        GameObject player;
        contenedor = GameObject.Find("Contenedor Scores");
        player = Instantiate(infoPlayer, contenedor.transform);
        scores.Add(puntos);
        player.GetComponent<TextMeshProUGUI>().text = puntos.ToString();
    }

    [SerializeField] GameObject[] objetosPlayers;
    public void ordenarScores()
    {
        scores.Sort();
        objetosPlayers = GameObject.FindGameObjectsWithTag("inputPlayer");
        for (int i = 0; i < objetosPlayers.Length; i++)
        {
            objetosPlayers[i].GetComponent<TextMeshProUGUI>().text = scores[i].ToString();
        }
    }

    public void ordenarScoresReversa()
    {
        scores.Sort();
        scores.Reverse();
        objetosPlayers = GameObject.FindGameObjectsWithTag("inputPlayer");
        for (int i = 0; i < objetosPlayers.Length; i++)
        {
            objetosPlayers[i].GetComponent<TextMeshProUGUI>().text = scores[i].ToString();
        }
    }

    public void Reiniciar()
    {
        //SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        datosCanvas = GameObject.Find("PantallaHighScores");
        datosCanvas.gameObject.SetActive(false);
        //Reiniciar el score
        //Regenerar los puntos
        datosPlayer.resetGame();

    }
}
