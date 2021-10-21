using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Weapoon : MonoBehaviour
{
    public int meleeDamage = 20;
    public float rateOfAttack = 2f;
    float nextAttack = 0;

    public Vector3 AttackOffset;
    public float AttackRange = 1f;
    public LayerMask attackMask;


    public void Attack()
    {
        if (Time.time >= nextAttack)
        {
            Vector3 pos = transform.position;
            pos += transform.right * AttackOffset.x;
            pos += transform.up * AttackOffset.y;

            Collider2D colInfo = Physics2D.OverlapCircle(pos, AttackRange, attackMask);
            if (colInfo != null)
            {
                colInfo.GetComponent<PlayerStatus>().TakeDamage(meleeDamage);
            }
            nextAttack = Time.time + 1f / rateOfAttack;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * AttackOffset.x;
        pos += transform.up * AttackOffset.y;
        Gizmos.DrawWireSphere(pos, AttackRange);
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
