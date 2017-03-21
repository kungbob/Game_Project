using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;
    public TurretBlueprint bank;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurrent()
    {
        Debug.Log("Another Turret Purchased");
        buildManager.SetTurretToBuild(anotherTurret);
    }

    public void BuildBank()
    {
        Debug.Log("Bank Purchased");
        buildManager.SetTurretToBuild(bank);
    }



}
