using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            animator.SetTrigger("Die");
            GameManager.Instance.GameOver();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ScoreOrb"))
        {
            GameManager.Instance.AddScore(5);
            Destroy(collider.gameObject);
        }
    }
}
