using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameScenes : MonoBehaviour
{
    private string SceneNameToSave;
    public GameObject panelUI, Taisiya, Camera;
    private Vector2 PositionTaiToSave, PositionCameraToSave;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            panelUI.SetActive(true);
        }
    }

    public void SaveAndEscapeOnClick(){
        SaveData();
    }
    public void BackOnClick(){
        panelUI.SetActive(false);
    }

    private void GetValuesToSave(){
        SceneNameToSave = SceneManager.GetActiveScene().name;
        PositionTaiToSave = Taisiya.GetComponent<Rigidbody2D>().position;
        PositionCameraToSave = Camera.GetComponent<Rigidbody2D>().position;
    }

    void SaveData(){
        GetValuesToSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream FileData = File.Create(Application.persistentDataPath + "/SaveDataNohowEnding.dat");
        DataSave LastData = new DataSave();
        LastData.SceneNameSaved = SceneNameToSave;
        LastData.XTaiSaved = PositionTaiToSave.x;
        LastData.YTaiSaved = PositionTaiToSave.y;
        LastData.XCameraSaved = PositionCameraToSave.x;
        LastData.YCameraSaved = PositionCameraToSave.y;
        bf.Serialize(FileData, LastData);
        FileData.Close();
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Saved");
    }
}

[Serializable]
public class DataSave{
    public string SceneNameSaved;
    public float XTaiSaved, YTaiSaved, XCameraSaved, YCameraSaved;
}