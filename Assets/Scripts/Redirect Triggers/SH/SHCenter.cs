using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHCenter : MonoBehaviour
{
    TriggerParent _SHCenter = new TriggerParent("Road", new Vector2(13f, -6.5f), new Vector2(13f, -6.5f));

    void Update(){
        _SHCenter.Redirect();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        _SHCenter.InTrigger(other);
    }

    public void OnTriggerExit2D(Collider2D other){
        _SHCenter.OutTrigger(other);
    }
}

