using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance { get; private set; }

    //Valores para salvar
    public int UnlockedStages;
	public string CurrentStage;

    private void Awake()
    {

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

            UnlockedStages = data.UnlockedStages;
			CurrentStage = data.CurrentStage;

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveInfo.ratoelho");
        PlayerData_Storage data = new PlayerData_Storage();
		
        data.UnlockedStages = UnlockedStages;
		data.CurrentStage = CurrentStage;
		
        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]

class PlayerData_Storage
{
    public int UnlockedStages;
	public string CurrentStage;
}