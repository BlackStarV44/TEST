using UnityEngine;

public class Background : MonoBehaviour
{
    private float backgroundSp = 0.4f;
    
    private Vector2 backgroundPosition;


    private void Update()
    {
        backgroundPosition = transform.position;
        backgroundPosition.y -= backgroundSp * Time.deltaTime;
        transform.position = backgroundPosition;

    }
}
