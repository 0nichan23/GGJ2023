using UnityEngine;

public class FruitDrop : Interactable
{
    public Fruit RefFruit;
    [SerializeField] private SpriteRenderer rend;

    public void CacheFruit(Fruit givenFruit)
    {
        Debug.Log("Cached player");
        RefFruit = givenFruit;
        RefFruit.CachePlayer(GameManager.Instance.PlayerWrapper);
    }

    public override void Interact()
    {
        RefFruit.ActivateEffect();
    }
}
