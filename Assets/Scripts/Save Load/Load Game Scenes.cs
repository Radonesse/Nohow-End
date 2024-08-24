using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadGameScenes : MonoBehaviour
{
    private bool BoolHasDataToLoad = false;
    public GameObject Taisiya, Camera;
    private Vector2 PositionTai = new Vector2(-2.28f, -6.42f), PositionCamera = new Vector2(-2.28f, -6f);

    private void Awake(){
        HasDataToLoad();
        LoadData();
    }

    private void HasDataToLoad(){
        if(File.Exists(Application.persistentDataPath + "/SaveDataNohowEnding.dat")){
            BoolHasDataToLoad = true;
        }
    }

    private void SetValues(){
        Taisiya.GetComponent<Rigidbody2D>().position = PositionTai;
        Camera.GetComponent<Rigidbody2D>().position = PositionCamera;
    }

    private void LoadData(){
        if(BoolHasDataToLoad){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream FileData = File.Open(Application.persistentDataPath + "/SaveDataNohowEnding.dat", FileMode.Open);
            DataSave LastData = (DataSave)bf.Deserialize(FileData);
            FileData.Close();
            PositionTai = new Vector2(LastData.XTaiSaved, LastData.YTaiSaved);
            PositionCamera = new Vector2(LastData.XCameraSaved, LastData.YCameraSaved);
            Debug.Log("Scene Settings Loaded");
        }
        else Debug.Log("New Game Started In Scene");
        SetValues();
    }
}
