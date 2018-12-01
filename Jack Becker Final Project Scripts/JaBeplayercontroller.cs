using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaBeplayercontroller : MonoBehaviour {

    private int count;
    private float timer;
    private float GameLoader;
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    public Text endText;
    private float gameOn;
    public Text countText;

    
    // Use this for initialization
    void Start () {
        timer = 0;
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));
        }
        

    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            endText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
