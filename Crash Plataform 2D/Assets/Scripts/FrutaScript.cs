using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaScript : MonoBehaviour {

    Animator anim;
    CircleCollider2D col;

    private AudioSource audioS;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<CircleCollider2D>();
        audioS = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            GameManager.gm.SetFrutas(1);
            col.enabled = false;
            anim.SetTrigger("Coletando");
            Destroy(gameObject, 0.667f);
        }
    }
}
