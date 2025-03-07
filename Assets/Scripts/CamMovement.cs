using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _offset;
    private float _smoothTime;
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private Transform player;
    
    private void Start()
    {
        _smoothTime = 0.1f;
        _offset = new Vector3(0f, 2f, -10f);
    }
    
    private void Update()
    {
        Vector3 desiredPosition = player.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity,  _smoothTime);
    }
}
