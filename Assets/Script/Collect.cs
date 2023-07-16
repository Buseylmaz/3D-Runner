using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class Collect : MonoBehaviour
{

    [SerializeField] int score;

    public TextMeshProUGUI scoreText;
    public Animator playerAnim;
    public GameObject player;

    public GameObject finishPanel;

    public OyuncuKontrol oyuncuKontrol;


    void Start()
    {
        playerAnim=player.GetComponentInChildren<Animator>();
    }


    /// <summary>
    /// Flower ad�nda tagla temas edince objeyi yok ediyoruz.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flower"))
        {
            AddFlower();
            //Debug.Log("Flower");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Finish"))
        {
            //biti� �izgisine gelince ko�may� durdurduk
            oyuncuKontrol.playerSpeed = 0;

            //Y�z� bize d�n�k olmas� i�in transfrom de�erine eri�tik
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self); //space.self kendi etraf�nda d�nd�rmek

            finishPanel.SetActive(true);

            if (score >= 8)
            {
                //Debug.Log("Mutlu");
                playerAnim.SetBool("Dance", true);
            }
            else
            {
                //Debug.Log("�zg�n");
                playerAnim.SetBool("Sad", true);
            }

            
            

        }

        else if (other.CompareTag("Cactus"))
        {
            if (score > 0)
            {
                MinusCactus();
            }
            else
            {
                ConstScore();
            }
            
            Destroy(other.gameObject);

        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Engele �arpt�");
            SceneManager.LoadScene(0);
        }
        
    }


    public void AddFlower()
    {
        score += 1;
        scoreText.text = "Skor: " + score.ToString();
    }


    public void MinusCactus()
    {
        score -= 1;
        scoreText.text = "Skor: " + score.ToString();
    }

    public void ConstScore()
    {
        scoreText.text = "Skor: " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
