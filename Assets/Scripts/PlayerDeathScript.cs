using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField] private GameObject wastedText;
    [SerializeField] private GameObject blackBackground;

    bool dead = false;

    IEnumerator Fade()
    {
        Color c = blackBackground.GetComponent<Image>().color;

        for(float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        {
            c.a = alpha;
            blackBackground.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(.1f);
        }

        if (c.a >= 0.9f)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("KillPlayer"))
        {
            Debug.Log("Killing Player");
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        if(dead == false)
        {
            dead = true;
            wastedText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(Fade());
        }
    }

    private void Update()
    {
        if(transform.position.y < -100)
        {
            KillPlayer();
        }
    }
}
