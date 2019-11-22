using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CaptureUIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text HintText;
    //[SerializeField] private Button switchButton;
    [SerializeField] private Button backToMapButton;
    //[SerializeField] private Sprite switchOnImg;
    //[SerializeField] private Sprite switchOffImg;

    [SerializeField] private GameObject arCamera;
    private bool isMapOn = true;

    private void Awake()
    {
        Assert.IsNotNull(coinsText);
    }
    private void Update()
    {
        upDateCoins();
        UpdateHint();
    }
    public void upDateCoins()
    {
        coinsText.text = "Coins: " + PocketDroidConstant.COINSNUM;
    }

    public void BackToMap()
    {

        List<GameObject> list = new List<GameObject>();
        //list.Add(monster);
        //list.Add(GameManager.Instance.GUI);
        //PocketDroidConstant.OBJECTTYPE = 0;
        Destroy(arCamera);
        SceneTransitionManager.Instance.GoToScene(PocketDroidConstant.SCENE_WORLD, list);
    }

    public void UpdateHint()
    {
        HintText.text = PocketDroidConstant.HINTTEXT;
    }

}
