using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    
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
        if (GameManager.Instance.IsMapOn && !transform.Find("object").gameObject.activeSelf) 
        {

            transform.Find("object").gameObject.SetActive(true);
        }
        else if (!GameManager.Instance.IsMapOn && transform.Find("object").gameObject.activeSelf)
        {
            transform.Find("object").gameObject.SetActive(false);
        }
    }
}
