using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] float yPaddlerOffset = 0.4f;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip paddleBounceClip;
    [SerializeField] AudioClip blockCollisionClip;
    [SerializeField] float randomFactor = 0.2f;
    
    //cached reference
    GameObject paddler;
    Rigidbody2D ballBody;
    AudioSource audioSource;

    //object variables
    private bool isFree;


    void Start()
    {
        isFree = false;
        paddler = GameObject.Find("Paddler");
        ballBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        LockBallOnPaddler();
    }

    void Update()
    {
        if (!isFree)
        {
            LockBallOnPaddler();
            LaunchOnMouseClick();
        }    
    }

    private void LockBallOnPaddler()
    {
        Vector2 paddlerPos = new Vector2(paddler.transform.position.x, paddler.transform.position.y);
        paddlerPos.y += yPaddlerOffset;
        transform.position = paddlerPos;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballBody.velocity = new Vector2(xPush, yPush);
            isFree = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFree)
        {
            float randomAngle = Random.Range(-randomFactor, randomFactor);
            ballBody.velocity = Quaternion.Euler(0, 0, randomAngle) * ballBody.velocity;

            if (collision.collider.name == "Paddler")
            {
                audioSource.PlayOneShot(paddleBounceClip);
            }
            else
            {
                audioSource.PlayOneShot(blockCollisionClip);
            }
        }
    }
}
