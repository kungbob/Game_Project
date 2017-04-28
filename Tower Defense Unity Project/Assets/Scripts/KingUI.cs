using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingUI : MonoBehaviour {

    public Text kingText;

    // Update is called once per frame
    void Update()
    {
        kingText.text = "HP :" + King.health.ToString();
    }
}
