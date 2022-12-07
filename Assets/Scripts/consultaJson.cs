using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;//Esta es para hacer WebRequest

public class consultaJson : MonoBehaviour
{
    string miLink;
    void Start()
    {
        miLink = "Aqui ponen su link";
        //StartCoroutine(GetData());
        StartCoroutine(GetWeather());
    }

    IEnumerator GetData()
    {
        //UnityWebRequest www = UnityWebRequest.Get("InsertarLinkConsulta");
        UnityWebRequest www = UnityWebRequest.Get(miLink);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }

    IEnumerator GetWeather()
    {
        UnityWebRequest www = UnityWebRequest.Get(miLink);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
            actualWeather = 800;
        }
        else
        {
            JsonData jsonData = JsonMapper.ToObject(www.downloadHandler.text);
            Debug.Log(jsonData);
            actualWeather = (int)jsonData["weather"][0]["id"];
        }

        Debug.Log(actualWeather);
        WeatherChanger();//Este aun no lo tienen
        StopCoroutine(GetWeather());
    }

    private int actualWeather;
    [SerializeField] DigitalRuby.RainMaker.RainScript2D rainMaker;
    private void WeatherChanger()
    {
        if (actualWeather >= 200 && actualWeather < 300)
        {
            //tormenta
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 1;
        }
        else if (actualWeather >= 300 && actualWeather < 400)
        {
            //llovizna
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 0.2f;
        }
        else if (actualWeather >= 400 && actualWeather < 500)
        {
            //lluvia
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 0.55f;
        }
        else if (actualWeather >= 500 && actualWeather < 600)
        {
            //lluvia
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 0.7f;
        }
        else if (actualWeather >= 700 && actualWeather < 800)
        {
            //niebla
            rainMaker.RainIntensity += 0.1f;
        }
        else if (actualWeather > 800)
        {
            //Nubes
            rainMaker.RainIntensity += 0.1f;
        }
        else if (actualWeather == 800)
        {
            rainMaker.gameObject.SetActive(false);
            //ClearSky
        }
    }

    
    

}
