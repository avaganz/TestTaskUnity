using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private Vector2 _sensity = Vector2.one;

    [SerializeField]
    private float _damping = 1f;

    public static InputController Instance { get; private set; }

    public Vector2 Delta { get; private set; }

    private bool _isDragging = false;

    private Vector2 _downPoint;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDragging = true;
        _downPoint = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
        Delta = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Delta = new Vector2((eventData.position.x - _downPoint.x) * _sensity.x,
                            (eventData.position.y - _downPoint.y) * _sensity.y);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!_isDragging)
            KeyboardUpdate();
    }

    private void KeyboardUpdate()
    {
        Delta = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            Delta = new Vector2(Delta.x, 400f);

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            Delta = new Vector2(Delta.x, -400f);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            Delta = new Vector2(200f, Delta.y);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            Delta = new Vector2(-200f, Delta.y);
    }
}
