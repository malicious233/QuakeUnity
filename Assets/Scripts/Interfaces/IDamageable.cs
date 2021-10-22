using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamageable 
{
    //Interface for allowing this object to be damaged
    void InflictDamage(Damage damageClass);


}
