using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSceneManager : PocketDroidsSceneManager
{
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
