using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour {

    public GameObject footman;
    public GameObject wolf;
    public GameObject soldier;

    public Transform spawnPoint;

    public Button footman_btn;
    public Button wolf_btn;
    public Button soldier_btn;

    void Start()
    {
        Button btn1 = footman_btn.GetComponent<Button>();
        btn1.onClick.AddListener(SpawnFootman);
        Button btn2 = wolf_btn.GetComponent<Button>();
        btn2.onClick.AddListener(SpawnWolf);
        Button btn3 = soldier_btn.GetComponent<Button>();
        btn3.onClick.AddListener(SpawnSoldier);
    }

    public void SpawnFootman()
    {
        PlayerStats.Money -= 30;
        Instantiate(footman, spawnPoint.position, spawnPoint.rotation);
        return;
    }

    public void SpawnWolf()
    {
        PlayerStats.Money -= 10;
        Instantiate(wolf, spawnPoint.position, spawnPoint.rotation);
        return;
    }

    public void SpawnSoldier()
    {
        PlayerStats.Money -= 100;
        Instantiate(soldier, spawnPoint.position, spawnPoint.rotation);
        return;
    }

}
