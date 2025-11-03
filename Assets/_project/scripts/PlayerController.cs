using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gameOverText;
    public float forwardspeed = 5f;
    public float movespeed = 3f;
    public float jump = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    private bool isGameOver = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isGameOver)
        {
            transform.Translate(Vector3.forward * forwardspeed * Time.deltaTime);

            float moveX = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * moveX * movespeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (gameOverText != null)
                gameOverText.gameObject.SetActive(true);

            forwardspeed = 0f;
            movespeed = 0f;

            GetComponent<MeshRenderer>().enabled = false;

            isGameOver = true; 
        }
    }

    public void CollectCoin()
    {
        coinCount++;

        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
