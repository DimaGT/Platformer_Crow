using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private TriggerDamage triggerDamage;
    [SerializeField] private float force;
    [SerializeField] private float lifeTime;

    public float Force
    {
        get { return force; }
        set { force = value; }
    }
    public void SetImpulse(Vector2 direction, float force, GameObject parent)
    {
        triggerDamage.Parent = parent;
        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
        if (force < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        StartCoroutine(StartLife());
    }

    private IEnumerator StartLife()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        yield break;
    }
}
