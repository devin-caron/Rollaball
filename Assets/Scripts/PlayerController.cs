using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private bool won = false;
    private TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    public Canvas winCanvas;
    private GameObject portalWall;
    private GameObject portal;
    Timer time;

    public Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        countText = GameObject.Find("CountText").GetComponent<TextMeshProUGUI>();
        time = GameObject.FindGameObjectWithTag("timeTag").GetComponent<Timer>();

        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count == 10)
        {
            portalWall = GameObject.Find("Portal Wall");
            portalWall.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && won == true)
        {
            won = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundManagerScript.PlaySound("coin");

            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
        else if (other.gameObject.CompareTag("Portal"))
        {
            SoundManagerScript.PlaySound("portal");
        }
        else if (other.gameObject.CompareTag("checkpoint"))
        {
            SoundManagerScript.PlaySound("checkpoint");
        }
        else if (other.gameObject.CompareTag("Win"))
        {
            won = true;
            string timeRecord = time.GetTime();
            SoundManagerScript.PlaySound("clapping");
            winCanvas.gameObject.SetActive(true);
            winText.text = "You Win!\nTime: " + timeRecord + "\nScore: " + count;
        }
    }
}
