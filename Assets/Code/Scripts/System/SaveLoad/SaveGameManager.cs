using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace Code.Scripts.System.SaveLoad
{
    [Serializable]
    public class SaveGame
    {
        // Game Settings
        public bool isFullscreen = false;
        public int resolutionIndex = 2;
        public int fontSize = 3;
        public float volume = 1.0f;
        public float musicVolume = 1.0f;
        public float sfxVolume = 1.0f;
        public float voiceVolume = 1.0f;
        
        // Game Progress
        public List<int> completedLessons = new List<int>();
        
        // Scene Settings
        public int gameSpeed = 1;
        
        // Graphic Settings
        public int quality = 5; // Default is Ultra
    }
    
    public class SaveGameManager : MonoBehaviour
    {
        private string _savePath;
        private string _codePath;
        public bool isLoaded = false;
        private string _saveContent = "";

        private readonly float _autoSaveTimer = 60 * 5; // auto saves the settings every 5 minutes
        private float _lastAutoSave = 0f;

        private string[] _lessonCodeFile = new[]
        {
            "Lesson00", "Lesson01", "Lesson02", "Lesson03", "Lesson04", "Lesson05",
            "Lesson06", "Lesson07", "Lesson08", "Lesson09", "Lesson10", "Lesson11", "Lesson12"
        };
        
        public SaveGame saveGame;
        
        public AudioSource _sfxAudioSource;
        public AudioSource _musicAudioSource;
        
        private void Start()
        {
            if (FindObjectsOfType<SaveGameManager>().Length > 1)
                Destroy(gameObject);
            
            // Keep SaveGameManager alive between scenes
            DontDestroyOnLoad(gameObject);
            
            Application.targetFrameRate = 60;
            
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
            {
                _savePath = Application.persistentDataPath;
                _codePath = Application.persistentDataPath + "/code";

                if (!Directory.Exists(_codePath))
                {
                    Directory.CreateDirectory(_codePath);
                }
                
                if (!File.Exists(_savePath + "/save.json"))
                {
                    saveGame = new SaveGame();   
                    File.WriteAllText(_savePath + "/save.json", JsonUtility.ToJson(saveGame));
                }
                else
                {
                    _saveContent = File.ReadAllText(_savePath + "/save.json");
                    saveGame = JsonUtility.FromJson<SaveGame>(_saveContent);

                    _musicAudioSource.volume = saveGame.musicVolume * saveGame.volume;
                    _sfxAudioSource.volume = saveGame.sfxVolume * saveGame.volume;

                    if (saveGame.completedLessons.Count > 0)
                    {
                       // Load the game data
                       QualitySettings.SetQualityLevel(saveGame.quality, true);
                    }
                    
                    isLoaded = true;
                }
                
                // Create .cs files for every Lesson
                foreach (var fileName in _lessonCodeFile)
                {
                    if (!File.Exists(_codePath + "/" + fileName + ".cs"))
                    {
                        File.WriteAllText(_codePath + "/" + fileName + ".cs", "");
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if (_lastAutoSave + _autoSaveTimer < Time.time)
            {
                Save();
                _lastAutoSave = Time.time;
            }
        }

        private void Save()
        {
            try
            {
                File.WriteAllText(_savePath + "/save.json", JsonUtility.ToJson(saveGame));
            }
            catch (Exception e)
            {
                print("Could not save the game: " + e.ToString());
                throw;
            }
        }
        
        public void ResetSaveGame()
        {
            saveGame = new SaveGame();
            Save();
        }

        public void SetResolutionIndex(int index)
        {
            saveGame.resolutionIndex = index;
        }
        
        public void SetFullscreen(bool isFullscreen)
        {
            saveGame.isFullscreen = isFullscreen;
        }
        
        public void SetMasterVolume(float volume)
        {
            saveGame.volume = volume;
        }
        
        public void SetMasterVolume(Slider slider)
        {
            _musicAudioSource.volume = slider.value * saveGame.volume;
            _sfxAudioSource.volume = slider.value * saveGame.volume;
            saveGame.volume = slider.value;
        }
        
        public void SetMusicVolume(float musicVolume)
        {
            saveGame.musicVolume = musicVolume;
        }
        
        public void SetMusicVolume(Slider slider)
        {
            _musicAudioSource.volume = slider.value * saveGame.volume;
            saveGame.musicVolume = slider.value;
        }
        
        public void SetSfxVolume(float sfxVolume)
        {
            saveGame.sfxVolume = sfxVolume;
        }
        
        public void SetSfxVolume(Slider slider)
        {
            _sfxAudioSource.volume = slider.value * saveGame.volume;
            saveGame.sfxVolume = slider.value;
        }
        
        public void SetVoiceVolume(float voiceVolume)
        {
            saveGame.voiceVolume = voiceVolume;
        }
        
        public void SetVoiceVolume(Slider slider)
        {
            saveGame.voiceVolume = slider.value;
        }
        
        public bool IsLessonCompleted(string name)
        {
            var index = Array.IndexOf(_lessonCodeFile, name);
            return index != -1 && saveGame.completedLessons.Contains(index);
        }
        
        public void SetCompletedLessons(List<int> completedLessons)
        {
            saveGame.completedLessons = completedLessons;
        }

        public void CompleteLessonByName(string name)
        {
            var index = Array.IndexOf(_lessonCodeFile, name);
            if (index != -1 && !saveGame.completedLessons.Contains(index))
            {
                saveGame.completedLessons.Add(index);
                Save();
            }
        }

        public void SetGameSpeed(int gameSpeed)
        {
            saveGame.gameSpeed = gameSpeed;
        }
        
        public void SetQualityLevel(Dropdown dropdown)
        {
            saveGame.quality = dropdown.value;
            QualitySettings.SetQualityLevel(saveGame.quality, true);
            Save();
        } 
    }
}
