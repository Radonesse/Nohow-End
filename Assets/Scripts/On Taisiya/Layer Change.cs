using UnityEngine;

public class LayerChange : MonoBehaviour
{
    void Update()
    {
        GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -100);
    }
}
