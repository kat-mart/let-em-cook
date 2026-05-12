using UnityEngine;

public class Recipe : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isPageIsOpen = false;
    public Sprite RecipePage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowPage()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = RecipePage;
        isPageIsOpen = true;
    }

    public void CloseRecipe()
    {
        spriteRenderer.sprite = null;
        isPageIsOpen = false;
    }
}
