using System;
using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

public class DeathFadeController : MonoBehaviour
{
    public HealthController healthController;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private float duration;
    
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
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        var collider = GetComponent<Collider2D>();
        Destroy(collider);
        var wait = new WaitForEndOfFrame();
        var currentDuration = duration;
        while (0 < currentDuration)
        {
            currentDuration -= Time.deltaTime;
            var color = spriteRenderer.color;
            color.a = currentDuration / duration;
            spriteRenderer.color = color;
            yield return wait;
        }
        Destroy(gameObject);
    }
}
