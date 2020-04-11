using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text hintText;
    [SerializeField] private Button switchButton;
    [SerializeField] private Sprite switchOnImg;
    [SerializeField] private Sprite switchOffImg;
    [SerializeField] private Text[] toolsAmountTexts;
    [SerializeField] private Text timerText;
    private bool isMapOn = true;
    IEnumerator countDown;

    private void Awake()
    {
        Assert.IsNotNull(coinsText);
        Assert.IsNotNull(pointsText);
        Assert.IsNotNull(toolsAmountTexts);
    }
    private void Start()
    {
        PocketDroidConstant.HINTTEXT = ""; // 重置提示文字
        PocketDroidConstant.LEFTTIME = -1; //重置倒计时
        countDown = CountDown();
        if (PocketDroidConstant.MONSTRER_ACTIVATED)
        {
            // 如果当前有monster被激活
            StartCoroutine(countDown);
        }

    }
    private void Update()
    {
        upDateCoins();
        upDatePoints();
        UpdateHint();
        UpdateToolAmount();
        UpdateTimer();
    }
    public void upDateCoins()
    {
        coinsText.text = "" + PocketDroidConstant.COINSNUM;
    }
    public void upDatePoints()
    {
        pointsText.text = "" + PocketDroidConstant.POINTSNUM;
    }
    public void UpdateHint()
    {
        hintText.text = PocketDroidConstant.HINTTEXT;
    }
    public void UpdateToolAmount()
    {
        toolsAmountTexts[0].text = "Amount: " + PocketDroidConstant.EYENUM;
        toolsAmountTexts[1].text = "Amount: " + PocketDroidConstant.TRAPNUM;
    }

    public void UpdateTimer()
    {
        
        if (PocketDroidConstant.LEFTTIME > -1)
        {
            timerText.text = "Time: " + PocketDroidConstant.LEFTTIME;
        }
        else
        {
            timerText.text = "";
        }
    }

    public void SwitchMap()
    {
        
        if(GameManager.Instance.IsMapOn)
        {
            switchButton.GetComponent<Image>().sprite = switchOffImg;
            GameManager.Instance.IsMapOn = false;
            if (PocketDroidConstant.MONSTRER_ACTIVATED)
            {
                // 如果当前有monster被激活
                StopCoroutine(countDown);
                PocketDroidConstant.LEFTTIME = -1;
                countDown = CountDown();
            }
        } else
        {
            switchButton.GetComponent<Image>().sprite = switchOnImg;
            GameManager.Instance.IsMapOn = true;
            if (PocketDroidConstant.MONSTRER_ACTIVATED)
            {
                // 如果当前有monster被激活
                StartCoroutine(countDown);
            }
        }
    }

    IEnumerator CountDown()
    {
        PocketDroidConstant.LEFTTIME = 5;

        while (PocketDroidConstant.LEFTTIME >= 0)
        {

            yield return new WaitForSeconds(1);
            PocketDroidConstant.LEFTTIME = PocketDroidConstant.LEFTTIME - 1;
            if (!isMapOn)
            {
                yield break;
            }
        }
        // 5秒后地图仍然打开
        PocketDroidConstant.HINTTEXT = "The monster robbed 50 points from you!";
        StartCoroutine(HideHint());
        PocketDroidConstant.POINTSNUM -= 50;
        PocketDroidConstant.MONSTRER_ACTIVATED = false;
    }

    public void BuyMagicEye()
    {

        if (PocketDroidConstant.COINSNUM < 150)
        {
            PocketDroidConstant.HINTTEXT = "You don't have enough money!";
            StartCoroutine(HideHint());
            
        } else
        {
            PocketDroidConstant.COINSNUM -= 150;
            PocketDroidConstant.EYENUM += 1;
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

    public void UseMagicEye()
    {

        if (PocketDroidConstant.EYENUM > 0)
        {
            PocketDroidConstant.USING_MAGICEYE = true;
            PocketDroidConstant.HINTTEXT = "Choose an object to see.";
            PocketDroidConstant.EYENUM -= 1;
            //StartCoroutine(HideHint());
        }
        else
        {
            PocketDroidConstant.HINTTEXT = "You don't have any magic eye!";
            StartCoroutine(HideHint());
        }
    }

    private IEnumerator HideHint()
    {
        yield return new WaitForSeconds(2); // 3秒后结束提示
        PocketDroidConstant.HINTTEXT = "";
    }
}
