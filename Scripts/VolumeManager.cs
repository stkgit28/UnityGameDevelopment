using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public DataManager dataManager;
    public AudioMixer mixer;

    public void Start()
    {
        dataManager.Load();
        if (dataManager.Data.Volume != 0.0f)
        {
            mixer.SetFloat("MusicVol", Mathf.Log10(dataManager.Data.Volume)*20);
        }

    }

}