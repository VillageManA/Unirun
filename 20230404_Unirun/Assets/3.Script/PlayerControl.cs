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
        //�ʱ�ȭ
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        audio = transform.GetComponent<AudioSource>();
        
        //460p
    }

    // Update is called once per frame
    void Update()
    {
        /*
        1. ������� �Է��� �����ϰ� ����ó���� �ؾ���
        2. ����ī��Ʈ 2������ ����Ҽ��ְ� 
        3. player�� ������ ���̻� ������ �ȵǵ��� �ؾ��Ѵ�
         
         */

        if (isDead)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0)&& jump_count<2)
        {
            jump_count++;
            //���������� �ӵ��� ���������� 0���� ����
            playerRigidbody.velocity = Vector2.zero;
            //�÷��̾� ������ٵ� �������� ���ֱ�
            playerRigidbody.AddForce(new Vector2(0, jump_Force));
            //�����Ҷ� �Ҹ� ���������
            audio.Play();
        }
        
        //���콺 ���� ��ư�� ����, �ӵ��� y���� ����̸� -> ���� ����� �̶��
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y >0)
        {
            //������ �ӵ��� �������� �ٿ��ּ���
            playerRigidbody.velocity = playerRigidbody.velocity *0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
    }
    private void Die()
    {
        //���ó��
        animator.SetTrigger("Die");

        //audio source�� �ϴ�� ����� Ŭ���� deathclip���� ����
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
        //�ٴڿ� ������� �����ϴ� ó��
        //��� �ݶ��̴��� ������� , �浹ǥ���� ������ ���� �ִٸ�?
        if (collision.contacts[0].normal.y > 0.7f)
        {
            //���� ������� �ʱ�ȭ�ϴ� bool��
            isGrounded = true;
            //�ٴڿ� ������� ����ī��Ʈ�� �ʱ�ȭ
            jump_count = 0;
        }
        

    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
