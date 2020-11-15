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

    #region TextForEquipmentPanel
    [Header("Text for Equipment Panel")]
    [SerializeField] private Text levelText;
    [SerializeField] private Text attackValueText;
    [SerializeField] private Text critRateText;
    #endregion

    #region TextForEnhancePanel
    [Header("Text for Enhance Panel")]
    [SerializeField] private Text enhanceLevelText;
    [SerializeField] private Text crystalOreAmountText;
    [SerializeField] private Text goldAmountText;
    public int crystalOreAmount;
    public int goldAmount;
    private int crystalOreToGold;
    #endregion

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
            default:
                crystalOreAmount.ToString("Level Max");
                goldAmount.ToString("Level Max");
                break;
        }
    }
}
