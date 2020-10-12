using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public int level;
    public int attack;
    public int critRate;

    public PlayerAttack playerAttack;

    [Header("Text for Equipment Panel")]
    public Text levelText;
    public Text attackValueText;
    public Text critRateText;

    [Header("Text for Enhance Panel")]
    public Text enhanceLevelText;
    public Text crystalOreAmountText;
    public Text goldAmountText;
    public int crystalOreAmount;
    public int goldAmount;
    private int crystalOreToGold;

    void Start()
    {
        level = 1;
        attack = playerAttack.damage;
        critRate = playerAttack.critRate;
    }

    void Update()
    {
        SetValueInPanelEquipment();

        SetValueForEnhancePanel();
    }

    void SetValueInPanelEquipment()
    {
        levelText.text = level.ToString();
        attackValueText.text = attack.ToString();
        critRateText.text = critRate.ToString() + "%";
    }

    void SetValueMaterialAmount()
    {
        crystalOreAmountText.text = crystalOreAmount.ToString();
        goldAmountText.text = goldAmount.ToString();
    }

    void SetValueForEnhancePanel()
    {
        int nextLevel = level + 1;
        enhanceLevelText.text = nextLevel.ToString();

        switch (nextLevel)
        {
            case 2:
                crystalOreAmount = 1;
                goldAmount = 3000;
                crystalOreToGold = crystalOreAmount * 500;
                SetValueMaterialAmount();
                break;
            case 3:
                crystalOreAmount = 2;
                goldAmount = 5000;
                crystalOreToGold = crystalOreAmount * 500;
                SetValueMaterialAmount();
                break;
            case 4:
                crystalOreAmount = 3;
                goldAmount = 9000;
                crystalOreToGold = crystalOreAmount * 500;
                SetValueMaterialAmount();
                break;
            case 5:
                crystalOreAmount = 4;
                goldAmount = 15000;
                crystalOreToGold = crystalOreAmount * 500;
                SetValueMaterialAmount();
                break;
        }
    }
}
