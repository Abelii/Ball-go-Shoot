using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class RTXCam : MonoBehaviour
{
   [SerializeField] private PostProcessVolume _PostProcessVolume;
   private Bloom _bloom;
   private Vignette _vignette;

   private void Start() {
       {
           _PostProcessVolume.profile.TryGetSettings(out _bloom);
           _PostProcessVolume.profile.TryGetSettings(out _vignette);
       }

   }
    void Update() {
        if(PlayerPrefs.GetString("Graphics") == "Poopy"){
            _vignette.active = false;
            _bloom.active = false;
        }
        if(PlayerPrefs.GetString("Graphics") == "RTX"){
            _bloom.active = true;
            _vignette.active = true;
        }
    }
}

