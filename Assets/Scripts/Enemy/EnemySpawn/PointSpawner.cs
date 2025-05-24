using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MoveObjcet
{
    [Header("PointSpawner")]
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;
    [SerializeField] protected PointEneSpawnerCtrl spawnerCtrl;
    [SerializeField] protected float timeDelay = 1.5f;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected int enemiesSpawned = 0;
    public int EnemiesSpawned => enemiesSpawned;
    [SerializeField] protected int maxEnemiesToSpawn = 4;
    [SerializeField] protected float tempTimer = 0f;
    [SerializeField] protected float tempDelayTimer = 10f;
    [SerializeField] protected bool reservePointSetup = false;
    [SerializeField] protected bool reservePointsActivated = false;
    [SerializeField] protected List<Transform> listPoints;
    [SerializeField] protected List<Transform> targetPoints;
    [SerializeField] protected List<Transform> occupiedPointsAttack = new List<Transform>();
    public List<Transform> OccupiedPointsAttack => occupiedPointsAttack;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
        this.LoadTargetPoints();
        this.LoadEnemySpawnerCtrl();
        this.LoadListPoints();
    }

    protected void LoadListPoints()
    {
        if (this.listPoints.Count>0) return;
        Transform listPointSpawn = this.transform;
        foreach(Transform t in listPointSpawn) 
        {
            this.listPoints.Add(t);
        }
        Debug.LogWarning(transform.name + ": LoadListPoints", gameObject);
    }

    protected void LoadEnemySpawnerCtrl()
    {
        if (this.enemySpawnerCtrl != null) return;
        this.enemySpawnerCtrl = transform.parent.parent.GetComponent<EnemySpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnerCtrl", gameObject);
    }

    protected void LoadTargetPoints()
    {
        if (this.targetPoints.Count > 0) return;
        Transform pointAtack = this.spawnerCtrl.PointAttack.transform;
        foreach(Transform i in pointAtack)
        {
            this.targetPoints.Add(i);
        }
        this.hideTargetPoint();

        Debug.LogWarning(transform.name + ": LoadTargetPoints", gameObject);
    }

    protected void hideTargetPoint()
    {
        for (int j = 4; j < this.targetPoints.Count; j++)
        {
            this.targetPoints[j].gameObject.SetActive(false);
        }
    }

    protected void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl=transform.parent.GetComponent<PointEneSpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.SpawnEnemies();
    }

    protected void SpawnEnemies()
    {
        GameObject enemyPrefab = enemySpawnerCtrl.Prefabs[0].gameObject;

        this.tempTimer += Time.deltaTime;

        if (!reservePointsActivated && this.tempTimer >= this.tempDelayTimer)
        {
            Debug.Log("Bật điểm dự bị");
            this.turnOnPointReserve(); //Bật các point bị ẩn
            this.reservePointsActivated = true;//đánh dấu các điểm dự bị đã được bật
            this.tempTimer = this.tempDelayTimer;
            this.maxEnemiesToSpawn += 2;
        }

        if (this.enemiesSpawned >= this.maxEnemiesToSpawn) return;

        this.timer += Time.deltaTime;

        if (this.listPoints.Count <= 0 || this.timer < this.timeDelay) return;
        Transform spawnPoint = this.listPoints[0];
        Transform newPrefabEnemy = Instantiate(enemyPrefab.transform, spawnPoint.position, spawnPoint.rotation);
        newPrefabEnemy.gameObject.SetActive(true);
        newPrefabEnemy.SetParent(this.enemySpawnerCtrl.Holder);
        this.MoveEnemy(newPrefabEnemy);
        this.enemiesSpawned++;
        this.timer = 0;
    }

    protected void MoveEnemy(Transform newPrefabEnemy)
    {
        Transform randomPosPrefab = this.RandPointsMove();
        EnemyMovement enemy = newPrefabEnemy.GetComponentInChildren<EnemyMovement>();
        if (randomPosPrefab == null) return;
        enemy.SetTarget(randomPosPrefab);
        enemy.SetAttackPosition(randomPosPrefab);
        occupiedPointsAttack.Add(randomPosPrefab);

        //for(int i = 4; i< this.targetPoints.Count; i++)
        //{
           // if (this.targetPoints[i].gameObject.activeSelf)
          //  {
           //     Debug.Log("Gọi setupPosReserve");
          //      this.setupPosReserve(enemy);//fix lỗi
           // }
        //}

        if (!this.reservePointSetup && this.targetPoints[4].gameObject.activeSelf)
        {
            Debug.Log("Gọi setupPosReserve");
            this.reservePointSetup = true;
            this.setupPosReserve(enemy);
        }
    }

    protected Transform RandPointsMove()
    {
        List<Transform> availablePositions = new List<Transform>();
        foreach(Transform pos in this.targetPoints)
        {
            if (pos.gameObject.activeSelf)
            {
                if (!occupiedPointsAttack.Contains(pos))
                {
                    availablePositions.Add(pos);
                }
            }
        }

        if(availablePositions.Count ==0) 
        {
            Debug.Log("Tất cả các vị trí chiến đấu đã bị chiếm đóng");
            return null;
        }

        int randIndex = Random.Range(0,availablePositions.Count);
        return availablePositions[randIndex];
    }

    public void DecreaseEnemiesSpawned()
    {
        if (this.enemiesSpawned > 0) this.enemiesSpawned--;
    }

    public void RemoveAttackPosition(Transform attackPos)
    {
        occupiedPointsAttack.Remove(attackPos);
    }

    protected void turnOnPointReserve()
    {
        for (int i = 4; i < this.targetPoints.Count; i++)
        {
            this.targetPoints[i].gameObject.SetActive(true);
        }
    }

    protected void setupPosReserve(EnemyMovement enemyMove)
    {
        //thay đổi rotation của enemy
    }
}


