using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;



public class TriggerParent : MonoBehaviour
{
    public string SceneName;
    public Vector2 TaiPosition, CameraPosition;
    public bool IsOnTrigger = false;

    public TriggerParent(string _SceneName, Vector2 _TaiPosition, Vector2 _CameraPosition){
        this.SceneName = _SceneName;
        this.TaiPosition = _TaiPosition;
        this.CameraPosition = _CameraPosition;
    }

    public void InTrigger(Collider2D other) {
        if (other.gameObject.name == "Taisiya"){
            this.IsOnTrigger = true;
            Debug.Log("Press space");
        }
    }

    public void OutTrigger(Collider2D other) {
        this.IsOnTrigger = false;
        Debug.Log("End of trigger");
    }

    public void Redirect(){
        if(this.IsOnTrigger){
            if(Input.GetKeyDown(KeyCode.Space)){
                // сохранение в файл
                BinaryFormatter bf = new BinaryFormatter();
                FileStream FileData = File.Create(Application.persistentDataPath + "/SaveDataNohowEnding.dat");
                DataSave LastData = new DataSave();
                LastData.SceneNameSaved = this.SceneName;
                LastData.XTaiSaved = this.TaiPosition.x;
                LastData.YTaiSaved = this.TaiPosition.y;
                LastData.XCameraSaved = this.CameraPosition.x;
                LastData.YCameraSaved = this.CameraPosition.y;
                bf.Serialize(FileData, LastData);
                FileData.Close();
                SceneManager.LoadScene(this.SceneName);
                Debug.Log("Redirected to " + this.SceneName + " on coords " + this.TaiPosition + ". Camera coords = " + this.CameraPosition + ". ");
            }
        }
    }
}

