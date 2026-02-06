using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log("Key K pressed");
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Key K pressed");
            animator.SetBool("isWalking", true);
        }
        if(!Input.GetKeyUp(KeyCode.K))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
