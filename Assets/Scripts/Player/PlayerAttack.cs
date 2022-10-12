using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlayerAttack : MonoBehaviour
{

    //Переменные для таймера
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    //позиция атаки меча
    public Transform attackPos;
    //Слой кого бить
    public LayerMask enemy;
    //Радиус атаки
    public float attackRange;
    //Урон
    public int damage;
    //Аниматор
    public Animator anim;
    //Коллайдеры врагов
    [SerializeField]
    public Collider2D enemies;
    public Collider2D Archer;
    //bool атака
    public bool flagAttack;
    //объект врага
    public GameObject Enemy;
    public GameObject attackParticle;


    private void Update()
    {

        if (ApplicationPlatform.FlagMob)
        {
            //таймер атаки
            if (timeBtwAttack <= 0)
            {
                if (flagAttack)
                {



                    OnAttack();
                    SetAnim();
                    timeBtwAttack = startTimeBtwAttack;

                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
                flagAttack = false;
            }
        }
        else {
            {
                //таймер атаки
                if (timeBtwAttack <= 0)
                {
                    //if (flagAttack) {
                    if (Input.GetMouseButtonDown(0))
                    {


                        OnAttack();
                        SetAnim();
                        timeBtwAttack = startTimeBtwAttack;

                    }
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                    flagAttack = false;
                }
            }
        }
    }
    //функция реагирования атаки 
    public void ClickOnButtonAttack()
    {
       
        flagAttack = true;
    }
    //включение анимации
    public void SetAnim()
    {     
         if (TriggerAttackDown.flagDown)
         {
            Instantiate(attackParticle, new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(0, 0, -90));
            anim.SetTrigger("DownAttack");
            
        } else if (TriggerAttackUp.flagUp)
         {
            Instantiate(attackParticle, new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z), Quaternion.Euler(0, 0, 90));
            anim.SetTrigger("UpAttack");
            
        }
         else
         {
            if (transform.rotation.y == 0)
            {
                Instantiate(attackParticle, new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(attackParticle, new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z), Quaternion.Euler(0, -180, 0));
            }
            anim.SetTrigger("AttackP");
         }  
    }
    // отладка радиуса атаки
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    //реакция врагов на атаку игрока
    public void OnAttack()
    {
        
        enemies = Physics2D.OverlapCircle(attackPos.position, attackRange, enemy);
        if (enemies!=null) {
            if (enemies.tag=="Enemy") {
                enemies.GetComponent<CapsuleCollider2D>().GetComponent<EnemyControl>().TakeDamage(damage);
            }
            else if (enemies.tag == "EnemyArcher")
            {
                enemies.GetComponent<CapsuleCollider2D>().GetComponent<ArcherControl>().TakeDamage(damage);
            }
        }

    }
   


}
