using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    private int vidas = 2;
    private int frutas = 0;

	// Use this for initialization
    void Start()
    {
        AtualizaHud();
    }

	void Awake () {

        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetVidas(int vida)
    {
        vidas += vida;
        if(vidas >= 0) AtualizaHud();
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void SetFrutas(int fruta)
    {
        frutas += fruta;
        if(frutas >= 50)
        {
            frutas -= 50;
            vidas += 1;
        }

        AtualizaHud();
    }

    public void AtualizaHud()
    {
        GameObject.Find("VidasText").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("FrutasText").GetComponent<Text>().text = frutas.ToString();
    }

    public void DeadHud()
    {
        GameObject.Find("VidasText").GetComponent<Text>().text = "DEAD";
    }

    void OnLevelWasLoaded()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            vidas = 2;
            frutas = 0;
        }
    }
}
