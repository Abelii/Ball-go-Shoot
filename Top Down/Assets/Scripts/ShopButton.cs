using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    Button sb;

    void Start(){
        sb = GetComponent<Button>();
        sb.onClick.AddListener(NextScene);
    }
    void NextScene(){
        SceneManager.LoadScene(1);
    }
}
