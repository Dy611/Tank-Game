using UnityEngine;
using UnityEngine.Audio;

//Created from "The Messy Coder" "How To Save Volume Settings In Unity"
[System.Serializable]
public struct MixerInfo
{
    public string name;
    public float volume;
}

[CreateAssetMenu(menuName = "Tank Game/Create Settings")]
public class Settings : ScriptableObject
{
    public bool saveInPlayerPrefs = true;
    public string prefPrefix = "Settings_";

    #region Audio Functions
    public AudioMixer audioMixer;
    public MixerInfo[] mixersInfo;

    public float LoadAudioLevels(string name)
    {
        float volume = 1f;

        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles file");
            return volume;
        }

        for (int i = 0; i < mixersInfo.Length; i++)
        {
            if (mixersInfo[i].name == name)
            {
                if (saveInPlayerPrefs && PlayerPrefs.HasKey(prefPrefix + mixersInfo[i].name))
                {
                    mixersInfo[i].volume = PlayerPrefs.GetFloat(prefPrefix + mixersInfo[i].name);
                }
                audioMixer.SetFloat(mixersInfo[i].name, Mathf.Log(mixersInfo[i].volume) * 20f);
                volume = mixersInfo[i].volume;
                break;
            }
        }
        return volume;
    }

    public void LoadAudioLevels()
    {
        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles file");
            return;
        }

        for (int i = 0; i < mixersInfo.Length; i++)
        {
            if (saveInPlayerPrefs)
            {
                if (PlayerPrefs.HasKey(prefPrefix + mixersInfo[i].name))
                {
                    mixersInfo[i].volume = PlayerPrefs.GetFloat(prefPrefix + mixersInfo[i].name);
                }
            }
            audioMixer.SetFloat(mixersInfo[i].name, Mathf.Log(mixersInfo[i].volume) * 20f);
        }
    }

    public void SetAudioLevels(string name, float volume)
    {
        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles file");
            return;
        }

        for (int i = 0; i < mixersInfo.Length; i++)
        {
            if (mixersInfo[i].name == name)
            {
                audioMixer.SetFloat(mixersInfo[i].name, Mathf.Log(volume) * 20f);
                break;
            }
        }
    }

    public void SaveAudioLevels(string name, float volume)
    {
        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles file");
            return;
        }

        for (int i = 0; i < mixersInfo.Length; i++)
        {
            if (mixersInfo[i].name == name)
            {
                if (saveInPlayerPrefs)
                {
                    PlayerPrefs.SetFloat(prefPrefix + name, volume);
                }
                audioMixer.SetFloat(name, Mathf.Log(volume) * 20f);
                mixersInfo[i].volume = volume;
            }
        }
    }
    #endregion Audio Functions
}