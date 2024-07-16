using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGround { get; private set; }
    private CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || (collision.gameObject.CompareTag("GroundAttachAble")))
        {
            isGround = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")||(collision.gameObject.CompareTag("GroundAttachAble")))
        {
            isGround = false;
        }
    }
}
