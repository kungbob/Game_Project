using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserBeamer;
    public TurretBlueprint cannon;
    public TurretBlueprint magictower;
    public TurretBlueprint antitank;
    public TurretBlueprint machinegun;

	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret ()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectTurretToBuild(missileLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectTurretToBuild(laserBeamer);
	}

    public void SelectCannon()
    {
        Debug.Log("Cannon Selected");
        buildManager.SelectTurretToBuild(cannon);
    }

    public void SelectMagicTower()
    {
        Debug.Log("Maigctower Selected");
        buildManager.SelectTurretToBuild(magictower);
    }

    public void SelectAntitank()
    {
        Debug.Log("Antitank Selected");
        buildManager.SelectTurretToBuild(antitank);
    }

    public void SelectMachinegun()
    {
        Debug.Log("Machine gun Selected");
        buildManager.SelectTurretToBuild(machinegun);
    }
}
