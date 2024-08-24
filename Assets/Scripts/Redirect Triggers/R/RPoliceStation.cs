using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPoliceStation : MonoBehaviour
{
    TriggerParent _RPoliceStation = new TriggerParent("Sweet Home", new Vector2(-35.7f, -7.2f), new Vector2(-25.8f, -6f));

    void Update(){
        _RPoliceStation.Redirect();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        _RPoliceStation.InTrigger(other);
    }

    public void OnTriggerExit2D(Collider2D other){
        _RPoliceStation.OutTrigger(other);
    }
}
