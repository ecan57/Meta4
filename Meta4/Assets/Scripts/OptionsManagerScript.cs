using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManagerScript : MonoBehaviour
{
    [SerializeField] Toggle mute;
    [SerializeField] Toggle windowed;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeText;
    
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Mute"))
            PlayerPrefs.SetInt("Mute", 0);
        else
            LoadMuteToggle();
        if (!PlayerPrefs.HasKey("Windowed"))
            PlayerPrefs.SetInt("Windowed", 0);
        else
            LoadWindowedToggle();
    }

    private void Update()
    {
        LoadVolume();
    }

    private void LoadMuteToggle()
    {
        mute.isOn = PlayerPrefs.GetInt("Mute") == 1;
    }

    private void LoadWindowedToggle()
    {
        windowed.isOn = PlayerPrefs.GetInt("Windowed") == 1;
    }

    public void MuteToggle()
    {
        PlayerPrefs.SetInt("Mute", mute.isOn ? 1 : 0);
        if(mute.isOn )
            AudioListener.pause = true;
        else
            AudioListener.pause = false;
    }

    public void WindowedToggle()
    {
        PlayerPrefs.SetInt("Windowed", windowed.isOn ? 1 : 0);
        if (!windowed.isOn )
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    private void LoadVolume() //Sliderý kontrol ediyor
    {
        float volumValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumValue;
        AudioListener.volume = volumValue;
    }
    public void VolumeControl(float volume) //yapýlan kontrolü uygulayacak
    {
        volumeText.text = "Volume " + volume.ToString("0");
        float volumeValue = volumeSlider.value; //buradaki volume deðeri unityde deðiþtirilen slider üzerinden gelen deðer
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }
}
