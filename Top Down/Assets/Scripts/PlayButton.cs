using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    Button pb;

    void Start(){
        pb = GetComponent<Button>();
        pb.onClick.AddListener(NextScene);
    }
    void NextScene(){
        SceneManager.LoadScene(1);
    }
}
