using UnityEngine;
using Pathfinding;

public class Dragon_Fireball_Behaviour : MonoBehaviour
{
    public float Dragon_Fireball_speed;
    public float Dragon_Fireball_Lifetime;
    public GameObject destroyEffect;
    // Start is called before the first frame update
    private void Start()
    {
        //Invoke("DestroyProjectile", Dragon_Fireball_Lifetime);
    }

    // Update is called once per frame
    private void Update()
    {


        if (Dragon_Pathfinding.x >= 0.00f || Dragon_Pathfinding.x <= 0.00f)
        {
            transform.Translate(transform.up * Dragon_Fireball_speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, -90);
        }

    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        Destroy(gameObject, Dragon_Fireball_Lifetime);
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
