using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;


    AudioSource audioSource;
    [SerializeField] AudioClip pauseGameClip;
    [SerializeField] AudioClip resumeGameClip;
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
        audioSource = GetComponent<AudioSource>();
        /*        Debug.Log("TimeToEnd: " + timeToEnd + "s");*/
        Debug.Log($"Time: {timeToEnd} s");
        InvokeRepeating("Stopper", 2, 1);
    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
            EndGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PlayClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PauseGame()
    {
        PlayClip(pauseGameClip);
        Debug.LogWarning("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;

    }

    public void ResumeGame()
    {
        PlayClip(resumeGameClip);
        Debug.LogWarning("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            PlayClip(winClip);
            Debug.Log("You win! Reload?");
        }

        else
        {
            PlayClip(loseClip);
            Debug.Log("You lose! Reload?");
        }

    }
    public void AddPoints(int point)
    {
        points += point;
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void SubstractTime(int time)
    {
        timeToEnd -= time;
    }
    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);

    }
    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Red:
                redKey++;
                break;
            case KeyColor.Green:
                greenKey++;
                break;
            case KeyColor.Gold:
                goldKey++;
                break;
        }
    }

}
