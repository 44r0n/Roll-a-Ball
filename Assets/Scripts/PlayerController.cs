using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    private int count;
    public Text CountText;
    public Text WinText;

    //Is called in the fist frame of the game.
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = string.Empty;
    }

    //Is called before rendering a frame -> Where game code will go
	void Update()
    {

    }

    //Is called before performing physics calculations
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveHorizontal, 0.0F, MoveVertical);

        rb.AddForce(movement * Speed); 
    }

    //Is called when the playercontroller first touches the Collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            WinText.text = "You WIN!!!";
        }
    }
}
