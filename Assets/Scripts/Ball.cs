using UnityEngine;
using System.Collections;
using TMPro;

public class Ball : MonoBehaviour
{
    AudioManager audioManager;
    public int winningScore = 5;
    public int player1score = 0;
    public int player2score = 0;

    public TMP_Text Player1Scoretext;
    public TMP_Text Player2Scoretext;
    public TMP_Text WinText;

    public float speed = 5f;
    private Rigidbody2D rb;
    public float speedIncreaseRate = 0.5f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

void Update()
{
    speed += speedIncreaseRate * Time.deltaTime;
    rb.velocity = rb.velocity.normalized * speed;
}


    void LaunchBall()
    {
        speed = 5f;
        int xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        int yDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(xDirection, yDirection).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal1"))
        {
            audioManager.PlaySfx(audioManager.Score);
            player2score++;
            Player2Scoretext.text = player2score.ToString();
            CheckWinCondition();
            Respawn();
        }
        else if (collision.CompareTag("Goal2"))
        {
            audioManager.PlaySfx(audioManager.Score);
            player1score++;
            Player1Scoretext.text = player1score.ToString();
            CheckWinCondition();
            Respawn();
        }
            else if (collision.CompareTag("PowerUp"))
        {
            audioManager.PlaySfx(audioManager.Score);
            speed += 10f;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySfx(audioManager.Bounce);
        }
    }

    void Respawn()
    {
        transform.position = Vector3.zero;
        LaunchBall();
    }

    void CheckWinCondition()
    {
        if (player1score >= winningScore)
        {
            ShowWinText("Player 1 Wins!\nGame Over! Press R to restart or ESC to quit.");
        }
        else if (player2score >= winningScore)
        {
            ShowWinText("Player 2 Wins!\nGame Over! Press R to restart or ESC to quit.");
        }
    }

    void ShowWinText(string message)
    {
        WinText.text = message;
        WinText.gameObject.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(WaitForRestartOrQuit());
    }

    IEnumerator WaitForRestartOrQuit()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Restarting game...");
                Time.timeScale = 1;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                yield break;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Quitting game...");
                Application.Quit();
                yield break;
            }
            yield return null;
        }
    }
}