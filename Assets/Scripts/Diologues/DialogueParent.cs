using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueParent : MonoBehaviour
{
    public List<string> Phrase;
    public bool IsOnTrigger = false;
    public int Count = 0;
    public TextMeshProUGUI Text;
    public GameObject TextParent;

    public void GetText(){
        // this.Text = (GameObject.Find("/CameraInGameScenes/Diologue/DiologueWindow/DialogueText")).GetComponent<TextMeshProUGUI>();
        // this.Text = TextParent.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
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
        Debug.Log("End of trigger");
    }

    public void Talk(){
        if(this.IsOnTrigger){
            if(Input.GetKeyDown(KeyCode.Space)){
                if (this.Count < this.Phrase.Count){
                    // Debug.Log(this.Text.text);
                    Debug.Log(this.Phrase[this.Count]);
                    this.Count++;
                }
                else{
                    Debug.Log("End of dialogue");
                    this.Count = 0;
                }
            }
        }
    }

    // public void TMPWorkPlease(){
    //     Debug.Log(this.Text.text);
    // }
}
