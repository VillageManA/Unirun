using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance = null;
    /*
     
    1.GameOver �����Ǵ�
    2.Text Ȱ��ȭ �κ� ��������.
    3. Score ��굵 ���⼭ �ؾ��� 
     
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
            Debug.Log("�̹� ���ӸŴ����� �����մϴ�. �׷��� ���� ������ ���ϰڴ�");
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
