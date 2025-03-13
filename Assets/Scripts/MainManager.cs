using System;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public Color teamColor;
    public void SaveColor()
    {
        PlayerData data = new PlayerData();
        data.teamColor = teamColor;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            teamColor = data.teamColor;
        }
    }
}
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public PlayerData playerData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

