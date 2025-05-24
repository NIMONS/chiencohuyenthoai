using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : PointEneSpawner
{
    [Header("PointSpawner")]
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected float timeDelay = 1f;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected int enemiesSpawned = 0;
    public int EnemiesSpawned => enemiesSpawned;
    [SerializeField] protected int maxEnemiesToSpawn = 4;
    [SerializeField] protected List<Transform> targetPoints;
    [SerializeField] protected PointEneSpawnerCtrl spawnerCtrl;
    [SerializeField] protected EnemyMovement enemyMovement;
    [SerializeField] protected List<Transform> occupiedPoints = new List<Transform>();
    public List<Transform> OccupiedPoints => occupiedPoints;
    [SerializeField] protected List<Transform> occupiedPointsAttack = new List<Transform>();
    public List<Transform> OccupiedPointsAttack => occupiedPointsAttack;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
        this.LoadTargetPoints();
        this.LoadEnemyMovement();
    }

    protected void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = spawnerCtrl.EnemyCtrl.transform.GetComponent<EnemyMovement>();
        Debug.LogWarning(transform.name + ": LoadEnemyMovement", gameObject);
    }

    protected void LoadTargetPoints()
    {
        if (this.targetPoints.Count > 0) return;
        Transform pointAtack = this.spawnerCtrl.PointAttack.transform;
        foreach (Transform i in pointAtack)
        {
            this.targetPoints.Add(i);
        }
        Debug.LogWarning(transform.name + ": LoadTargetPoints", gameObject);
    }

    protected void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = transform.parent.GetComponent<PointEneSpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.SpawnEnemies();
    }

    protected void SpawnEnemies()
    {
        if (this.enemiesSpawned >= this.maxEnemiesToSpawn) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return;

        foreach (Transform spawnpoint in this.listPoints)
        {
            if (this.listPoints.Count > 0 && spawnpoint != null)
            {
                if (!occupiedPoints.Contains(spawnpoint))
                {
                    Transform randomPrefab = this.RandPoints();
                    if (!occupiedPoints.Contains(randomPrefab))
                    {
                        Transform newPrefabEnemy = Instantiate(enemyPrefab.transform, randomPrefab.position, randomPrefab.rotation);
                        newPrefabEnemy.gameObject.SetActive(true);
                        occupiedPoints.Add(randomPrefab);
                        this.MoveEnemy(newPrefabEnemy);
                        this.enemiesSpawned++;
                        return;
                    }
                }
            }
            else
            {
                Debug.LogWarning("EnemyPrefabs or Spawnpoint is missing");
            }
        }
        this.timer = 0f;
        //this.UpdateOccupiedPoints();
        if (occupiedPoints.Count >= this.listPoints.Count)
        {
            Debug.Log("Điểm chiếm đóng đã full!!");
        }
    }

    protected void MoveEnemy(Transform newPrefabEnemy)
    {
        Transform randomPosPrefab = this.RandPointsMove();
        EnemyMovement enemy = newPrefabEnemy.GetComponentInChildren<EnemyMovement>();
        if (randomPosPrefab != null)
        {
            enemy.SetTarget(randomPosPrefab);
            occupiedPointsAttack.Add(randomPosPrefab);
        }
    }

    protected Transform RandPoints()
    {
        int randIndex = Random.Range(0, this.listPoints.Count);
        return this.listPoints[randIndex];
    }

    protected Transform RandPointsMove()
    {
        List<Transform> availablePositions = new List<Transform>();
        foreach (Transform pos in this.targetPoints)
        {
            if (!occupiedPointsAttack.Contains(pos))
            {
                availablePositions.Add(pos);
            }
        }

        if (availablePositions.Count == 0)
        {
            Debug.Log("Tất cả các vị trí chiến đấu đã bị chiếm đóng");
            return null;
        }

        int randIndex = Random.Range(0, availablePositions.Count);
        return availablePositions[randIndex];
    }

    public void DecreaseEnemiesSpawned()
    {
        if (this.enemiesSpawned > 0)
        {
            this.enemiesSpawned--;
            this.UpdateOccupiedPoints();
            if (this.enemiesSpawned < this.maxEnemiesToSpawn)
            {
                this.SpawnEnemies();
            }
        }
    }

    protected void UpdateOccupiedPoints()
    {
        occupiedPoints.RemoveAll(point =>
        {
            if (point == null) return true;

            // Kiểm tra xem có enemy nào vẫn đang ở tại điểm này không
            Collider[] colliders = Physics.OverlapSphere(point.position, 0.1f);
            bool isOccupied = false;

            foreach (Collider col in colliders)
            {
                if (col.GetComponentInParent<EnemyMovement>() != null)
                {
                    isOccupied = true;
                    break;
                }
            }

            // Nếu không có enemy nào chiếm đóng, loại bỏ điểm đó khỏi danh sách
            return !isOccupied;
        });

        occupiedPointsAttack.RemoveAll(point =>
        {
            if (point == null) return true;

            // Kiểm tra xem có enemy nào vẫn đang ở tại điểm tấn công này không
            Collider[] colliders = Physics.OverlapSphere(point.position, 0.1f);
            bool isOccupied = false;

            foreach (Collider col in colliders)
            {
                if (col.GetComponentInParent<EnemyMovement>() != null)
                {
                    isOccupied = true;
                    break;
                }
            }

            // Loại bỏ điểm nếu không bị chiếm đóng
            return !isOccupied;
        });
    }

}


