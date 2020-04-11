using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.1f;
    [SerializeField] private float catchRate = 0.1f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defense = 0;
    [SerializeField] private int hp = 0;

    private void Start()
    {
        //DontDestroyOnLoad(this);
    }

  

    public float SpawnRate
    {
        get { return spawnRate; }
    }
    public float CatchRate
    {
        get { return catchRate; }
    }
    public float Attack
    {
        get { return attack; }
    }
    public float Defense
    {
        get { return defense; }
    } 
    public float Hp
    {
        get { return hp; }
    }

   

    private void OnMouseDown()
    {
        PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();
        foreach(PocketDroidsSceneManager pocketDroidsSceneManager in managers)
        {
            if (pocketDroidsSceneManager.gameObject.activeSelf)
            {
                pocketDroidsSceneManager.MonsterTapped(this.gameObject);
            }
        }
    }
}
