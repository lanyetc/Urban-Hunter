using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CaptureUIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text HintText;
	[SerializeField] private Text timerText;
	//[SerializeField] private Button switchButton;
	[SerializeField] private Button backToMapButton;
    //[SerializeField] private Sprite switchOnImg;
    //[SerializeField] private Sprite switchOffImg;
    [SerializeField] private Text[] toolsAmountTexts;

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
        upDateTimer();
        upDatePoints();
        UpdateToolAmount();
    }
    public void upDateCoins()
    {
        coinsText.text = "" + PocketDroidConstant.COINSNUM;
    }

    public void upDatePoints()
    {
        pointsText.text = "" + PocketDroidConstant.POINTSNUM;
    }

    public void upDateTimer()
    {
        if (PocketDroidConstant.LEFTTIME > -1)
        {
            timerText.text = "Time: " + PocketDroidConstant.LEFTTIME;
        } else
        {
            timerText.text = "";
        }
    }

    public void UpdateToolAmount()
    {
        toolsAmountTexts[0].text = "Amount: " + PocketDroidConstant.EYENUM;
        toolsAmountTexts[1].text = "Amount: " + PocketDroidConstant.TRAPNUM;
    }


    public void BackToMap()
    {

        List<GameObject> list = new List<GameObject>();
        list.Add(arCamera);
        //list.Add(GameManager.Instance.GUI);
        //PocketDroidConstant.OBJECTTYPE = 0;

        SceneTransitionManager.Instance.GoToScene(PocketDroidConstant.SCENE_WORLD, list);
        //Destroy(arCamera);
    }

    public void UpdateHint()
    {
        HintText.text = PocketDroidConstant.HINTTEXT;
    }

    public void UseMagicTrap()
    {

        if (PocketDroidConstant.TRAPNUM >= 0)
        {
            if (PocketDroidConstant.OBJECTTYPE == 0)
            {
                PocketDroidConstant.HINTTEXT = "Congratulations! You trapped a monster!";
                PocketDroidConstant.POINTSNUM += 20;
                PocketDroidConstant.MONSTRER_ACTIVATED = false;
            } else
            {
                PocketDroidConstant.HINTTEXT = "Here is no monster.";
            }
            
            //StartCoroutine(HideHint());
            CaptureSceneManager captureSceneManager = FindObjectOfType<CaptureSceneManager>();
            captureSceneManager.UseMagicEye();
            PocketDroidConstant.TRAPNUM -= 1;
        }
        else
        {
            PocketDroidConstant.HINTTEXT = "You don't have any magic trap.";
            StartCoroutine(HideHint());
        }
    }
    public void BuyMagicTrap()
    {

        if (PocketDroidConstant.COINSNUM < 200)
        {
            PocketDroidConstant.HINTTEXT = "You don't have enough money!";
            StartCoroutine(HideHint());
        }
        else
        {
            PocketDroidConstant.COINSNUM -= 200;
            PocketDroidConstant.TRAPNUM += 1;
        }
    }

    //public void UseMagicTrap()
    //{

    //    if (PocketDroidConstant.TRAPNUM >= 0)
    //    {
    //        PocketDroidConstant.HINTTEXT = "You don't have any magic trap!";
    //        StartCoroutine(HideHint());
    //    }
    //    else
    //    {
    //        PocketDroidConstant.COINSNUM -= 200;
    //        PocketDroidConstant.TRAPNUM += 1;
    //    }
    //}

    private IEnumerator HideHint()
    {
        yield return new WaitForSeconds(2); // 2秒后结束提示
        PocketDroidConstant.HINTTEXT = "";
    }

}
