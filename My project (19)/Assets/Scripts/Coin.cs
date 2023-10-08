using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int score;
    public int maxScore;
    public TextMeshProUGUI scoreText;
    private PlayerController playerController;

    public Animator playerAnim;
    public GameObject thisPlayer;

    public Button restartButton;

    private float zamanSayaci = 0f;
    public float gecisSuresi = 10f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerAnim = thisPlayer.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("EndGame"))
        {
            playerController._speed = 0f;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            if (score >= maxScore)
            {
                playerAnim.SetBool("Win", true);
                StartCoroutine(RestartSceneAfterDelay(10f));
            }
            else
            {
                playerAnim.SetBool("Lose", true);
                StartCoroutine(RestartSceneAfterDelay(10f));
                restartButton.interactable = true;
                restartButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        zamanSayaci += Time.deltaTime;

        if (score >= 10 && zamanSayaci >= gecisSuresi)
        {
            SahneyiGec();
        }
    }
    public void SahneyiGec()
    {
        // Bir sonraki sahneye geç
        SceneManager.LoadScene(3);
    }

}
