using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueParent : MonoBehaviour
{
    public List<string> Phrase;
    public bool IsOnTrigger = false;
    public int Count = 0;
    public GameObject TextWindow;
    public TextMeshProUGUI Text;

    public void GetText(){
        this.TextWindow = GameObject.Find("CameraInGameScenes").transform.GetChild(3).gameObject;
        this.Text = TextWindow.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public DialogueParent(List<string> _Phrase){
        this.Phrase = _Phrase;
    }

    public void InTrigger(Collider2D other) {
        if (other.gameObject.name == "Taisiya"){
            this.IsOnTrigger = true;
            Debug.Log("Press Space to talk");
        }
    }

    public void OutTrigger(Collider2D other) {
        this.IsOnTrigger = false;
        Count = 0;
        Debug.Log("End of trigger");
    }

    public void Talk(){
        if(this.IsOnTrigger){
            if(Input.GetKeyDown(KeyCode.Space)){
                if (this.Count < this.Phrase.Count){
                    TextWindow.SetActive(true);
                    Text.text = this.Phrase[this.Count];
                    this.Count++;
                }
                else{
                    TextWindow.SetActive(false);
                    this.Count = 0;
                    Debug.Log("End of dialogue");
                }
            }
        }
    }
}
