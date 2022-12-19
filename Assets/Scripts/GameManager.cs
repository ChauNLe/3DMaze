using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int level;
    public PlayerMove player;
    public TMP_Text scoreText;
    public TMP_Text currentLevel;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject gameReady;
    public GameObject Minimap;
    public GameObject Quit;
    public GameObject instruction;
    public GameObject pause;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        player = FindObjectOfType<PlayerMove>();
        instruction.SetActive(false);
        gameReady.SetActive(true);
        gameOver.SetActive(false);
        Minimap.SetActive(false);
        player.enabled = false;
        Quit.SetActive(false);
        FindObjectOfType<MazeLoader>().enabled = false;
        player.isGameOver = false;
        FindObjectOfType<Timer>().enabled = false;
        pause.SetActive(false);
        
        // Cursor.lockState = CursorLockMode.Confined;
    }

    public void Play() {
        score = 0;
        level = 1;
        scoreText.text = string.Concat("SCORE: ", score.ToString());
        currentLevel.text = string.Concat("LEVEL ", level.ToString());
        playButton.SetActive(false);
        instruction.SetActive(false);
        gameOver.SetActive(false);
        Minimap.SetActive(true);
        gameReady.SetActive(false);
        Quit.SetActive(true);
        player.enabled = true;
        player.isGameOver = false;
        FindObjectOfType<MazeLoader>().enabled = true;
        FindObjectOfType<Timer>().enabled = true;
        pause.SetActive(true);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        gameReady.SetActive(false);
        Quit.SetActive(false);
        player.isGameOver = true;
        FindObjectOfType<Timer>().enabled = false;
        pause.SetActive(false);
    }

    public void IncreaseLevel(){
        IncreaseScore();
        level++;
        currentLevel.text = string.Concat("LEVEL ", level.ToString());
        FindObjectOfType<MazeLoader>().enabled = false;
        player.enabled = false;
        FindObjectOfType<MazeLoader>().mazeRows += level%2;
        FindObjectOfType<MazeLoader>().mazeColumns += 1 - level%2;
        player.enabled = true;
        FindObjectOfType<MazeLoader>().enabled = true;
        FindObjectOfType<Timer>().timeRemaining = 90 + 10*(level-1);
        
    }

    public void IncreaseScore(){
        score+= 50 + 10*level;
        scoreText.text = string.Concat("SCORE: ", score.ToString());
    }

    public void Pause()
    {
        FindObjectOfType<Timer>().timerIsRunning = false;
        pause.SetActive(false);
    }

    public void Resume()
    {
        FindObjectOfType<Timer>().timerIsRunning = true;
        instruction.SetActive(false);
        if (level>0)
        {
            pause.SetActive(true);
        }
    }

    public void showInstruction(){
        instruction.SetActive(true);
        pause.SetActive(false);
        Pause();
    }
    void Update()
    {
        if (Input.GetKey("q"))
        {
            GameOver();
        }
        if (Input.GetKeyDown("return"))
        {
            Play();
        }
        if (Input.GetKeyDown("r"))
        {
            Resume();
        }
        if (Input.GetKey("p"))
        {
            Pause();
        }
        if (Input.GetKey("i"))
        {
            showInstruction();
        }
    }

}
