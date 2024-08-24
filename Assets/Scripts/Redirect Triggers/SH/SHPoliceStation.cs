using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHPoliceStation : MonoBehaviour
{
    TriggerParent _SHPoliceStation = new TriggerParent("Road", new Vector2(36.4f, -6.5f), new Vector2(26f, -6.5f));

    void Update(){
        _SHPoliceStation.Redirect();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        _SHPoliceStation.InTrigger(other);
    }

    public void OnTriggerExit2D(Collider2D other){
        _SHPoliceStation.OutTrigger(other);
    }
}
