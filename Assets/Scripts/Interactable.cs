using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float interactionRange = 1f;

    private SpriteRenderer spriteRenderer;
    private Transform player;

    private Color normalColor = Color.white;
    private Color highlightColor = Color.yellow;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance <= interactionRange)
        {
            spriteRenderer.color = highlightColor;
        }
        else
        {
            spriteRenderer.color = normalColor;
        }
    }
}