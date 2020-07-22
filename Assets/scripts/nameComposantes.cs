using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class nameComposantes : MonoBehaviour {

	public GameObject Confirm;
	public GameObject Next;
	public GameObject Correct;
	public GameObject Incorrect;

	public GameObject IdeaImage;
	public GameObject Help;
	public GameObject GoHomeAlert;

	public GameObject MusicOn;
    public GameObject MusicOff;

    public GameObject audio;

	private bool isPlay = true;

	public static int currentScene;

	public int[] Parts = {0, 1, 2, 3, 4, 5};
//    public static int[] FromClass = new int[6];
//    public static int index = 0;
	public static int n0, n1, n2, n3, n4, n5;

	//methode pour initialiser
	void Start()
	{
		currentScene = SceneManager.GetActiveScene().buildIndex;

		Shuffle(Parts);

		n0 = Parts[0];
        n1 = Parts[1];
        n2 = Parts[2];
        n3 = Parts[3];
        n4 = Parts[4];
        n5 = Parts[5];

		Correct.SetActive(false);
		Incorrect.SetActive(false);
		IdeaImage.SetActive(false);
		GoHomeAlert.SetActive(false);

        Reset();

		if (currentScene == 11)
        {
            Help.SetActive(true);
            Timer.pausedGame = true;
        }
        else 
        {
            Help.SetActive(false); 
            Timer.gameEnded = false;
        }

	}

	public void Update()
	{
		if (DragDrop1.locked && DragDrop2.locked && DragDrop3.locked && DragDrop4.locked && DragDrop5.locked && DragDrop6.locked)
		{
			Confirm.SetActive(true);
		}
	}

	public void nextLevel()
	{
        FindObjectOfType<SoundManager>().PlaySound("click");
		loadScene(currentScene + 1);
        Confirm.SetActive(false);
	}

	public void mainMenu()
	{
        FindObjectOfType<SoundManager>().PlaySound("click");
		loadScene(0);
	}

	public void loadScene (int sceneIndex)
    {
        StartCoroutine (loadAsync(sceneIndex));
    }

    IEnumerator loadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01 (operation.progress / .9f);
            yield return null;
        }
    } 

    public void AudioPause()
    {
        if (!Timer.pausedGame)
        {
            AudioListener.pause = true;     
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
        }   
    }

    public void AudioPlay()
    {
        if (!Timer.pausedGame)
        {
            AudioListener.pause = false;    
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
        }  
    }

    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }

    public void ShowIdea()
    {
        if (!Timer.pausedGame)
        {
            FindObjectOfType<SoundManager>().PlaySound("idea");
            IdeaImage.SetActive(true);
            Timer.pausedGame = true;            
        }
    }

    public void ShowHelp()
    {
        if (!Timer.pausedGame)
        {
            FindObjectOfType<SoundManager>().PlaySound("click");
        	Help.SetActive(true);
        	Timer.pausedGame = true;
        }
    }

    public void ShowHomeAlert()
    {
        if (!Timer.pausedGame)
        {
            FindObjectOfType<SoundManager>().PlaySound("click");
        	GoHomeAlert.SetActive(true);
        	Timer.pausedGame = true;
        }
    }

    public void CloseIdea()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        IdeaImage.SetActive(false);
        Timer.pausedGame = false;
    }

    public void CloseHelp()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Help.SetActive(false);
        Timer.pausedGame = false;
        Timer.gameEnded = false;
    }

    public void CloseHomeAlert()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	GoHomeAlert.SetActive(false);
    	Timer.pausedGame = false;
    }

    public void VerifyResult()
    {
        if (!Timer.pausedGame)
        {
        	Timer.pausedGame = true;
        	if (NameSlot1.GoodDrop && NameSlot2.GoodDrop && NameSlot3.GoodDrop && NameSlot4.GoodDrop && NameSlot5.GoodDrop && NameSlot6.GoodDrop)
            {
                FindObjectOfType<SoundManager>().PlaySound("correctanswer");
                Correct.SetActive(true);              
                Timer.gameEnded = true;
            } 
            else
            {
                FindObjectOfType<SoundManager>().PlaySound("incorrectanswer");
                Incorrect.SetActive(true);
            }
        }
    }

    public void InactiveCorrect()
    {
        Correct.SetActive(false);
        Next.SetActive(true);
        Timer.pausedGame = false;
    }

    public void InactiveIncorrect()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	Incorrect.SetActive(false);
        Reset();
    }
/*
    public void Cancel()
    {
          if (FromClass[index] == 1) {NameSlot1.empty = true; DragDrop1.locked = false; DragDrop1.rectTransform.anchoredPosition = DragDrop1.originalPosition1; DragDrop1.gotDragged = false; DragDrop1.correctPlace = false; DragDrop1.canvasGroup.blocksRaycasts = true; NameSlot1.GoodDrop = false; print("Class " + index + " has been reset!"); if (index > 0) index--;}
            if (FromClass[index] == 2) {NameSlot2.empty = true; DragDrop2.locked = false; DragDrop2.rectTransform.anchoredPosition = DragDrop2.originalPosition2; DragDrop2.gotDragged = false; DragDrop2.correctPlace = false; DragDrop2.canvasGroup.blocksRaycasts = true; NameSlot2.GoodDrop = false; print("Class " + index + " has been reset!"); if (index > 0) index--;}
            if (FromClass[index] == 3) {NameSlot3.empty = true; DragDrop3.locked = false; DragDrop3.rectTransform.anchoredPosition = DragDrop3.originalPosition3; DragDrop3.gotDragged = false; DragDrop3.correctPlace = false; DragDrop3.canvasGroup.blocksRaycasts = true; NameSlot3.GoodDrop = false; print("Class " + index + " has been reset!"); if (index > 0) index--;}
            if (FromClass[index] == 4) {NameSlot4.empty = true; DragDrop4.locked = false; DragDrop4.rectTransform.anchoredPosition = DragDrop4.originalPosition4; DragDrop4.gotDragged = false; DragDrop4.correctPlace = false; DragDrop4.canvasGroup.blocksRaycasts = true; NameSlot4.GoodDrop = false; print("Class " + index + " has been reset!"); if (index > 0) index--;}
            if (FromClass[index] == 5) {NameSlot5.empty = true; DragDrop5.locked = false; DragDrop5.rectTransform.anchoredPosition = DragDrop5.originalPosition5; DragDrop5.gotDragged = false; DragDrop5.correctPlace = false; DragDrop5.canvasGroup.blocksRaycasts = true; NameSlot5.GoodDrop = false; print("Class " + index + " has been reset!"); if (index > 0) index--;}
            if (FromClass[index] == 6) {NameSlot6.empty = true; DragDrop6.locked = false; DragDrop6.rectTransform.anchoredPosition = DragDrop6.originalPosition6; DragDrop6.gotDragged = false; DragDrop6.correctPlace = false; DragDrop6.canvasGroup.blocksRaycasts = true; NameSlot6.GoodDrop = false; print("Class " + index + " has been reset!"); if (index > 0) index--;}
     Reset();
    }
*/
    public void ResetWithSound()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Reset();
    }

    public void Reset()
    {
        Confirm.SetActive(false);
        NameSlot1.empty = true; DragDrop1.locked = false; DragDrop1.rectTransform.anchoredPosition = DragDrop1.originalPosition1; DragDrop1.gotDragged = false; DragDrop1.correctPlace = false; DragDrop1.canvasGroup.blocksRaycasts = true; NameSlot1.GoodDrop = false;
        NameSlot2.empty = true; DragDrop2.locked = false; DragDrop2.rectTransform.anchoredPosition = DragDrop2.originalPosition2; DragDrop2.gotDragged = false; DragDrop2.correctPlace = false; DragDrop2.canvasGroup.blocksRaycasts = true; NameSlot2.GoodDrop = false;
        NameSlot3.empty = true; DragDrop3.locked = false; DragDrop3.rectTransform.anchoredPosition = DragDrop3.originalPosition3; DragDrop3.gotDragged = false; DragDrop3.correctPlace = false; DragDrop3.canvasGroup.blocksRaycasts = true; NameSlot3.GoodDrop = false;
        NameSlot4.empty = true; DragDrop4.locked = false; DragDrop4.rectTransform.anchoredPosition = DragDrop4.originalPosition4; DragDrop4.gotDragged = false; DragDrop4.correctPlace = false; DragDrop4.canvasGroup.blocksRaycasts = true; NameSlot4.GoodDrop = false;
        NameSlot5.empty = true; DragDrop5.locked = false; DragDrop5.rectTransform.anchoredPosition = DragDrop5.originalPosition5; DragDrop5.gotDragged = false; DragDrop5.correctPlace = false; DragDrop5.canvasGroup.blocksRaycasts = true; NameSlot5.GoodDrop = false;
        NameSlot6.empty = true; DragDrop6.locked = false; DragDrop6.rectTransform.anchoredPosition = DragDrop6.originalPosition6; DragDrop6.gotDragged = false; DragDrop6.correctPlace = false; DragDrop6.canvasGroup.blocksRaycasts = true; NameSlot6.GoodDrop = false;
        Timer.pausedGame = false;
    }

}