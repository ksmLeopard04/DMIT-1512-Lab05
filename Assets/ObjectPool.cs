using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledBullets;
    public GameObject bulletPrefab;
    public List<GameObject> pooledTowers;
    public GameObject towerPrefab;
    public List<GameObject> pooledEnemies;
    public GameObject enemyPrefab;
    public List<GameObject> pooledMines;
    public GameObject minePrefab;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledBullets = new List<GameObject>();
        pooledTowers = new List<GameObject>();
        pooledEnemies = new List<GameObject>();
        pooledMines = new List<GameObject>();
        GameObject tmp;
        GameObject tmp1;
        GameObject tmp2;
        amountToPool = 100;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(bulletPrefab);
            tmp.SetActive(false);
            pooledBullets.Add(tmp);
        }
        for (int i = 0; i < amountToPool; i++)
        {
            tmp1 = Instantiate(towerPrefab);
            tmp1.SetActive(false);
            pooledTowers.Add(tmp1);
        }
        for (int i = 0; i < amountToPool; i++)
        {
            tmp2 = Instantiate(enemyPrefab);
            tmp2.SetActive(false);
            pooledEnemies.Add(tmp2);
        }
        for (int i = 0; i < amountToPool; i++)
        {
            tmp2 = Instantiate(minePrefab);
            tmp2.SetActive(false);
            pooledMines.Add(tmp2);
        }
    }
    public GameObject GetPooledObject(int objectToPool)
    {
        switch (objectToPool)
        {
            case 1:
                for (int i = 0; i < amountToPool; i++)
                {
                    if (!pooledBullets[i].activeInHierarchy)
                    {
                        return pooledBullets[i];
                    }
                }
                break;
            case 2:
                for (int i = 0; i < amountToPool; i++)
                {
                    if (!pooledTowers[i].activeInHierarchy)
                    {
                        return pooledTowers[i];
                    }
                }
                break;
            case 3:
                for (int i = 0; i < amountToPool; i++)
                {
                    if (!pooledEnemies[i].activeInHierarchy)
                    {
                        return pooledEnemies[i];
                    }
                }
                break;
            case 4:
                for (int i = 0; i < amountToPool; i++)
                {
                    if (!pooledMines[i].activeInHierarchy)
                    {
                        return pooledMines[i];
                    }
                }
                break;
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
