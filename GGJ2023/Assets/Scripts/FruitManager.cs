using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{

    [SerializeField] private List<Root> roots = new List<Root>();
    [SerializeField] private Transform spawnPosition;
    private float currentTimeWaited;
    private float targetTime;

    public List<Root> Roots { get => roots; }

    private void Update()
    {
        if (targetTime != 0)
        {
            currentTimeWaited += Time.deltaTime;
            if (currentTimeWaited >= 77 / targetTime)
            {
                SpawnFruit();
                UpdateTargetTime();
                ResetCurrentTime();
            }
        }
    }

    private void SpawnFruit()
    {
        FruitDrop fruit = Instantiate(GameManager.Instance.FruitDropOP.GetPooledObject(), spawnPosition.position, Quaternion.identity);
        fruit.CacheFruit(GetFruitFromEnum(GetRandomFruit()));
        fruit.gameObject.SetActive(true);
    }

    private void UpdateTargetTime()
    {
        targetTime = roots.Count;
    }

    private void ResetCurrentTime()
    {
        currentTimeWaited = 0;
    }

    public void RemoveRoot(Root givenRoot)
    {
        if (roots.Contains(givenRoot))
        {
            roots.Remove(givenRoot);
        }
    }

    public void AddRoot(Root givenRoot)
    {
        roots.Add(givenRoot);
        UpdateTargetTime();
    }

    private FruitType GetRandomFruit()
    {
        return (FruitType)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(FruitType)).Length));
    }

    private Fruit GetFruitFromEnum(FruitType gievnFruit)
    {
        switch (gievnFruit)
        {
            case FruitType.ATTACK:
                return new AttackFruit();
            case FruitType.HEAL:
                return new HealFruit();
            case FruitType.SPEED:
                return new SpeedFruit();
            case FruitType.A_SPEED:
                return new ASpeedFruit();
            default:
                return null;
        }
    }


}
