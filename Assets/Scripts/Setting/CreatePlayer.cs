using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class CreatePlayer : MonoBehaviour
{
    public InputField playerNameInput;

    // File path for saving player names
    private string saveFilePath;

    // List to store player names
    private static List<string> registeredPlayerNames = new List<string>();

    void Start()
    {
        // Make sure the InputField playerNameInput is assigned in the Unity editor
        if (playerNameInput == null)
        {
            Debug.LogError("PlayerNameInput is not assigned!");
        }

        // Set the save file path
        saveFilePath = Path.Combine(Application.persistentDataPath, "playerNames.json");

        // Load saved player names from disk
        LoadPlayerNames();
    }

    public void RegisterPlayer()
    {
        // Retrieve the player name from the InputField
        string playerName = playerNameInput.text;

        // Check if the name is not empty before proceeding
        if (!string.IsNullOrEmpty(playerName))
        {
            // Check if the playerName is already taken
            if (!IsPlayerNameTaken(playerName))
            {
                // Create a new instance of PlayerData with default score and time
                PlayerData playerData = new PlayerData(playerName, 0, 0f);

                // Save the PlayerData (you can also save it to disk here if necessary)
                Debug.Log("Player registered: " + playerData.PlayerName);

                // Add the playerName to the list of registered players
                registeredPlayerNames.Add(playerName);

                // Save the updated list to disk
                SavePlayerNames();
                 SceneManager.LoadScene("MainMenu");
                
            }
            else
            {
                Debug.LogWarning("PlayerName is already taken. Please choose a different name.");
            }
        }
        else
        {
            Debug.LogWarning("PlayerName cannot be empty!");
        }
    }

    bool IsPlayerNameTaken(string playerName)
    {
        // Check if the playerName is already in the list of registered players
        return registeredPlayerNames.Contains(playerName);
    }

    void SavePlayerNames()
    {
        // Convert the list of player names to JSON
        string json = JsonUtility.ToJson(registeredPlayerNames);

        // Write the JSON to the save file on disk
        File.WriteAllText(saveFilePath, json);
    }

    void LoadPlayerNames()
    {
        if (File.Exists(saveFilePath))
        {
            // Read the JSON from the save file on disk
            string json = File.ReadAllText(saveFilePath);

            // Deserialize the JSON to get the saved player names
            registeredPlayerNames = JsonUtility.FromJson<List<string>>(json);
        }
    }
}
