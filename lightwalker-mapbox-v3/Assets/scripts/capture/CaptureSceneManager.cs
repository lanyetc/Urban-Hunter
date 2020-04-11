using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureSceneManager : PocketDroidsSceneManager
{
    [SerializeField] GameObject coins;
    [SerializeField] GameObject magicTrap;
    [SerializeField] GameObject fixedTrap;
    [SerializeField] GameObject monster;
    private void Start()
    {
        PocketDroidConstant.LEFTTIME = -1;
        coins.SetActive(false);
        fixedTrap.SetActive(false);
        magicTrap.SetActive(false);
        monster.SetActive(false);
        ShowObject();
    }

    public void ShowObject()
    {
        
        if (PocketDroidConstant.OBJECTTYPE == 0)
        {
            // 是monster
            monster.SetActive(true);
            PocketDroidConstant.MONSTRER_ACTIVATED = true;
            StartCoroutine(CountDown(PocketDroidConstant.OBJECTTYPE));
        } else if (PocketDroidConstant.OBJECTTYPE == 1)
        {
            // 是fixed trap
            fixedTrap.SetActive(true);
            if (PocketDroidConstant.MONSTRER_ACTIVATED)
            {
                // 此时有monster被激活
                StartCoroutine(CountDown(PocketDroidConstant.OBJECTTYPE));
            }
            
        } else if (PocketDroidConstant.OBJECTTYPE == 2)
        {
            // 是coins
            coins.SetActive(true);
           
        } else if (PocketDroidConstant.OBJECTTYPE == 3)
        {
            // 是magic trap
            magicTrap.SetActive(true);
        }
    }

    IEnumerator CountDown(int type)
    {
       PocketDroidConstant.LEFTTIME = 5;
        
        while (PocketDroidConstant.LEFTTIME >= 0)
        {
            
            yield return new WaitForSeconds(1);
            PocketDroidConstant.LEFTTIME = PocketDroidConstant.LEFTTIME - 1;
            if (!PocketDroidConstant.MONSTRER_ACTIVATED)
            {
                PocketDroidConstant.LEFTTIME = -1;
                //PocketDroidConstant.HINTTEXT = "";
                yield break;
            }

        }
        if (type == 0)
        {
            // 是monster
            PocketDroidConstant.HINTTEXT = "The monster robbed 50 points from you!";
            PocketDroidConstant.POINTSNUM -= 50;
            PocketDroidConstant.MONSTRER_ACTIVATED = false;

        } else if (type == 1)
        {
            // 是fixed trap且此时有monster被激活
            PocketDroidConstant.HINTTEXT = "Congratulations! You trapped a monster!";
            PocketDroidConstant.POINTSNUM += 20;
            PocketDroidConstant.MONSTRER_ACTIVATED = false;
        }
    }

    public void UseMagicEye()
    {
        magicTrap.SetActive(true);
    }

    public override void CollectatbleTapped(GameObject collectable)
    {
        if (PocketDroidConstant.OBJECTTYPE == 2)
        {
            // 是coins

        }
    }

    public override void MonsterTapped(GameObject monster)
    {
        print("CaptureSceneManager.MonsterTapped activated!");
    }

    public override void PlayerTapped(GameObject player)
    {
        throw new System.NotImplementedException();
    }

}
