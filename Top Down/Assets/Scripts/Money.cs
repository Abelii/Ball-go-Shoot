using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    void Update(){GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("money").ToString();}
}
