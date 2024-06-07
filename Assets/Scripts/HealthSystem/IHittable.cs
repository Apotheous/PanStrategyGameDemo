using UnityEngine;

public interface IHittable
{   
    void GetHit(int damageValue, GameObject sender);
    void Death(int damageValue, GameObject sender);
}
