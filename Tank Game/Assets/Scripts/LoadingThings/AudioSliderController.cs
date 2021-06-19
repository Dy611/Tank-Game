using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TankGame.Menus
{
    [RequireComponent(typeof(Slider))]
    public class AudioSliderController : MonoBehaviour
    {
        private Slider slider { get { return GetComponent<Slider>(); } }

        [Tooltip("This is the name of the exposed parameter in your AudioMixer")]
        [SerializeField]
        private string volumeName = "Enter Volume Parameter Name Here";

        [Tooltip("Text to set volume percentage to")]
        [SerializeField]
        private TMP_Text volumeText;

        private void Start()
        {
            ResetSliderValue();
            slider.onValueChanged.AddListener(delegate { SliderChanged(slider.value); });
        }

        public void ResetSliderValue()
        {
            if (MenuManager.settings)
            {
                float volume = MenuManager.settings.LoadAudioLevels(volumeName);
                SliderChanged(volume);
                slider.value = volume;
            }
        }

        public void SliderChanged(float value)
        {
            if (volumeText != null)
                volumeText.text = Mathf.Round(value * 100.0f).ToString() + "%";

            if (MenuManager.settings)
                MenuManager.settings.SetAudioLevels(volumeName, value);

            if (MenuManager.settings && MenuManager.settings.audioMixer != null)
                MenuManager.settings.SaveAudioLevels(volumeName, value);
        }
    }
}