using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    private Camera m_Camera;

    [SerializeField]
    [Range(1, 50)]
    private float dragSpeed;

    [SerializeField]
    [Range(1, 50)]
    private float targetDistance;

    private bool hasTarget = false;

    private Vector3 startPosition;
    private Vector3 dragOrigin;

    private void Start()
    {
        instance = this; 
        startPosition = transform.position;

        m_Camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (hasTarget) return;

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = m_Camera.ScreenToViewportPoint(Input.mousePosition);
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dragDifference = dragOrigin - m_Camera.ScreenToViewportPoint(Input.mousePosition);
            dragDifference.z = dragDifference.y;
            dragDifference.y = 0;

            transform.position = startPosition + dragDifference * dragSpeed;
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            startPosition = transform.position;
            return;
        }
    }

    public void SetTarget(Transform targetTransform)
    {
        if (targetTransform.Equals(transform))
        {
            transform.DOMove(startPosition, 0.33f).SetEase(Ease.OutSine).OnComplete(() => hasTarget = false);
            return;
        }

        Vector3 targetPosition = targetTransform.position;

        Vector3 distanceToTarget = transform.forward * targetDistance;
        
        transform.DOMove(targetPosition - distanceToTarget, 0.33f).SetEase(Ease.OutSine).OnComplete(() => hasTarget = true);
    }

}
