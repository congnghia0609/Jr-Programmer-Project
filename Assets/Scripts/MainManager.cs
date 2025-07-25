using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
  public static MainManager Instance;
  public Color TeamColor;

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
    LoadColor();
  }

  // Ref: https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
  public void SaveColor()
  {
    SaveData data = new SaveData();
    data.TeamColor = TeamColor;
    string json = JsonUtility.ToJson(data);
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
  }

  public void LoadColor()
  {
    string path = Application.persistentDataPath + "/savefile.json";
    Debug.Log(path);
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      SaveData data = JsonUtility.FromJson<SaveData>(json);
      TeamColor = data.TeamColor;
    }
  }
}

[System.Serializable]
public class SaveData
{
  public Color TeamColor;
}
