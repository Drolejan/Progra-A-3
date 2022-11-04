using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class DBmanager : MonoBehaviour
{
    DatabaseReference reference;

    void Start()
    {
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;//Busca el link para conectarse

        InitDB();//Iniciar la base de datos
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitDB()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void writeNewUser(string userId, string name, string email)
    {
        float score = Random.Range(0, 50000);
        User user = new User(name, email,score.ToString());
        string usuarioJson = JsonUtility.ToJson(user);//Convierte un Objeto a un archivo de texto

        reference.Child("MiBDnueva").Child(userId).SetRawJsonValueAsync(usuarioJson);
    }

    public void ButtonDB()
    {
        int numRandom = Random.Range(1, 1000);
        writeNewUser(numRandom.ToString(), "hola"+numRandom, "miEmail@gmail.com");
    }

    //Crear funcion para cargar Scores Reales a Firebase
    int miPlayerId=1;
    public void uploadData(string datosMiPlayer)
    {
        reference.Child("BD_MiJuego").Child(miPlayerId.ToString()).SetRawJsonValueAsync(datosMiPlayer);
        miPlayerId++;
    }
}

public class User
{
    public string username;
    public string email;
    public string score;

    public User()
    {

    }

    public User(string username, string email, string score)
    {
        this.username = username;
        this.email = email;
        this.score = score;
    }
}
