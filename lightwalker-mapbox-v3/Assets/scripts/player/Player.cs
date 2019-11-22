using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    [SerializeField] private int requiredXp = 100;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private List<GameObject> droids = new List<GameObject>();
    private int lvl = 1;

    public int Coins
    {
        get { return coins; }
    }
    public int RequiredXp
    {
        get { return requiredXp; }
    }
    public int LevelBase
    {
        get { return levelBase; }
    }
    public List<GameObject> Droids
    {
        get { return droids; }
    }

    public void AddCoins(int coins)
    {

        this.coins += Mathf.Max(0, coins);
    }

    public void AddDroids(GameObject droid)
    {
        droids.Add(droid);
    }

    private void InitLevelData()
    {
        lvl = (coins / levelBase) + 1;
        requiredXp = levelBase * lvl;
    }


    // Start is called before the first frame update
    void Start()
    {
        InitLevelData();
    }

}
