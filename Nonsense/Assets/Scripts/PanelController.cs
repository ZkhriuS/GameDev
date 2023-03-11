using UnityEngine;
using DG.Tweening;

public class PanelController : MonoBehaviour
{
    private enum ShowSide { Left, Right, Up, Down }

    [SerializeField]
    private ShowSide showSide;

    private RectTransform rectTransfrom;

    private bool isShowed = false;
    private void Start()
    {
        rectTransfrom = GetComponent<RectTransform>();
    }

    public void Show()
    {
        if (isShowed) return;

        isShowed = true;
        transform.DOMove(rectTransfrom.position + SideToVector(showSide), 0.5f);;
    }
    public void Hide()
    {
        if (!isShowed) return;

        isShowed = false;
        transform.DOMove(rectTransfrom.position - SideToVector(showSide), 0.5f);
    }

    private Vector3 SideToVector(ShowSide side)
    {
        switch (side)
        {
            case ShowSide.Left:  return Vector3.left * rectTransfrom.rect.width;
            case ShowSide.Right: return Vector3.right * rectTransfrom.rect.width;
            case ShowSide.Up:    return Vector3.up * rectTransfrom.rect.height;
            case ShowSide.Down:  return Vector3.down * rectTransfrom.rect.height;
            default:             return Vector3.zero;
        }
    }
}
