using UnityEngine;

public class Dragon_Fireball_Behaviour : MonoBehaviour
{
    public float Dragon_Fireball_speed;
    public float Dragon_Fireball_Lifetime;
    public GameObject destroyEffect;

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
        Destroy(gameObject, Dragon_Fireball_Lifetime);
    }
}
