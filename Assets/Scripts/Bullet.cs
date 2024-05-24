using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifetime = 3.0f;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDamage(int dmg) {
        damage = dmg;
    }

    private void DestroyBullet() 
    { 
        Destroy(this.gameObject); 
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
        {
            e.Damage(damage);
        }

        DestroyBullet();
    }
}
