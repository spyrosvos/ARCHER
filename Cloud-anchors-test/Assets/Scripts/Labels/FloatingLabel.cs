using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingLabel : MonoBehaviour
{
    private Canvas canvas;
    private Camera cam;
    private Transform AnchorPoint;
    private RectTransform ui;
    private TextMeshProUGUI txt;
    // Start is called before the first frame update
    private bool showing = false;
    private Vector3 outside;
    void Start()
    {
        outside = new Vector3(-10000, -10000);
    }

    public void SetupLabel(Canvas canvas, Camera cam, Transform AnchorPoint, string text) {
        this.canvas = canvas;
        this.cam = cam;
        this.AnchorPoint = AnchorPoint;
        ui = GetComponent<RectTransform>();
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = text;
        showing = true;
    }

    // Update is called once per frame
    void Update() {
        if (!showing) return;
        Vector3 directionToTarget = cam.transform.position - AnchorPoint.position;
        float angle = Vector3.Angle(cam.transform.forward, directionToTarget);
        if (Mathf.Abs(angle) > 90) {
            RectTransform CanvasRect = canvas.GetComponent<RectTransform>();

            Vector2 ViewportPosition = cam.WorldToViewportPoint(AnchorPoint.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

            ui.anchoredPosition = WorldObject_ScreenPosition;
        }
        else {
            //hide
            ui.anchoredPosition = outside;
        }
    }
}
