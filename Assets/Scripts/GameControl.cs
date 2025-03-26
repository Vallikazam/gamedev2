using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject winText; 

    [SerializeField]
    private Image darkOverlay; 

    [SerializeField]
    private GameObject restartButton; 

    [SerializeField]
    private Tiger tiger; 
    [SerializeField]
    private Panda panda;   
    [SerializeField]
    private Deer deer; 
    [SerializeField]
    private Turkey turkey; 

    private bool hasWon = false; 

    void Start()
    {
        winText.SetActive(false); 
        restartButton.SetActive(false); 
        darkOverlay.color = new Color(darkOverlay.color.r, darkOverlay.color.g, darkOverlay.color.b, 0f); 
    }

    void Update()
    {
        if (!hasWon && Tiger.locked && Panda.locked && Deer.locked && Turkey.locked)
        {
            hasWon = true;
            StartCoroutine(ShowWinScreen()); 
        }
    }

    private IEnumerator ShowWinScreen()
    {
        float fadeDuration = 1f; 
        float elapsedTime = 0f;
        Color startColor = darkOverlay.color; 
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0.8f); 

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            darkOverlay.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration); 
            yield return null;
        }

        winText.SetActive(true);
        restartButton.SetActive(true);
    }
    public void RestartGame()
{
    if (tiger != null) Tiger.locked = false;
    if (panda != null) Panda.locked = false;
    if (deer != null) Deer.locked = false;
    if (turkey != null) Turkey.locked = false;

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
}
}