using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController r_health = other.GetComponent<RubyController>();

        if (r_health != null)
        {
            r_health.ChangeHealth(-1);
        }
    }

}
