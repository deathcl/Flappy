using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    //creamos una instancia de este mismo objeto como script para poder utilizar sus variables y metodos desde cualquier otro script
    //esto sin necesidad de estar definiendo variables de referencia en todos los demas script donde necesitemos utilizarlos
    public static GameControler instance;

    public GameObject gameOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;
    public Text scoreText;
    int score;

    private void Awake()
    {
        //generamos la instacia a si mismo para dejarla activa siempre y cuando no exista una anterior
        if(GameControler.instance == null)
        {
            GameControler.instance = this;
        }
        else if(GameControler.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void BirdScore()
    {
        if (gameOver == true) return;
        score++;
        scoreText.text = "Puntos: " + score;
        SoundSystem.instance.PlayAudioPoint();
    }

    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    //con este metodo destruimos cualquier referencia que pueda quedar al destruir una referencia anterior del SINGLETON
    private void OnDestroy()
    {
        if(GameControler.instance == this)
        {
            GameControler.instance = null;
        }
    }
}
