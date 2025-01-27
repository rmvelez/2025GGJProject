using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public GameObject hubArea;
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;

    public GameObject bubbleOne;
    public GameObject bubbleTwo;
    public GameObject bubbleThree;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        bubbleTwo.SetActive(false);
        bubbleThree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "LevelOneWarp")
        {
            hubArea.SetActive(false);
            levelOne.SetActive(true);
            bubbleOne.SetActive(false);
            bubbleTwo.SetActive(true);
        }
        if (other.gameObject.name == "LevelTwoWarp")
        {
            hubArea.SetActive(false);
            levelTwo.SetActive(true);
            bubbleTwo.SetActive(false);
            bubbleThree.SetActive(true);
        }
        if (other.gameObject.name == "LevelThreeWarp")
        {
            hubArea.SetActive(false);
            levelThree.SetActive(true);
        }
        if (other.gameObject.name == "HubWarp")
        {
            hubArea.SetActive(true);
            levelOne.SetActive(false);
            levelTwo.SetActive(false);
        }
        if (other.gameObject.name == "WinWarp")
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    void OnColliderEnter(Collider other)
    {
        if (other.gameObject.name == "DeathTrigger")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
