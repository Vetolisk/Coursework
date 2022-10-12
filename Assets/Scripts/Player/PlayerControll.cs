using UnityEngine;
using TMPro;
using YG;
public class PlayerControll : MonoBehaviour
{
    public Joystick joystick;
    [Header("��������� ��������")]
    //��������
    public Animator anim;
    //�������
    //public Joystick joystick;
    //��� ����
    public Rigidbody2D m_Rigidbody2D;
    //������ ������������
    Vector2 movement;

    public Vector2 lastMotionVector;
    //bool ���� �� ��������
    public bool moving;
    // ���������� �����
 
    public int currentHealth;
    // ����������� �����
    public  int health;
    //��������
    public float runSpeed = 5f;
    //����� �����
    public HealthBar healthBar;
    //bool ���
    public bool live = true;
    //����
    public WinMenu winMenu;
    //���������� �������
    public TMP_Text myText;
    // ������
    public static float Scorem;
    //bool ���
    public bool flagShield=true;
    //����� ������
    private AudioSource audioSource;


    void Start(){
        Scorem = 0;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();      
        currentHealth = health;
        healthBar.SetMaxHealth(health);
        audioSource = GetComponent<AudioSource>();
    }
    // ��������� ��� 
    public void TakeDamage(int damage)
    {
        if (gameObject!=null) {
            audioSource.Play();
        }
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
 
    public void UpdateScoreDisplay() //������������ ����������
    {         
        myText.text = "Score: " + Scorem;  
    }

    public void ShieldUp()
    {
        AttackEnemy.flagFamagPlayer = false;
        flagShield = true;
        anim.SetBool("BShieldDown", flagShield);
        //anim.SetTrigger("ShieldUp");

    }
    public void ShieldDown()
    {
        AttackEnemy.flagFamagPlayer = true;
        flagShield = false;
        //Debug.Log(flagShield);
        anim.SetBool("BShieldDown", flagShield);
       
    }

    void Update()
    {
        if (ApplicationPlatform.FlagMob) {
            anim.SetBool("BShieldDown", flagShield);
        }
        else {
            if (Input.GetMouseButtonDown(1))
            {
                ShieldUp();
            }
            if (Input.GetMouseButtonUp(1))
            {
                ShieldDown();
            }
        }


        UpdateScoreDisplay();
        //���������� �� ��
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");  
        
        StateMovement();
        AnimOnSpeed();
        Flip();     
    }

    private void FixedUpdate(){
      
        m_Rigidbody2D.velocity = lastMotionVector * runSpeed;
    }
    //������������� �������� � ���� 
    public void StateMovement()
    {
        if (YandexGame.EnvironmentData.deviceType == "mobile")
        {
             movement.x = joystick.Horizontal;
             movement.y = joystick.Vertical;
        }

        moving = movement.x != 0 || movement.y != 0;
        if (moving)
        {
            lastMotionVector = new Vector2(movement.x, movement.y).normalized;
            anim.SetBool("IsMoving", true);
        }
        else
        {
            lastMotionVector = Vector2.zero;
            anim.SetBool("IsMoving", false);
        }
        if (currentHealth <= 0)
        {
            live = false;
            gameObject.SetActive(false);
            winMenu.SetLooseMenu();
        }
    }
    private void Flip(){
       
        if (movement.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (movement.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
    public void AnimOnSpeed(){
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }
    
}
