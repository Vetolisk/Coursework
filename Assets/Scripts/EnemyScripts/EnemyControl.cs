using System;
using UnityEngine;
using System.Collections;
public class EnemyControl : MonoBehaviour
{
   
    public bool isFlipped = false;
    public GameObject DethEffect;
    [SerializeField]
    public  int health;
    public  int startHealth;
    public float startTimeBtwAttack;
    public float speed;
    //private Transform target;
    Rigidbody2D rb;
    private float stopTime;
    public float startStopTime;
    public float normalspeed;
    private Animator anim;
    private PlayerControll player;
    public ParticleSystem particle;
    public int damage;
    public Vector2 newPos;
    public float offset;
    public  float PlusToDeadScore;
    public  static bool FlagEnemyDead;
    public GameObject Knife;
    public HealthBar healthBar;
    public int currentHealth;
    public static float Score; // убрать static
    void Start()
    {
        
        player = FindObjectOfType<PlayerControll>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        normalspeed = speed;
        currentHealth = health;
        healthBar.SetMaxHealth(health);

    }
    
    public void LookAtPlayer()
    {

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (player.isActiveAndEnabled)
        {
            if (transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
    }
    

    private void Update()
    {   
        if (FlagEnemyDead)
        {
            SetScore();
        }
        
       
        LookAtPlayer();
    }
    private void FixedUpdate()
    {
        // потом условие заменить 
        if (player.isActiveAndEnabled)
        {
            Vector2 target = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y);

            newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            offset = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, rb.position);
            rb.MovePosition(newPos);

        }
    }
    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        Instantiate(DethEffect, transform.position, Quaternion.identity);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(Knife);
            anim.SetTrigger("DeadEnemy");
            Invoke("AnimDead", 0.5f);
            FlagEnemyDead = true;
          
        }
    }
   
    public void SetScore() //перезаписать Результаты
    {

        PlayerControll.Scorem += PlusToDeadScore;
        FlagEnemyDead = false;
        
        
    }
 
    
    public void AnimDead()
    {
        
        Destroy(gameObject);
    }
    
   

}
