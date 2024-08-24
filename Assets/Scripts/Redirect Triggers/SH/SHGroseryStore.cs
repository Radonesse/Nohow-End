using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHGroseryStore : MonoBehaviour
{
    TriggerParent _SHGroseryStore = new TriggerParent("Road", new Vector2(-36.4f, -6.5f), new Vector2(-28.13f, -6.26f));

    void Update(){
        _SHGroseryStore.Redirect();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        _SHGroseryStore.InTrigger(other);
    }

    public void OnTriggerExit2D(Collider2D other){
        _SHGroseryStore.OutTrigger(other);
    }
}
