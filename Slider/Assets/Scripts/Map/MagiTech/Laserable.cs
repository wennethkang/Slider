using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public class Laserable : MonoBehaviour
{
    public enum LaserInteractionType
    {
        Reflect,
        Portal,
        Absorb,
        Passthrough
    }

    [SerializeField] private LaserInteractionType laserInteractionType;
    [Tooltip("ONLY FOR MIRRORS. Check if mirror faces backwards")]
    public bool flipDirection;
    public bool isLasered;
    public UnityEvent OnLasered;
    public UnityEvent OnUnLasered;

    private void OnEnable()
    {
        SGridAnimator.OnSTileMoveStart += OnSTileMoveStart;
    }

    private void OnDisable()
    {
        SGridAnimator.OnSTileMoveStart -= OnSTileMoveStart;
    }

    private  void OnSTileMoveStart(object sender, SGridAnimator.OnTileMoveArgs e)
    {
        if (isLasered) OnUnLasered?.Invoke();
        isLasered = false;
    }

    public bool IsInteractionType(string type)
    {
        return laserInteractionType == (LaserInteractionType) Enum.Parse(typeof(LaserInteractionType), type);
    }

    public void SetTransparency(bool b)
    {
        Tilemap tm = GetComponent<Tilemap>();
        Color color = tm.color;
        color.a = b ? 0 : 255;
        tm.color = color;
    }
}
