using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance = null;
    /*
     
    1.GameOver 여부판단
    2.Text 활성화 부분 만들어야함.
    3. Score 계산도 여기서 해야함 
     
     */
    public bool isGameOver = false;
    public Text ScoreText;
    public GameObject gamover_UI;
    public int Score = 0;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("이미 게임매니저는 존재합니다. 그래서 나는 죽음을 택하겠다");
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameOver&&Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Stay1");
            
        }
        if (Score >= 10)
        {
            SceneManager.LoadScene("Stay2");
        }
    }
    public void AddScore(int score)
    {
        if(!isGameOver)
        {
            Score += score;
            ScoreText.text = "Score : " + Score;
        }
    }
    public void PlayerDead()
    {
        isGameOver = true;
        gamover_UI.SetActive(true);
        
    }
}
