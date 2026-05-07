using UnityEngine;

public class Recipebook : MonoBehaviour
{
    public Sprite openRecipeBookSprite;
    public Sprite closedRecipeBookSprite;
    private bool bookIsOpen = false;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        }
        else
        {
            ChangeToClosedRecipeBookSprite();
        }
    }
}
