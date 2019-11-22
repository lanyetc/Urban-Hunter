using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : PocketDroidsSceneManager
{
    private GameObject monster;
    private GameObject collectable;
    private AsyncOperation loadScene;

    public override void CollectatbleTapped(GameObject collectable)
    {
        List<GameObject> list = new List<GameObject>();
        PocketDroidConstant.OBJECTTYPE = Random.Range(1,3);
        SceneTransitionManager.Instance.GoToScene(PocketDroidConstant.SCENE_CAPTURE, list);
    }

    public override void MonsterTapped(GameObject monster)
    {
        List<GameObject> list = new List<GameObject>();
        //list.Add(monster);
        //list.Add(GameManager.Instance.GUI);
        PocketDroidConstant.OBJECTTYPE = 0;
        SceneTransitionManager.Instance.GoToScene(PocketDroidConstant.SCENE_CAPTURE, list);
    }

    public override void PlayerTapped(GameObject player)
    {
        
    }
}
