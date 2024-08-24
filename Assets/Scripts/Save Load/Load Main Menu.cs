using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadMainMenu : MonoBehaviour
{
    public TMP_Text LoadText;
    public bool BoolHasDataToLoad = false;
    public string SceneNameMenu = "Sweet Home";
    
    private void Awake(){
        HasDataToLoad();
    }
    public void LoadOnClick(){
        LoadData();
    }
    public void SettingsMenuOnClick(){
        SceneManager.LoadScene("Settings Menu");
    }
    public void ResetOnClick(){
        NewGame();
    }

    private void HasDataToLoad(){
        if(File.Exists(Application.persistentDataPath + "/SaveDataNohowEnding.dat")){
            BoolHasDataToLoad = true;
            LoadText.color = new UnityEngine.Color(1, 1, 1, 1);
        }
    }

    private void SetValues(){
        SceneManager.LoadScene(SceneNameMenu);
    }

    private void LoadData(){
        if(BoolHasDataToLoad){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream FileData = File.Open(Application.persistentDataPath + "/SaveDataNohowEnding.dat", FileMode.Open);
            DataSave LastData = (DataSave)bf.Deserialize(FileData);
            FileData.Close();
            SceneNameMenu = LastData.SceneNameSaved;
            SetValues();
            Debug.Log("Loaded");
        }
        else Debug.Log("No data to load");
    }

    private void NewGame(){
        if(BoolHasDataToLoad){
            File.Delete(Application.persistentDataPath + "/SaveDataNohowEnding.dat");
            SceneNameMenu = "Sweet Home";
        }
        SetValues();
        Debug.Log("New Game Started");
    }
}
