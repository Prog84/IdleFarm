using System;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour, ISaveManager{
    private string _saveFolderName = "Save";
    private static string CloudFileName = "PlayerData.svf";
    private string _passSalt = "IdleFarmSave";

    public void Save(SaveData saveData) {
        SaveToFile(saveData, SaveManager.CloudFileName);
    }

    public SaveData Load() {
        var data = LoadFromFile<SaveData>(SaveManager.CloudFileName);
        return data;
    }

    public void SaveToFile<T>(T data, string filePath) {
        if (data == null) {
            return;
        }

        if (Directory.Exists(Application.persistentDataPath) == false) {
            Directory.CreateDirectory(Application.persistentDataPath);
        }

        if (Directory.Exists(Path.Combine(Application.persistentDataPath, _saveFolderName)) == false) {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, _saveFolderName));
        }

        var encryptData = Crypto.Encrypt(JsonUtility.ToJson(data), _passSalt);
        try {
            File.WriteAllText(Path.Combine(Application.persistentDataPath, _saveFolderName, filePath),
                encryptData /*JsonUtility.ToJson(encryptData)*/);
        }
        catch (Exception ex) {
            Debug.LogError("Cannot save: " + ex.Message);
        }
    }

    public T LoadFromFile<T>(string fileName) where T : new() {
        if (File.Exists(Path.Combine(Application.persistentDataPath, _saveFolderName, fileName))) {
            var data = File.ReadAllText(Path.Combine(Application.persistentDataPath, _saveFolderName, fileName));
            if (data != null) {
                return JsonUtility.FromJson<T>(Crypto.Decrypt(data, _passSalt));
            }
        }

        Debug.Log("Load");
        return new T();
    }
}