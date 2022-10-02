using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private PanelController panel;

    private void OnMouseUp()
    {
        CameraMovement.instance.SetTarget(transform);
        panel.Show();
    }
}
