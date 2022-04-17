using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    void Update(){GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("highScore").ToString();}
}
