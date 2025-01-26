using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    PlayerMovement movement;
    Rigidbody2D rb;
    PlayerStats stats;
    public ParticleSystem shootBubbles;

    //Timers

    [Header ("BLOCK")]
    
    [SerializeField] bool canBlock;
    [SerializeField] float blockStart;
    [SerializeField] float blockDuration = 2;
    [SerializeField] float blockCD = 2;

    [Header("ATTACK")]
    [SerializeField] bool canAttack;
    [SerializeField] float attackStart;
    [SerializeField] float attackDuration = 2;
    [SerializeField] float attackCD = 2;

    [Header("CATCH")]
    [SerializeField] bool canCatch;
    [SerializeField] float catchStart;
    [SerializeField] float catchDuration = 2;
    [SerializeField] float catchCD = 2;

    [Header("SHOOT")]
    [SerializeField] bool canShoot;
    [SerializeField] float shootStart;
    [SerializeField] float shootDuration = 2;
    [SerializeField] float shootCD = 2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        attackStart = Time.time - attackCD;
        catchStart = Time.time - catchCD;
        blockStart = Time.time - blockCD;
        shootStart = Time.time - shootCD;
    }

    private void Update()
    {
        if (movement.isAirborne)
        {
            animator.SetBool("isAirborne", true);
        }
        else { animator.SetBool("isAirborne", false); }

        if (canBlock)
        {
            animator.SetBool("canBlock", true);
        }

        else { animator.SetBool("canBlock", false); }

        #region Timer Checks
        if (Time.time >= attackStart + attackCD)
        {
            canAttack = true;
        }

        if (Time.time >= catchStart + catchCD)
        {
            canCatch = true;
        }

        if (Time.time >= shootStart + shootCD)
        {
            canShoot = true;
        }

        if (Time.time >= blockStart + blockCD)
        {
            canBlock = true;
        } 

        #endregion

        if (Input.GetKeyDown(KeyCode.J) && canAttack)
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.K) && stats.ZPower < 100 && canCatch)
        {
            StartCoroutine(Catch());
        }

        else if (Input.GetKeyDown(KeyCode.K) && stats.ZPower == 100 && canShoot)
        {
            StartCoroutine(Shoot());
        }



        if (Input.GetKeyDown(KeyCode.L) && canBlock)
        {
            StartCoroutine(Block());
        }



        /*
        if (Input.GetKeyUp(KeyCode.L))
        {
            animator.SetBool("isBlocking", false);
            StopCoroutine(Block());
        }
        */
      

        IEnumerator Attack()
        {
            attackStart = Time.time;
            canAttack = false;
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(attackDuration);
            attackStart = Time.time;
            animator.SetBool("isAttacking", false);
        }

        IEnumerator Catch()
        {
            catchStart = Time.time;
            canCatch = false;
            animator.SetBool("isCatching", true);
            yield return new WaitForSeconds(catchDuration);
            catchStart = Time.time;
            animator.SetBool("isCatching", false);
        }

        IEnumerator Shoot()
        {
            shootStart = Time.time;
            shootBubbles.Play();
            PlayerStats.instance.ResetZ();
            canShoot = false;
            animator.SetBool("isShooting", true);
            yield return new WaitForSeconds(shootDuration);
            catchStart = Time.time;
            animator.SetBool("isShooting", false);
        }

        IEnumerator Block()
        {
            blockStart = Time.time;
            canBlock = false;
            animator.SetBool("isBlocking", true);
            yield return new WaitForSeconds(blockDuration);
            animator.SetBool("isBlocking", false);
        }
    }
}



