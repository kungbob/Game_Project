using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5; 

    public Button upgrade_btn;

    public GameObject btn_army_add;
    public GameObject btn_army_add2;
    public GameObject btn_army_add3;

    public GameObject btn_tower_add;
    public GameObject btn_tower_add2;
    public GameObject btn_tower_add3;
    public GameObject btn_tower_add4;
    public GameObject btn_tower_add5;
    public GameObject btn_tower_add6;
    public GameObject btn_tower_add7;

    public Text upgradeText;


    // Use this for initialization
    void Start () {
        Button btn1 = upgrade_btn.GetComponent<Button>();
        btn1.onClick.AddListener(upgrade);
        upgradeText.text = "$100" ;

    }

    void upgrade()
    {
        if (PlayerStats.town_level == 0)
        {
            if (PlayerStats.Money >= 100)
            {
                level1.SetActive(true);
                btn_tower_add.SetActive(true);
                btn_army_add.SetActive(true);
                PlayerStats.town_level++;
                PlayerStats.Money -= 100;
                upgradeText.text = "$200";
            }
            
        }

        else if (PlayerStats.town_level == 1)
        {
            if (PlayerStats.Money >= 200)
            {
                level1.SetActive(true);
                level2.SetActive(true);
                btn_tower_add.SetActive(true);
                btn_tower_add2.SetActive(true);
                btn_army_add.SetActive(true);
                btn_army_add2.SetActive(true);
                PlayerStats.town_level++;
                PlayerStats.Money -= 200;
                upgradeText.text = "$400";
            }
            
        }

        else if(PlayerStats.town_level == 2)
        {
            if (PlayerStats.Money >= 400)
            {
                level1.SetActive(true);
                level2.SetActive(true);
                level3.SetActive(true);
                btn_tower_add.SetActive(true);
                btn_tower_add2.SetActive(true);
                btn_tower_add3.SetActive(true);
                PlayerStats.town_level++;
                PlayerStats.Money -= 400;
                upgradeText.text = "$800";
            }
                
        }

        else if (PlayerStats.town_level == 3)
        {
            if (PlayerStats.Money >= 800)
            {
                level1.SetActive(true);
                level2.SetActive(true);
                level3.SetActive(true);
                level4.SetActive(true);
                btn_tower_add.SetActive(true);
                btn_tower_add2.SetActive(true);
                btn_tower_add3.SetActive(true);
                btn_tower_add4.SetActive(true);
                btn_army_add3.SetActive(true);
                PlayerStats.town_level++;
                PlayerStats.Money -= 800;
                upgradeText.text = "$1500";
            }
            
        }

        else if (PlayerStats.town_level == 4)
        {
            if (PlayerStats.Money >= 1500)
            {
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(false);
                level4.SetActive(false);
                level5.SetActive(true);
                btn_tower_add.SetActive(false);
                btn_tower_add2.SetActive(false);
                btn_tower_add3.SetActive(false);
                btn_tower_add4.SetActive(false);
                btn_tower_add5.SetActive(true);
                btn_tower_add6.SetActive(true);
                btn_tower_add7.SetActive(true);
                btn_army_add.SetActive(false);
                btn_army_add2.SetActive(false);
                btn_army_add3.SetActive(true);
                PlayerStats.town_level++;
                PlayerStats.Money -= 1500;
            }
            
        }

    }
	
}
