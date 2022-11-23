using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{

    [Tooltip("Vida del panda")]
    public float health;
    [Tooltip("Velocidad del panda")]
    public float speed;
    [Tooltip("Daño que hace el panda")]
    public int cakeEatenPerBite;

    private Animator animator;
    private Rigidbody2D rb2D;

    //Hashings representando los tres nombres de los triggers del animator del panda.
    private int AnimatorDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int AnimatorEatTriggerHash = Animator.StringToHash("EatTrigger");
    private int AnimatorHitTriggerHash = Animator.StringToHash("HitTrigger");

    private static GameManager gameManager;
    private Waypoint currentWaypoint;
    private const float waypointThreshold = 0.001f;

    private bool isDead = false;

    private void Start()
    {
        if (gameManager == null){gameManager = FindObjectOfType<GameManager>();}

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        currentWaypoint = gameManager.firstWaypoint;
    }

    private void FixedUpdate()
    {
        if (isDead) { return; }
        if(currentWaypoint == null)
        {
            Eat();
            return;
        }

        float distance = Vector2.Distance(this.transform.position, currentWaypoint.GetPosition());
        if (distance <= waypointThreshold)
        {
            currentWaypoint = currentWaypoint.GetNextWaypoint();
        }
        else
        {
            MoveTowards(currentWaypoint.GetPosition());
        }
    }

    private void MoveTowards(Vector3 destination)
    {
        float step = speed * Time.fixedDeltaTime; //Espacio = v * t

        rb2D.MovePosition(Vector3.MoveTowards(this.transform.position, destination, step));
    }

    private void Hit(float damage)
    {
        if (!isDead)
        {
            health -= damage;
            if (health > 0) { animator.SetTrigger(AnimatorHitTriggerHash); }
            else
            {
                animator.SetTrigger(AnimatorDieTriggerHash);
                isDead = true;
                gameManager.OneMorePandaInHell();
            }
        }
    }

    private void Eat()
    {
        animator.SetTrigger(AnimatorEatTriggerHash);
        gameManager.BiteTheCake(cakeEatenPerBite);
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
        {
            Hit(collision.GetComponent<ProjectileScript>().damage);
            Destroy(collision.gameObject);
        }
    }
}
