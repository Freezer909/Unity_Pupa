using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,
    IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransform;
    private Canvas canvas;
    SFX_Script sfxScript;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Sākts vilkt velkamo objektu");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Velk velkamo objektu");
         Vector2 mousePosition = eventData.position;
        mousePosition.x = Mathf.Clamp(mousePosition.x, 0+rectTransform.rect.width / 2, Screen.width - rectTransform.rect.width / 2);

        mousePosition.y = Mathf.Clamp(mousePosition.y, 0 + rectTransform.rect.height / 2, Screen.height - rectTransform.rect.height / 2);

        rectTransform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Pabeigts vilkt velkamo objektu");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Izdarīts klikšķis uz velkamā objekta");
        sfxScript.PlaySFX(2);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxScript = FindFirstObjectByType<SFX_Script>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
