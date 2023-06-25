using System;
using Code.Scripts.System.SaveLoad;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Code.Scripts.Main_Menu
{
    public class MM_Settings : MonoBehaviour
    {
        public Dropdown displayDropdown;
        public Dropdown qualityDropdown;
        public Dropdown resolutionDropdown;
        public Slider volumeSlider;
        public Slider musicSlider;
        public Slider sfxSlider;
        public Slider voiceSlider;

        private void Start()
        {
            var saveGameManager = FindObjectOfType<SaveGameManager>();
            if (saveGameManager != null)
            {
                displayDropdown.value = saveGameManager.saveGame.displayMode;
                resolutionDropdown.value = saveGameManager.saveGame.resolutionIndex;
                qualityDropdown.value = saveGameManager.saveGame.quality;
                displayDropdown.onValueChanged.AddListener(saveGameManager.SetDisplayMode);
                resolutionDropdown.onValueChanged.AddListener(saveGameManager.SetResolutionIndex);
                qualityDropdown.onValueChanged.AddListener(saveGameManager.SetQualityLevel);
                
                volumeSlider.onValueChanged.AddListener(saveGameManager.SetMasterVolume);
                musicSlider.onValueChanged.AddListener(saveGameManager.SetMusicVolume);
                sfxSlider.onValueChanged.AddListener(saveGameManager.SetSfxVolume);
                voiceSlider.onValueChanged.AddListener(saveGameManager.SetVoiceVolume);
                
                volumeSlider.value = saveGameManager.saveGame.volume;
                musicSlider.value = saveGameManager.saveGame.musicVolume;
                sfxSlider.value = saveGameManager.saveGame.sfxVolume;
                voiceSlider.value = saveGameManager.saveGame.voiceVolume;
                
                print("Added Listeners to Settings");
            }
        }
    }
}