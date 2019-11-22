using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player currentPlayer;
    //[SerializeField] private GameObject gui;
    private bool isMapOn = true; // map状态

    public bool IsMapOn {
        get { return isMapOn; }
        set { isMapOn = value; }
    }

    public Player CurrentPlayer
    {
        get { return currentPlayer; }
    }

    //public GameObject GUI
    //{
    //    get { return gui; }
    //}

    private void Awake()
    {
        Assert.IsNotNull(currentPlayer);
    }
}
