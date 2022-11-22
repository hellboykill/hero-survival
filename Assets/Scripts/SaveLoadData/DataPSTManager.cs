using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPSTManager : MonoBehaviour
{
    [Header("File Storage Config")]
    public string fileName;

    public GameData gameData;

    private FileDataHandler dataHandler;

    private List<IDataPersistance> dataPersistenceObjects;
    public static DataPSTManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one dataPST in scene");
        }
        instance = this;
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        GetAllDataPersistence();                                                    
        GameEvent.Instance.OnGetAllIdataPersisTence += GetAllDataPersistence;
        LoadGame();
    }
    private void OnDisable()
    {
        GameEvent.Instance.OnGetAllIdataPersisTence -= GetAllDataPersistence;
    }

    private void GetAllDataPersistence()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceobjects();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {

        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No data was found, then initializing");
            NewGame();
        }
        foreach (IDataPersistance dataPersistanceObj in dataPersistenceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        if (dataPersistenceObjects == null)
            return;
        foreach (IDataPersistance datapersistenceObj in dataPersistenceObjects)
        {
            if (datapersistenceObj != null)
            {
                datapersistenceObj.SaveData(ref gameData);
            }
        }

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private void OnApplicationPause(bool pause)
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistenceobjects()
    {
        IEnumerable<IDataPersistance> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistenceObjects);
    }
}
