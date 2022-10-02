using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Start()
    {
        instance = this;
    }

    public void SetTarget(GameObject obj)
    {
        CameraMovement.instance.SetTarget(obj.transform);
    }
}
