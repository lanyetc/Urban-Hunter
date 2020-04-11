using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiexedTrap : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] GameObject closedTrap;
    [SerializeField] GameObject openedTrap;
    private void OnMouseDown()
    {
        if (PocketDroidConstant.MONSTRER_ACTIVATED)
        {
            openedTrap.SetActive(false);
            closedTrap.SetActive(true);
            monster.SetActive(true);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        openedTrap.SetActive(true);
        closedTrap.SetActive(false);
        monster.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
