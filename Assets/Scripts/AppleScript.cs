using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private AudioSource _audioSource;
    private CircleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _collider =  GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _audioSource.Play();
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }
    }
}
