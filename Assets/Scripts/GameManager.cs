using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private string saveFilePath;
    private PlayerData playerData;

    void Start()
    {
        // Définissez le chemin du fichier de sauvegarde
        saveFilePath = Path.Combine(Application.persistentDataPath, "save.json");

        // Chargez les données du joueur au démarrage du jeu
        LoadPlayerData();
    }

    void SavePlayerData()
    {
        // Sérialisez les données du joueur en JSON
        string json = JsonUtility.ToJson(playerData);

        // Écrivez le JSON dans le fichier de sauvegarde
        File.WriteAllText(saveFilePath, json);
    }

    void LoadPlayerData()
    {
        if (File.Exists(saveFilePath))
        {
            // Lisez le JSON depuis le fichier de sauvegarde
            string json = File.ReadAllText(saveFilePath);

            // Désérialisez le JSON pour obtenir les données du joueur
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            // Si le fichier de sauvegarde n'existe pas, créez une nouvelle instance de PlayerData
            playerData = new PlayerData(playerData.PlayerName, playerData.Score, playerData.TimeElapsed);
        }
    }

    // Exemple d'utilisation :
    void Update()
    {
        // Exemple de modification des données du joueur
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerData.Score += 10;
            SavePlayerData();
        }

        // Exemple d'affichage des données du joueur
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Player Score: " + playerData.Score);
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string PlayerName;
    public int Score;
    public float TimeElapsed;

    public PlayerData(string playerName, int score, float timeElapsed)
    {
        PlayerName = playerName;
        Score = score;
        TimeElapsed = timeElapsed;
    }
}
