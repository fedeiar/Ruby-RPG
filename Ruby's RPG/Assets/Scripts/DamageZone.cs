using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyHealth r_health = other.GetComponent<RubyHealth>();

        if (r_health != null)
        {
            r_health.ChangeHealth(-1);
        }
    }

}
