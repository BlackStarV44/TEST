using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator explosionAnimator;





    private void Start()
    {
        explosionAnimator = GetComponent<Animator>();
    }



    void Update()
    {
        if (explosionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >=1)
        {
            Destroy(gameObject);
        }
    }
}
