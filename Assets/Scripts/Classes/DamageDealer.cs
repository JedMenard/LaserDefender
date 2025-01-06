using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private bool damagesPlayers = true;

    [SerializeField]
    private bool damagesEnemies = true;

    [SerializeField]
    private bool isProjectile = false;

    [SerializeField]
    private float damagePerHit = 10;

    public void DealDamage(Health target)
    {
        if (target.IsPlayer && this.damagesPlayers
            || target.IsEnemy && this.damagesEnemies)
        {
            target.ApplyDamage(this.damagePerHit);

            if (this.isProjectile)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
