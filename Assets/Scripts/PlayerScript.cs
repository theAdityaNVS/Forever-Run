using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody playerRigidBody;
    public Text scoreDisplay;
    public Text highScoreDisplay;
    public Text coinDisplay;
    public AudioSource enemyHit;
    public AudioSource coinHit;
    int coin = 0;
    float moveTime;
    int score = 0;
    int highScore;
    Vector3 startPos, endPos;

    private void OnTriggerEnter(Collider other) //Game Scence Changer
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemyHit.Play();
            SceneManager.LoadScene("GameOver");
        }
        if(other.gameObject.CompareTag("Coin"))
        {
            coin += 1;
            coinHit.Play();
            coinDisplay.text = coin + ": Coins ";
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
        coinDisplay.text = coin + ": Coins ";
        scoreDisplay.text = "  Score: " + score;
        highScoreDisplay.text = "  HighScore: " + PlayerPrefs.GetInt("HighScore",0);

    }
    
    IEnumerator WaitForPlayerMovement()
    {
        yield return new WaitForSeconds(4f);
        score++;
        scoreDisplay.text = "  Score: " + score;
        if(score>PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreDisplay.text = "  HighScore :" + score;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && playerRigidBody.velocity.y == 0)
        {
            playerRigidBody.velocity = new Vector3(0, 5f, 0);
            playerAnimator.SetTrigger("Jump");
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnimator.SetTrigger("Roll");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && this.transform.position.x == 0)
        {
            StartCoroutine(MoveRightLeft("Left"));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && this.transform.position.x == 3)
        {
            StartCoroutine(MoveRightLeft("Left"));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x == 0)
        {
            StartCoroutine(MoveRightLeft("Right"));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x == -3)
        {
            StartCoroutine(MoveRightLeft("Right"));
        }
    }
    void Update()
    {
        StartCoroutine(WaitForPlayerMovement());
    }
    IEnumerator MoveRightLeft(string whereToMove)
    {
        switch(whereToMove)
        {
            case "Right":
                moveTime = 0f;
                startPos = this.transform.position;
                endPos = new Vector3(this.transform.position.x + 3f, this.transform.position.y, this.transform.position.z);
                while(moveTime < 0.5f)
                {
                    moveTime += 0.02f;
                    this.transform.position = Vector3.Lerp(startPos, endPos, moveTime / 0.5f);
                    yield return null;
                }
                break;
            case "Left":
                moveTime = 0f;
                startPos = this.transform.position;
                endPos = new Vector3(this.transform.position.x - 3f, this.transform.position.y, this.transform.position.z);
                while (moveTime < 0.5f)
                {
                    moveTime += 0.02f;
                    this.transform.position = Vector3.Lerp(startPos, endPos, moveTime / 0.5f);
                    yield return null;
                }
                break;
        }
    }

}