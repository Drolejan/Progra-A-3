using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float magnitud;
    [SerializeField]int puntos;
    
    [SerializeField]
    TextMeshProUGUI scorePlayer;
    [SerializeField]
    TextMeshProUGUI usernamePlayer;
    [SerializeField]
    TextMeshProUGUI mensajeGameOver;
    string user;

    //[SerializeField]public GameObject tablaScores;
    float timer;
    //[SerializeField]baseDatos bdFunctions;
    public GameObject[] objetosPuntos;
    public float limiteTimer;
    
    [SerializeField] GameManager gm;
    
    //Lista de players
    public List<player> players=new List<player>();

    Transform puntoRespawn;

    [SerializeField] DBmanager fireDB;//Hago referencia al script de Firebase
    [SerializeField] TextMeshProUGUI textoTimer;
    [SerializeField] TextMeshProUGUI textoTiros;

    int shots=10;//Oportunidades de Tiro
    void Start()
    {
        puntoRespawn = GameObject.Find("RESPAWN").GetComponent<Transform>();
        //bdFunctions = GameObject.Find("Objeto BD").GetComponent<baseDatos>();
        playerRB = GetComponent<Rigidbody2D>(); 
        puntos = 0;
        //scorePlayer = GameObject.Find("sp").GetComponent<TextMeshProUGUI>();
        timer = limiteTimer;
    }
    
    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1") && Time.timeScale==1)
        {
            if (shots > 0)
            {
                float rx = Random.Range(-5, 5);
                float ry = Random.Range(-5, 5);
                playerRB.AddForce(new Vector2(rx, ry) * magnitud);
                shots--;
            }
        }
        */
        textoTiros.text = "TIROS: " + shots.ToString();
        textoTimer.text = "TIME: "+Mathf.RoundToInt(limiteTimer);
        limiteTimer -= Time.deltaTime;

        if (limiteTimer<0)
        {
            Time.timeScale = 0;
            //tablaScores.SetActive(true);
            //bdFunctions.addMyScore(puntos);
            limiteTimer += timer;
            shots = 10;
            gm.gameOver();//Activamos la funcion game over del GM
            player currentP = new player 
            { 
                name = usernamePlayer.text, 
                score = puntos 
            };
            //Una vez creado, debo de convertirlo para BD
            string playerBD = JsonUtility.ToJson(currentP);
            Debug.Log(playerBD);
            players.Add(currentP);//Se agrega a la lista interna
            //Codigo para el Respawn
            transform.position = puntoRespawn.position;
            playerRB.velocity = Vector2.zero;
            //Usuario con Num Aleatorio
            string userRandDB = currentP.name+Random.Range(1000,9999);
            //Agregar codigo para BD Firebase
            fireDB.uploadData(userRandDB,playerBD);
        }
    }

    public void updateData()
    {
        scorePlayer.text = usernamePlayer.text + " : " + puntos;
        mensajeGameOver.text = usernamePlayer.text + " : " + puntos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Points"))
        {
            Debug.Log("Sume Puntos");//Sumamos puntos
            puntos++;
            scorePlayer.text = usernamePlayer.text +" : "+ puntos;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Poison"))
        {
            Debug.Log("Perdi Puntos");//Sumamos puntos
            puntos--;
            scorePlayer.text = usernamePlayer.text + " : " + puntos;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Time"))
        {
            Debug.Log("Extra Time");//Sumamos puntos
            limiteTimer+=3f;
            shots++;
            collision.gameObject.SetActive(false);
        }

    }

    public void resetGame() {
        //Reseteo score
        puntos = 0;
        updateData();
        //Reseteo puntos
        objetosPuntos = GameObject.FindGameObjectsWithTag("Points");
        foreach (GameObject op in objetosPuntos)
        {
            op.SetActive(false);
        }
        //Aqui podriamos colocar el reseteo de la posición del player
    }

    private void OnMouseDown()
    {
            if (shots > 0 && Time.timeScale == 1)
            {
                float rx = Random.Range(-5, 5);
                float ry = Random.Range(-5, 5);
                playerRB.AddForce(new Vector2(rx, ry) * magnitud);
                shots--;
            }
    }

}


