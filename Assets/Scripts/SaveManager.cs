using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class SaveManager
{
    private string SaveDirectory => Path.Combine(Application.persistentDataPath, "saves");

    private string GetSavePath(int slot)
    {
        return Path.Combine(SaveDirectory, $"slot_{slot}.json");
    }

    public void Save(int slot, GameState state)
    {
        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }

        string json = JsonConvert.SerializeObject(state, Formatting.Indented);
        File.WriteAllText(GetSavePath(slot), json);

        Debug.Log($"Saved slot {slot} to {GetSavePath(slot)}");
    }

    public GameState Load(int slot)
    {
        string path = GetSavePath(slot);

        if (!File.Exists(path))
        {
            Debug.LogWarning($"No save found at slot {slot}");
            return null;
        }

        string json = File.ReadAllText(path);
        GameState state = JsonConvert.DeserializeObject<GameState>(json);

        Debug.Log($"Loaded slot {slot}");
        return state;
    }

    public bool SaveExists(int slot)
    {
        return File.Exists(GetSavePath(slot));
    }

    public void Delete(int slot)
    {
        string path = GetSavePath(slot);

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"Deleted save slot {slot}");
        }
        else
        {
            Debug.LogWarning($"Tried to delete non-existent save slot {slot}");
        }
    }
    
}