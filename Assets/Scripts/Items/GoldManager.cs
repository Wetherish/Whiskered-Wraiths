using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public TMP_Text goldText;
    public int gold;
    
    void Start()
    {
        goldText.text = gold.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = gold.ToString();
    }
}
