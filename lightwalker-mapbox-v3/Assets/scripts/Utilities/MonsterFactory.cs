using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] private Monster[] availableMonsters;
    [SerializeField] private Player player;
    [SerializeField] private float waitTime = 180.0f; //每个monster生成的时间 3min
    [SerializeField] private int startingMonsters = 5; //初始monster数目
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;
    private List<Monster> liveMonsters = new List<Monster>();

    private Monster selectedMonster;

    public List<Monster> LiveMonsters
    {
        get { return liveMonsters; }
    }

    public Monster SelectedMonster
    {
        get { return selectedMonster; }
    }

    private void Awake()
    {
        Assert.IsNotNull(availableMonsters);
        Assert.IsNotNull(player);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < startingMonsters; i++)
        {
            InstantiateMosnter();
        }
        StartCoroutine(GenerateMonsters());
    }

    public void MonsterWasSelected (Monster monster)
    {
        selectedMonster = monster;
    }

    private IEnumerator GenerateMonsters()
    {
        while(true)
        {
            InstantiateMosnter();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void InstantiateMosnter()
    {
        int index = Random.Range(0, availableMonsters.Length);
        float x = player.transform.position.x + GenerateRange(); 
        float z = player.transform.position.z + GenerateRange(); 
        float y = player.transform.position.y;
        liveMonsters.Add(Instantiate(availableMonsters[index], new Vector3(x, y, z), Quaternion.identity));
       
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }
 
}
