using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MM_Handler : MonoBehaviour
{
  private string[] _gameNames = new string[] {
    "Codeverse: Stranded in Space",
    "C# Survival: A Programmer's Odyssey",
    "Binary Blast: Stranded Programmer",
    "Syntax Station: The Ultimate Challenge",
    "C# Quest: Lost in Space",
    "The Coding Cosmos: A Stranded Programmer's Tale",
    "Programmed for Survival: The C# Challenge",
    "C# Crash Course: Stranded in the Cosmos",
    "The C# Chronicles: Stranded in the Station",
    "Space Syntax: A Programmer's Survival Story",
    "System Shocked: A C# Programmer's Odyssey",
    "Galactic Code: The Stranded Programmer",
    "Starship Syntax: A C# Survival Story",
    "C# Conquest: Stranded in Space",
    "The Syntax Saga: A Programmer's Journey",
    "Code Crusade: A C# Programmer's Survival Story",
    "The C# Chronicles: Stranded in the Stars",
    "Mission: Code Repair",
    "C# Cosmos: A Programmer's Tale",
    "Planet Programmer: A C# Survival Story",
    "Code Cadet: A C# Programmer's Challenge",
    "Space Syntax: A C# Programmer's Journey",
    "Code Crash: A Stranded Programmer's Tale",
    "Programmed for Disaster: A C# Programmer's Odyssey",
    "Binary Bunker: A Stranded Programmer's Challenge",
    "Syntax Survival: A C# Programmer's Odyssey",
    "C# Catastrophe: A Stranded Programmer's Tale",
    "Code Crusader: A Stranded Programmer's Challenge",
    "C# Crisis: A Programmer's Survival Story",
    "Syntax Station: A C# Programmer's Journey",
    "Code Cosmos: A Stranded Programmer's Tale",
    "C# Cataclysm: A Programmer's Survival Story",
    "Binary Breakdown: A Stranded Programmer's Challenge",
    "Programmed to Survive: A C# Programmer's Odyssey",
    "Code Crisis: A Stranded Programmer's Tale",
    "Syntax Stranded: A C# Programmer's Challenge",
    "C# Catastrophic: A Stranded Programmer's Odyssey",
    "Binary Breakthrough: A Programmer's Survival Story",
    "Code Colony: A C# Programmer's Journey",
    "Syntax Struggle: A Stranded Programmer's Tale",
    "C# Catastrophize: A Programmer's Challenge",
    "Binary Bounceback: A C# Programmer's Survival Story",
    "Code Conquer: A Stranded Programmer's Odyssey",
    "Syntax Scavenger: A C# Programmer's Journey",
    "C# Cataclysmic: A Programmer's Survival Story",
    "Binary Backup: A Stranded Programmer's Challenge",
    "Code Crusade: A C# Programmer's Tale",
    "Syntax Solitude: A Stranded Programmer's Odyssey",
    "C# Crash Course: A Programmer's Challenge",
    "Binary Bridge: A C# Programmer's Journey",
    "Code Chaos: A Stranded Programmer's Survival Story",
    "Syntax Stranded: A C# Programmer's Odyssey",
    "C# Catastrophism: A Programmer's Tale",
    "Binary Brigade: A Stranded Programmer's Challenge",
    "Code Commander: A C# Programmer's Survival Story",
    "Syntax Strife: A Stranded Programmer's Odyssey",
    "C# Crisis Control: A Programmer's Challenge",
    "Binary Battleship: A C# Programmer's Tale",
    "Code Catastrophe: A Stranded Programmer's Survival Story"
    };
  
    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _gameNames[Random.Range(0, _gameNames.Length)];
        
        // set the button functions
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(StartGame);
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(Application.Quit);
    }
    
    void Update()
    {
        // slowly change the rotation of main camera over time
        Camera.main.transform.Rotate(0, 0.001f, 0);
    }
    
    private void StartGame()
    {
        // load the ship deck scene
        SceneManager.LoadScene("1 - Ship Deck");
    }
}
