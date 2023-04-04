using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public AudioClip deathclip;
    private int jump_count = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    [SerializeField] private float jump_Force = 700f;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource audio;
    

    // Start is called before the first frame update
    void Start()
    {
        //초기화
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        audio = transform.GetComponent<AudioSource>();
        
        //460p
    }

    // Update is called once per frame
    void Update()
    {
        /*
        1. 사용자의 입력을 감지하고 점프처리를 해야함
        2. 점프카운트 2번까지 사용할수있게 
        3. player가 죽으면 더이상 실행이 안되도록 해야한다
         
         */

        if (isDead)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0)&& jump_count<2)
        {
            jump_count++;
            //점프직전의 속도를 순간적으로 0으로 변경
            playerRigidbody.velocity = Vector2.zero;
            //플레이어 리지드바디에 위쪽으로 힘주기
            playerRigidbody.AddForce(new Vector2(0, jump_Force));
            //점프할때 소리 만들어줬어용
            audio.Play();
        }
        
        //마우스 왼쪽 버튼을 떼고, 속도의 y값이 양수이면 -> 위로 상승중 이라면
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y >0)
        {
            //현재의 속도를 절반으로 줄여주세용
            playerRigidbody.velocity = playerRigidbody.velocity *0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
    }
    private void Die()
    {
        //사망처리
        animator.SetTrigger("Die");

        //audio source에 하당된 오디오 클립을 deathclip으로 변경
        audio.clip = deathclip;
        audio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
        GameManger.Instance.PlayerDead();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //바닥에 닿았음을 감지하는 처리
        //어떠한 콜라이더가 닿았으며 , 충돌표면이 위쪽을 보고 있다면?
        if (collision.contacts[0].normal.y > 0.7f)
        {
            //땅에 닿았음을 초기화하는 bool값
            isGrounded = true;
            //바닥에 닿았으면 점프카운트를 초기화
            jump_count = 0;
        }
        

    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
