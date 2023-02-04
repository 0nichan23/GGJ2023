using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{

    [SerializeField] private List<Root> roots = new List<Root>();
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private Sprite attackSprite;
    [SerializeField] private Sprite speedSprite;
    [SerializeField] private Sprite aSpeedSprite;
    [SerializeField] private Sprite healSprite;
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
        Fruit fruittype = GetFruitFromEnum(GetRandomFruit());
        fruit.CacheFruit(fruittype,  GetSpriteFromFruiteEnum(fruittype.FruitType));

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
            case FruitType.A_SPEED:
                return new ASpeedFruit();
            case FruitType.SPEED:
                return new SpeedFruit();
            default:
                return null;
        }
    }


    private Sprite GetSpriteFromFruiteEnum(FruitType gievnFruit)
    {
        switch (gievnFruit)
        {
            case FruitType.ATTACK:
                return attackSprite;
            case FruitType.HEAL:
                return healSprite;
            case FruitType.A_SPEED:
                return aSpeedSprite;
            case FruitType.SPEED:
                return speedSprite;
            default:
                return null;
        }
    }

}
