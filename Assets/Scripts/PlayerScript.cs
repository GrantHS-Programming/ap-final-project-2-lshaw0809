using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float JumpForce;

    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D RB;

    private void Awake()
    {
        RB = getComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded = true)
            {

            }
        }
    }
}
