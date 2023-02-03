using UnityEngine;

public class FruitDrop : Interactable
{
    public Fruit RefFruit;
    [SerializeField] private SpriteRenderer rend;

    public void CacheFruit(Fruit givenFruit)
    {
        givenFruit.CachePlayer(GameManager.Instance.PlayerWrapper);
        givenFruit.ActivateEffect();
    }

    public override void Interact()
    {
        throw new System.NotImplementedException();
    }
}
