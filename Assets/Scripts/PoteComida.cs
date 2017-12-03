using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoteComida : MonoBehaviour {

    public Sprite poteCheioImg;

    public Sprite poteVazioImg;

    private bool poteVazio { set; get; }
    
    // Use this for initialization
	void Start () {
        poteVazio = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnchePote()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = poteCheioImg;
        poteVazio = false;
    }

    public void EsvaziaPote()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = poteVazioImg;
        poteVazio = true;
    }
}
