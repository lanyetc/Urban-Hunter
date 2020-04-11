using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public int type;
    public Vector3 pos;
    private void OnMouseDown()
    {
        List<GameObject> list = new List<GameObject>();
        SceneTransitionManager.Instance.GoToScene(PocketDroidConstant.SCENE_CAPTURE, list);
    }
    
}
