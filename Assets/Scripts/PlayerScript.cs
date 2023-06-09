using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float JumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;
    bool dble = false;
    bool keyUp = false;

    Rigidbody2D RB;

    public Text ScoreTxt;

    private void Awake()
    {
        RB =  GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            dble = true;
            keyUp = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            keyUp = true;
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == false && dble == true && keyUp == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                dble = false;
                keyUp = false;
            }
        }
        

        if(isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE: " + score.ToString("f");
        }
    }

    private int doubleJump()
    {
        int count = 0;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            count++;
        }
        if (isGrounded == true)
        {
            count = 0;
        }
        return count;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
}
