using TMPro;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public int appleCount;
    public TMP_Text appleText;
    public GameObject door;
    private bool _doorDestroyed;
    
    private void Update()
    {
        appleText.text = ": " + appleCount;

        if (appleCount == 4 && !_doorDestroyed)
        {
            _doorDestroyed = true;
            Destroy(door);
        }
    }
}
