using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panelGameOver;
    public GameObject panelWin;
    private PlayerHealth playerHealth;
    private PlayerAttack player;
    private EnemyHealth enemyHealth;

    public Image skillImg;
    public Sprite cooldownSkillSprite;
    public Sprite ActiveSkillSprite;

    private float cooldownTime;
    public Text cooldownTimeText;

    public int amountCrystalOre;
    public Text amountCrystalOreText;

    public int amountGold;
    public Text amountGoldText;

    public GameObject panelStatus;
    public Text atkInfoText;
    public Text critRateInfoText;
    public Text healthPlayerText;
    public GameObject panelPause;
    private bool isPaused = false;

    public GameObject panelEquipment;
    public GameObject panelEnhance;
    private bool enhancePanelActive = false;
    private bool equipmentPanelActive = false;

    public Weapon weapon;
    public Image enhanceButton;
    private bool canEnhance = false;
    private int level;
    private int attack;
    private int critRate;
    private int n = 1;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

        level = weapon.level;
        attack = weapon.attack;
        critRate = weapon.critRate;

        amountCrystalOre = 0;
        amountGold = 0;
    }

    void Update()
    {
        ChangeSpriteDoubleDamageSkill();

        SetStatusValue();

        CheckMaterialEnhance();

        amountCrystalOreText.text = amountCrystalOre.ToString();
        amountGoldText.text = amountGold.ToString();

        if (playerHealth.health <= 0)
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if(enemyHealth.health <= 0)
        {
            panelWin.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            panelPause.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                panelPause.gameObject.SetActive(false);
                Time.timeScale = 0;
            }
        }

        cooldownTime -= Time.deltaTime;
    }

    public void ChangeSpriteDoubleDamageSkill()
    {
        if (Mathf.RoundToInt(cooldownTime) <= 0 && !player.isCooldown)
        {
            skillImg.sprite = ActiveSkillSprite;
            cooldownTimeText.gameObject.SetActive(false);
        }

        if (player.isCooldown)
        {
            skillImg.sprite = cooldownSkillSprite;

            if(cooldownTime < 0)
            {
                cooldownTime = 5;
            }

            cooldownTimeText.gameObject.SetActive(true);

            cooldownTimeText.text = Mathf.Round(cooldownTime).ToString();
        }
    }

    void SetStatusValue()
    {
        atkInfoText.text = weapon.attack.ToString();
        critRateInfoText.text = weapon.critRate.ToString() + "%";
        healthPlayerText.text = playerHealth.health.ToString();
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void InfoStatus()
    {
        Time.timeScale = 0;
        panelPause.gameObject.SetActive(false);
        isPaused = false;
        panelStatus.gameObject.SetActive(true);
    }

    public void BackToGame()
    {
        Time.timeScale = 1;

        if (isPaused)
        {
            panelPause.SetActive(false);
        }
        else
        {
            panelStatus.SetActive(false);
        }
    }

    public void ShowEquipmentPanel()
    {
        if (!equipmentPanelActive)
        {
            equipmentPanelActive = true;
            panelStatus.SetActive(false);
            panelEquipment.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GoToEnhancePanel()
    {
        if (!enhancePanelActive)
        {
            enhancePanelActive = true;
            Time.timeScale = 0;
            panelEquipment.SetActive(false);
            panelEnhance.SetActive(true);
        }
    }

    public void CloseButton()
    {
        if (enhancePanelActive)
        {
            enhancePanelActive = false;
            panelEnhance.SetActive(false);
        }

        if (equipmentPanelActive)
        {
            equipmentPanelActive = false;
            panelEquipment.SetActive(false);
        }
    }

    void CheckMaterialEnhance()
    {
        if (!canEnhance)
        {
            enhanceButton.color = new Color(195, 195, 195, 196);
            enhanceButton.GetComponent<Button>().interactable = false;
        }

        if(amountCrystalOre >= weapon.crystalOreAmount && amountGold >= weapon.goldAmount)
        {
            canEnhance = true;
            enhanceButton.color = new Color(255, 255, 255, 255);
            enhanceButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            canEnhance = false;
        }
    }

    public void EnhancePistol()
    {
        if (canEnhance)
        {
            level++;
            weapon.level = level;
            attack += 30 * n;
            weapon.attack = attack;
            player.damage = attack;
            critRate += 5 * n;
            weapon.critRate = critRate;
            n++;

            amountGold -= weapon.goldAmount;
            amountCrystalOre -= weapon.crystalOreAmount;
        }
    }
}
