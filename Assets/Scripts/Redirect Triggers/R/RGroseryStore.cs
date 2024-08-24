using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGroseryStore : MonoBehaviour
{
    TriggerParent _RGroseryStore = new TriggerParent("Sweet Home", new Vector2(36f, -6f), new Vector2(25f, -6f));

    void Update(){
        _RGroseryStore.Redirect();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        _RGroseryStore.InTrigger(other);
    }

    public void OnTriggerExit2D(Collider2D other){
        _RGroseryStore.OutTrigger(other);
    }
}
