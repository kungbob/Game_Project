using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour {

    public GameObject allyPrefab;

    public Transform spawnPoint;

    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(SpawnEnemy);
    }

    public void SpawnEnemy()
    {
        Instantiate(allyPrefab, spawnPoint.position, spawnPoint.rotation);
        return;
    }

}
