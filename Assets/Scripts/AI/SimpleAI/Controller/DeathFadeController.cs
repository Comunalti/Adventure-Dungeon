using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFadeController : MonoBehaviour
{
    public Health health;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private float duration;
    
    private void OnEnable()
    {
        health.DiedEvent += OnEnemyDied;
    }
    private void OnDisable()
    {
        health.DiedEvent -= OnEnemyDied;
    }

    private void OnEnemyDied()
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
