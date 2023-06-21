using System;
using Code.Scripts.System.SaveLoad;
using TMPro;
using UnityEngine;

namespace Code.Scripts.Environments.Ship_Deck
{
    public class Monitor : MonoBehaviour
    {
        private string sharpOS =
            "<size='1'>SharpOS</size>\n\nFATAL: SEVERE HARDWARE FAILURE\n\n" +
            "It seems like your main circuit board is not working correctly. Please make sure that all nodes are connected to ensure the system has enough power.\n\n";

        public TMPro.TextMeshPro text;
        
        private void Start()
        {
            var saveGameManager = FindObjectOfType<SaveGameManager>();
            
            if (saveGameManager != null)
            {
                print(saveGameManager.saveGame.completedLessons.Count );
                float progress = (saveGameManager.saveGame.completedLessons.Count / 12.0f) * 100;
                sharpOS += progress + "% Power";
                text.text = sharpOS;
            }
        }
    }
}