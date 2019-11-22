using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Button switchButton;
    [SerializeField] private Sprite switchOnImg;
    [SerializeField] private Sprite switchOffImg;
    private bool isMapOn = true;

    private void Awake()
    {
        Assert.IsNotNull(coinsText);
    }
    private void Start()
    {
        PocketDroidConstant.HINTTEXT = ""; // 重置提示文字
    }
    private void Update()
    {
        upDateCoins();
    }
    public void upDateCoins()
    {
        coinsText.text = "Coins: " + PocketDroidConstant.COINSNUM;
    }

    public void SwitchMap()
    {
        
        if(GameManager.Instance.IsMapOn)
        {
            switchButton.GetComponent<Image>().sprite = switchOffImg;
            GameManager.Instance.IsMapOn = false;
        } else
        {
            switchButton.GetComponent<Image>().sprite = switchOnImg;
            GameManager.Instance.IsMapOn = true;
        }
    }
    
}
