using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Composante1 : MonoBehaviour {

	[SerializeField]
	private GameObject win1;
	[SerializeField]
	private GameObject win2;
	[SerializeField]
	private GameObject win3;

	[SerializeField]
	private GameObject composantName1;
	[SerializeField]
	private GameObject composantName2;
	[SerializeField]
	private GameObject composantName3;

	public GameObject Confirm;
	public GameObject again;
	public GameObject Correct;
	public GameObject Incorrect;

	public GameObject IdeaImage;
	public GameObject Help;
	public GameObject GoHomeAlert;

	public GameObject MusicOn;
    public GameObject MusicOff;

    public GameObject audio;

	private bool isPlay = true;
    private bool ConfirmActive = true;

	public static int currentScene;

	public static int[] Parts1 = {0, 1, 2, 3, 4, 5};
    public static int[] Parts2 = {6, 7, 8, 9, 10, 11};
    public static int[] Parts3 = {12, 13, 14, 15, 16, 17};
	public static int[] CorrectPlace1 = new int[3];
    public static int[] CorrectPlace2 = new int[3];
    public static int[] CorrectPlace3 = new int[3];
	public static int n0, n1, n2, n3, n4, n5, n6, n7, n8;
    public static int c0, c1, c2, c3, c4, c5, c6, c7, c8;
	public static bool TryAgain;

	//methode pour initialiser
	void Start()
	{
		currentScene = SceneManager.GetActiveScene().buildIndex;

		Shuffle(Parts1); Shuffle(Parts2); Shuffle(Parts3);

		n0 = Parts1[0]; n1 = Parts1[1]; n2 = Parts1[2];
        n3 = Parts2[0]; n4 = Parts2[1]; n5 = Parts2[2];
        n6 = Parts3[0]; n7 = Parts3[1]; n8 = Parts3[2];

		CorrectPlace1[0] = n0; CorrectPlace1[1] = n1; CorrectPlace1[2] = n2;
        CorrectPlace2[0] = n3; CorrectPlace2[1] = n4; CorrectPlace2[2] = n5;
        CorrectPlace3[0] = n6; CorrectPlace3[1] = n7; CorrectPlace3[2] = n8;

		Shuffle(CorrectPlace1); Shuffle(CorrectPlace2); Shuffle(CorrectPlace3);

		c0 = CorrectPlace1[0]; c1 = CorrectPlace1[1]; c2 = CorrectPlace1[2];
        c3 = CorrectPlace2[0]; c4 = CorrectPlace2[1]; c5 = CorrectPlace2[2];
        c6 = CorrectPlace3[0]; c7 = CorrectPlace3[1]; c8 = CorrectPlace3[2];

		win1.SetActive(false);
		win2.SetActive(false);
		win3.SetActive(false);

		composantName1.SetActive(false);
		composantName2.SetActive(false);
		composantName3.SetActive(false);
		Correct.SetActive(false);
		Incorrect.SetActive(false);
		again.SetActive(false);
		IdeaImage.SetActive(false);
		GoHomeAlert.SetActive(false);

		if (currentScene == 7) Help.SetActive(true);
        else 
        {
            Help.SetActive(false); 
            Timer.gameEnded = false;
            Reset();
        }
	}

	public void Update()
	{
		if (DragDrop1.locked && DragDrop2.locked && DragDrop3.locked && ConfirmActive)
		{
			Confirm.SetActive(true);
		}
        else Confirm.SetActive(false);
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
        	if (PartSlot1.GoodDrop && PartSlot2.GoodDrop && PartSlot3.GoodDrop)
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

    public void InactiveCorrect(){
        ConfirmActive = false;
        Correct.SetActive(false);
        Timer.pausedGame = false;
    }

    public void InactiveIncorrect()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	Incorrect.SetActive(false);
        Reset();
    }

    public void Reset()
    {
        Confirm.SetActive(false);
        PartSlot1.empty = true; DragDrop1.locked = false; DragDrop1.rectTransform.anchoredPosition = DragDrop1.originalPosition1; DragDrop1.gotDragged = false; DragDrop1.correctPlace = false; DragDrop1.canvasGroup.blocksRaycasts = true; PartSlot1.GoodDrop = false;
        PartSlot2.empty = true; DragDrop2.locked = false; DragDrop2.rectTransform.anchoredPosition = DragDrop2.originalPosition2; DragDrop2.gotDragged = false; DragDrop2.correctPlace = false; DragDrop2.canvasGroup.blocksRaycasts = true; PartSlot2.GoodDrop = false;
        PartSlot3.empty = true; DragDrop3.locked = false; DragDrop3.rectTransform.anchoredPosition = DragDrop3.originalPosition3; DragDrop3.gotDragged = false; DragDrop3.correctPlace = false; DragDrop3.canvasGroup.blocksRaycasts = true; PartSlot3.GoodDrop = false;
        Timer.pausedGame = false;
    }
}