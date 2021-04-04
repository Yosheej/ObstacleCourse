using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 800.0f;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] TextMeshProUGUI countText;

    bool controlsDisabled = false;
    float score;
   

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(!controlsDisabled)
        {
            PlayerMovement();
        }
    }
    
    void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag){

            case "Friendly":
                break;

            default:
                Invoke("ReloadScene", 2f);
                deathParticles.Play();
                controlsDisabled = true;
                break;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            
            countText.text = "Score: " + score.ToString();

            if(score >= 15)
            {
                Invoke("LoadWinScene", 2f);
            }
        }
    }

    void ReloadScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
    void LoadWinScene()
    {

        SceneManager.LoadScene(1);

    }
}