using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    //Script de Introducción 24 08 2022
    float calificacion; //Esta es privada
    public int edad; // Esta es publica
    [SerializeField] string nombre; // Esta es privada pero modificable por el editor
    [SerializeField] int[] edades;
    [SerializeField] List<string> nombres;
    void Start()
    {
        edad = 11;
        nombre = "Pedro";
        Debug.Log(nombre);
        edades = new int[6];
        edades[0] = 15;
        edades[5] = 50;
        //edades[6] = 99; //Este indice no existe
        nombres.Add("Charlo");
        nombres.Add("Alexco");
        nombres.Add("Juan");
        nombres.Sort();
        nombres.Reverse();
    }

    void Update()
    {
        
    }
}
