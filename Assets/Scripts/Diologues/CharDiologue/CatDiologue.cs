using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDialogue : MonoBehaviour
{
    DialogueParent _CatDialogue = new DialogueParent(new List<string>(){"Hey", "Go away girl"});

    private void Start(){
        _CatDialogue.GetText();
    }

    void Update(){
        // _CatDialogue.TMPWorkPlease();
        _CatDialogue.Talk();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        _CatDialogue.InTrigger(other);
    }

    public void OnTriggerExit2D(Collider2D other){
        _CatDialogue.OutTrigger(other);
    }
}