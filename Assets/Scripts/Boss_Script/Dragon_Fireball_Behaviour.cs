using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Fireball_Behaviour : MonoBehaviour
{
    public float Dragon_Fireball_speed;
    public float Dragon_Fireball_Lifetime;

    public GameObject destroyEffect;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyProjectile", Dragon_Fireball_Lifetime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(transform.right * Dragon_Fireball_speed * Time.deltaTime);
    }
    
    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boss_FlipCollider"))
        {
            Destroy(gameObject);
         
        }
    }
    */
}
