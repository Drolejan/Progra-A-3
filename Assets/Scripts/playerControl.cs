using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float magnitud;
    [SerializeField]int puntos;
    TextMeshProUGUI scorePlayer;
    public GameObject tablaScores;
    float timer;
    baseDatos bdFunctions;
    public GameObject[] objetosPuntos;
    public float limiteTimer;
    void Start()
    {
        //bdFunctions = GameObject.Find("Objeto BD").GetComponent<baseDatos>();
        playerRB = GetComponent<Rigidbody2D>(); 
        puntos = 0;
        //scorePlayer = GameObject.Find("sp").GetComponent<TextMeshProUGUI>();
        //objetosPuntos = GameObject.FindGameObjectsWithTag("Points");
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale==1)
        {
            float rx = Random.Range(-5, 5);
            float ry = Random.Range(-5, 5);
            playerRB.AddForce(new Vector2(rx,ry)*magnitud);
        }

        timer += Time.deltaTime;

        if (timer > limiteTimer)
        {
            Time.timeScale = 0;
            //tablaScores.SetActive(true);
            //bdFunctions.addMyScore(puntos);
            timer -= limiteTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Points"))
        {
            Debug.Log("Sume Puntos");//Sumamos puntos
            puntos++;
            //scorePlayer.text = "Puntos: " + puntos;
            //Destroy(collision.gameObject);//Destruimos el objeto
            //Desactivamos el objeto
            collision.gameObject.SetActive(false);
        }
    }

    public void resetGame() {
        //Reseteo score
        puntos = 0;
        scorePlayer.text = "Puntos: " + puntos;
        //Reseteo puntos
        foreach (GameObject op in objetosPuntos)
        {
            op.SetActive(true);
        }
        //Aqui podriamos colocar el reseteo de la posición del player
    }
}
