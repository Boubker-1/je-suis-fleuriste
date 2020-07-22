using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FadeOut : MonoBehaviour
{
    public Animator transition;

    public void ToNextLevel()
    {
    		FindObjectOfType<SoundManager>().PlaySound("click");
            StoreScore();
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ToMainMenu()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        StartCoroutine(LoadScene(0));
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

    void StoreScore()
    {
            if (SceneManager.GetActiveScene().buildIndex == 3) PlayerPrefs.SetInt("Flower1Attempt1", GameControl.attempt);
            if (SceneManager.GetActiveScene().buildIndex == 4) PlayerPrefs.SetInt("Flower1Attempt2", GameControl.attempt);
            if (SceneManager.GetActiveScene().buildIndex == 5) PlayerPrefs.SetInt("Flower1Attempt3", GameControl.attempt);
            if (SceneManager.GetActiveScene().buildIndex == 7) {PlayerPrefs.SetFloat("Composante1Time1", Timer.currentTime); Timer.currentTime = 0;}
            if (SceneManager.GetActiveScene().buildIndex == 8) {PlayerPrefs.SetFloat("Composante1Time2", Timer.currentTime); Timer.currentTime = 0;}
            if (SceneManager.GetActiveScene().buildIndex == 9) {PlayerPrefs.SetFloat("Composante1Time3", Timer.currentTime); Timer.currentTime = 0;}
            if (SceneManager.GetActiveScene().buildIndex == 11) {PlayerPrefs.SetFloat("Composante2Time1", Timer.currentTime); Timer.currentTime = 0;}
            if (SceneManager.GetActiveScene().buildIndex == 12) {PlayerPrefs.SetFloat("Composante2Time2", Timer.currentTime); Timer.currentTime = 0;}
            if (SceneManager.GetActiveScene().buildIndex == 13) {PlayerPrefs.SetFloat("Composante2Time3", Timer.currentTime); Timer.currentTime = 0;}
    }
}
