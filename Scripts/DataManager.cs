using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SaveElements Data;

    private string file = "playerData.txt";

    public void Save()
    {
        string json = JsonUtility.ToJson(Data);
        WriteToFile(file, json);
    }

    public void Load()
    {
        Data = new SaveElements();
        string json = ReadFromFile(file);
        if (json != "")
        {
            JsonUtility.FromJsonOverwrite(json, Data);
        }
    }
    
    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using StreamWriter writer = new StreamWriter(fileStream);
        writer.Write(json);
    }

    private string GetFilePath(string fileName)
    {
        Debug.Log(Application.persistentDataPath);
        return Application.persistentDataPath + "/" + fileName;
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using StreamReader reader = new StreamReader(path);
            string json = reader.ReadToEnd();
            return json;
        }
        else
        {
            Debug.LogWarning("File not found");
        }

        return "";
    }
}
