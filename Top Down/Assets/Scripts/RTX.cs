using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RTX : MonoBehaviour{

    public TextMeshProUGUI grText;
    public Button btn;
    void Start()
    {
        if(PlayerPrefs.GetString("Graphics") == ""){
            PlayerPrefs.SetString("Graphics", "RTX");
        }
        btn.onClick.AddListener(ChangeGraphics);
    }

    void Update()
    {
        grText.text = "Graphics: " + PlayerPrefs.GetString("Graphics");
    }

    void ChangeGraphics()
    {   
        if(PlayerPrefs.GetString("Graphics") == "RTX"){
            print(1);
            PlayerPrefs.SetString("Graphics", "Poopy");
        }
        else if(PlayerPrefs.GetString("Graphics") == "Poopy"){
            PlayerPrefs.SetString("Graphics", "RTX");
            print(2);
        }
        print(PlayerPrefs.GetString("Graphics"));
    }
}
