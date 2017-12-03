using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WindowController : MonoBehaviour {

    public Sprite closed, opened, closedCat, openedCat;
    public float catAppeardTime, catSpawnTime;
    public Transform catPrefab;
    public bool HasCat { get; private set; }
    public bool IsOpened { get; private set; }
    public bool IsNextPlayer { get; private set; }

    SpriteRenderer renderer2D;
    
    void Awake()
    {
        if (closed == null || opened == null || closedCat == null || openedCat==null)
        {
            Debug.LogError("Erro. Sprites Closed, Opened, ClosedCat ou OpenedCat não definida(s).");
            return;
        }
        renderer2D = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(_NextAppearTimer());
    }

    public void Open()
    {
        if (!IsNextPlayer)
            return;

        if (HasCat)
            renderer2D.sprite = openedCat;
        else
            renderer2D.sprite = opened;

        IsOpened = true;
    }

    public void Close()
    {
        if (!IsNextPlayer)
            return;

        if (HasCat)
            renderer2D.sprite = closedCat;
        else
            renderer2D.sprite = closed;

        IsOpened = false;
    }

    IEnumerator _NextAppearTimer()
    { 
        yield return new WaitForSeconds(catAppeardTime);
        HasCat = true;
        if (IsOpened)
            renderer2D.sprite = openedCat;
        else
            renderer2D.sprite = closedCat;

        StartCoroutine("_SpawnTimer");
    }

    IEnumerator _SpawnTimer()
    {
        yield return new WaitForSeconds(catSpawnTime);
        if (IsOpened)
        { 
            //Spawn Cat
            GameObject.Instantiate(catPrefab, new Vector3(transform.position.x + 2.2f, transform.position.y - 45f, 0f), Quaternion.identity);
            renderer2D.sprite = opened;
        }
        else
            renderer2D.sprite = closed;

        HasCat = false;
        StartCoroutine(_NextAppearTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsNextPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsNextPlayer = false;
    }

    public void WindowToggle()
    {
        if (IsOpened)
            Close();
        else
            Open();
    }

    /*
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 200, 100, 20), "Janela"))
        {
            if (IsOpened)
                Close();
            else
                Open();
        }
    }
    */

}
