using UnityEngine;

public class DamageSender : CCHTMonoBehaviour
{
    [SerializeField] protected int damageSendMeteorite = 2;
    public int DamageSendMeteorite => damageSendMeteorite;
    [SerializeField] protected int damageSendEnemy = 2;
    public int DamageSend => damageSendEnemy;
    [SerializeField] protected FXSpawner fxSpawner;
    public FXSpawner FXSpawner => fxSpawner;
    [SerializeField] protected JunkSpawner itemSpawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFXSpawner();
        this.LoadItemSpawner();
    }

    protected void LoadItemSpawner()
    {
        if (this.itemSpawner != null) return;
        this.itemSpawner = GameObject.FindObjectOfType<JunkSpawner>();
        Debug.LogWarning(transform.name + ": LoadItemSpawner", gameObject);
    }

    protected void LoadFXSpawner()
    {
        if (this.fxSpawner != null) return;
        this.fxSpawner = GameObject.FindObjectOfType<FXSpawner>();
        Debug.LogWarning(transform.name + ": LoadFXSpawner", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.SpawnFX();
        }
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            this.SendDamage();
            this.SpawnFX();
        }
    }

    protected void SendDamage()
    {
        Destroy(transform.parent.gameObject);
    }

    protected void SpawnFX()
    {
        Transform effectImpact = fxSpawner.Prefabs[1].transform;
        Transform effectImpactSpawn = Instantiate(effectImpact, transform.position, transform.rotation);
        effectImpactSpawn.gameObject.SetActive(true);
        effectImpactSpawn.SetParent(fxSpawner.Holder);
    }
}
