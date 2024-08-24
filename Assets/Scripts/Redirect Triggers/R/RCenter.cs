using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCenter : MonoBehaviour
{
    TriggerParent _RCenter = new TriggerParent("Sweet Home", new Vector2(-12f, -7.2f), new Vector2(-12f, -6f));

    void Update(){
        _RCenter.Redirect();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        _RCenter.InTrigger(other);
    }

    public void OnTriggerExit2D(Collider2D other){
        _RCenter.OutTrigger(other);
    }
}
