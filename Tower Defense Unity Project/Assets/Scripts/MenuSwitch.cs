using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour {

    public GameObject tower_menu; // Assign in inspector
    public GameObject army_menu;
    public GameObject upgrade_menu;

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            tower_menu.SetActive(!tower_menu.activeSelf);
        }

        if (Input.GetKeyDown("b"))
        {
            army_menu.SetActive(!army_menu.activeSelf);
        }

        if (Input.GetKeyDown("n"))
        {
            upgrade_menu.SetActive(!upgrade_menu.activeSelf);
        }
    }
}
