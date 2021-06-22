using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance { get; private set; }

    //Valores para salvar
	public string GameLanguage;
    public int UnlockedStages;
	public string CurrentStage;
	public bool S1Checkpoint;
	public bool S2Checkpoint;
	public int Score;
	public int HighScore;

    private void Awake()
    {
		if(CurrentStage == "") CurrentStage = "Stage1";
		
        print(Application.persistentDataPath);
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        Load();
    }
	
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveInfo.ratoelho"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveInfo.ratoelho", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);
			
			GameLanguage = data.GameLanguage;
            UnlockedStages = data.UnlockedStages;
			CurrentStage = data.CurrentStage;
			S1Checkpoint = data.S1Checkpoint;
			S2Checkpoint = data.S2Checkpoint;
			Score = data.Score;
			HighScore = data.HighScore;

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveInfo.ratoelho");
        PlayerData_Storage data = new PlayerData_Storage();
		
		data.GameLanguage = GameLanguage;
        data.UnlockedStages = UnlockedStages;
		data.CurrentStage = CurrentStage;
		data.S1Checkpoint = S1Checkpoint;
		data.S2Checkpoint = S2Checkpoint;
		data.Score = Score;
		data.HighScore = HighScore;
		
        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]

class PlayerData_Storage
{
	public string GameLanguage;
    public int UnlockedStages;
	public string CurrentStage;
	public bool S1Checkpoint;
	public bool S2Checkpoint;
	public int Score;
	public int HighScore;
}