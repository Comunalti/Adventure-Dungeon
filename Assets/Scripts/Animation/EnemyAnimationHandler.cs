using System;
using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Animator anim;
    [SerializeField] private HealthController healthController;
    [SerializeField] private SpriteRenderer sprRnd;
    [SerializeField] private float fadeOutSpeed = 0.1f;
    
    private void OnEnable()
    {
        healthController.DeathEvent += OnEnemyDeath;
    }
    
    private void OnDisable()
    {
        healthController.DeathEvent -= OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        anim.SetTrigger("IsDead");
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        var c = sprRnd.material.color;
        for (float alpha = 1; Mathf.Clamp(alpha, 0, 1f) != 0; alpha -= 0.1f)
        {
            c.a = alpha;
            sprRnd.material.color = c;
            yield return new WaitForSeconds(fadeOutSpeed);
        }
        
        Destroy(enemy);
    }
}
