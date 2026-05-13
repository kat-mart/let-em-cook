using UnityEngine;

public class Recipebook : MonoBehaviour
{
    public Sprite openRecipeBookSprite;
    public Sprite closedRecipeBookSprite;
    private bool bookIsOpen = false;
    private SpriteRenderer spriteRenderer;
    private Vector3 SpritePosition;
    public Recipe Recipe;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public Vector3 GetSpritePosition()
    {
        return transform.position;
    }
    
    // when we click on the recipe book it changes art to open book and our recipe shows
    private void ChangeToOpenBookSprite()
    {
        spriteRenderer.sprite = openRecipeBookSprite;
        bookIsOpen = true;
    }

    private void ChangeToClosedRecipeBookSprite()
    {
        spriteRenderer.sprite = closedRecipeBookSprite;
        bookIsOpen = false;
    }
    
    //  Change to only open when on the recipe book
    public void MouseClickDetected()
    {
        if (!bookIsOpen)
        {
            ChangeToOpenBookSprite();
            ShowRecipe();
        }
        else
        {
            ChangeToClosedRecipeBookSprite();
            Recipe.CloseRecipe();
        }
    }

    private void ShowRecipe()
    {
        Recipe.ShowPage();
    }
}
