using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBTNShop : MonoBehaviour
{
    Button mb;

    void Start(){
        mb = GetComponent<Button>();
        mb.onClick.AddListener(NextScene);
    }
    void NextScene(){
        SceneManager.LoadScene(0);
    }
}
