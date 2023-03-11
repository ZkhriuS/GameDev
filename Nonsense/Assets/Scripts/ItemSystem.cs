using UnityEngine;

public class ItemSystem : MonoBehaviour
{


    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition) + new Vector3(0, 1, 0);
    }
}
