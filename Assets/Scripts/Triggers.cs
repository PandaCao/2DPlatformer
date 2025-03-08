using UnityEngine;

public enum Type {Respawn, Finish}

public class Triggers : MonoBehaviour
{
    public GameManager gameManager;
    
    public Type type = Type.Respawn;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (type == Type.Respawn && other.gameObject.CompareTag("Player"))
        {
            gameManager.SelectLevel(1);
        }
        else if (type == Type.Finish && other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameManager.finishPanel.SetActive(true);
        }
    }
}
