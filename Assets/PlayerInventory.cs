using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int yarnCount = 0;
    public Text yarnText;

    private bool gameWon;
    private bool gameLost;

    private void Start()
    {
        gameWon = false;
        gameLost = false;
    }


    private void Update()
    {
        yarnText.text = "Yarn: " + yarnCount;

        if (yarnCount == 3)
        {
            gameWon = true;
            StartCoroutine(waiter());
            Debug.Log("Win!");
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.5f);
        if (gameWon)
            SceneManager.LoadScene(3);
        else if (gameLost)
            SceneManager.LoadScene(4);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yarn")
        {
            Debug.Log("Yarn");
            yarnCount += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            gameLost = true;
            StartCoroutine(waiter());
        }
    }
}
