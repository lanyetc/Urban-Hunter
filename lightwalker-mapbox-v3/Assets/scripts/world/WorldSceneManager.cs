using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : PocketDroidsSceneManager
{
    private GameObject monster;
    private GameObject collectable;
    private AsyncOperation loadScene;
    [SerializeField] private GameObject[] clickables;

    private void Start()
    {
        foreach (Clickable obj in PocketDroidConstant.shownObjects)
        {
            //Debug.Log(obj.transform.position);
            GameObject newObj = Instantiate(clickables[obj.type], obj.pos, Quaternion.identity);
            newObj.AddComponent<Clickable>();
        }
    }
    public override void CollectatbleTapped(GameObject collectable)
    {
        List<GameObject> list = new List<GameObject>();
        PocketDroidConstant.OBJECTTYPE = collectable.GetComponent<CollectableObject>().ObjectType;
        collectable.GetComponent<CollectableObject>().ObjectState = false;
        //if (PocketDroidConstant.OBJECTTYPE != 1 || (PocketDroidConstant.OBJECTTYPE == 1 && PocketDroidConstant.MONSTRER_ACTIVATED))
        //{
        //    collectable.GetComponent<CollectableObject>().ObjectState = false;
        //}
        if (PocketDroidConstant.USING_MAGICEYE)
        {
            Clickable newClickable = new Clickable();
            GameObject newObj = Instantiate(clickables[PocketDroidConstant.OBJECTTYPE], collectable.transform.position, Quaternion.identity);
            newClickable.type = PocketDroidConstant.OBJECTTYPE;
            newClickable.pos = newObj.transform.position;
            newObj.AddComponent<Clickable>();

            PocketDroidConstant.shownObjects.Add(newClickable);
            PocketDroidConstant.USING_MAGICEYE = false;
            PocketDroidConstant.HINTTEXT = "";
        } else {
            SceneTransitionManager.Instance.GoToScene(PocketDroidConstant.SCENE_CAPTURE, list);
        }
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
