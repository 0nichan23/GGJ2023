using UnityEngine;

public class FruitDrop : Interactable
{
    public Fruit RefFruit;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private AudioSource source;

    public void CacheFruit(Fruit givenFruit, Sprite givenSprite)
    {
        Debug.Log("Cached player");
        RefFruit = givenFruit;
        rend.sprite = givenSprite;
        RefFruit.CachePlayer(GameManager.Instance.PlayerWrapper);
    }

    public override void Interact()
    {
        RefFruit.ActivateEffect();
        source.Play();
        gameObject.SetActive(false);
    }
}
