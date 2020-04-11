using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    private int objectType = -1;
    private bool objectState = true;



    private void Awake()
    {
        objectType = Random.Range(0, 3);
    }

    public int ObjectType
    {
        get { return objectType; }
    }

    public bool ObjectState
    {
        get { return objectState; }
        set { objectState = value; }
    }

    private void OnMouseDown()
    {

        //GameManager.Instance.CurrentPlayer.AddCoins(10);
        PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();
        foreach (PocketDroidsSceneManager pocketDroidsSceneManager in managers)
        {
            if (pocketDroidsSceneManager.gameObject.activeSelf)
            {
                pocketDroidsSceneManager.CollectatbleTapped(this.gameObject);
            }
        }
    }

    private void Update()
    {

        UpdateDispalyState();
    }

    private void UpdateDispalyState()
    {
        if (GameManager.Instance.IsMapOn && !transform.Find("object").gameObject.activeSelf && objectState) 
        {

            transform.Find("object").gameObject.SetActive(true);
        }
        else if ((!GameManager.Instance.IsMapOn && transform.Find("object").gameObject.activeSelf) || !objectState)
        {
            transform.Find("object").gameObject.SetActive(false);
        }
    }
}
