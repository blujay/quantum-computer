using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;


public class VRUIInput : MonoBehaviour
{


    private Transform player;
    private QuantumVR_LaserPointer laserPointer;
    private HoverButton lastButton;
    private Hand hand;
    private bool hovering;

    void Awake()
    {
        player = gameObject.GetComponentInParent<Player>().transform;
        hand = gameObject.GetComponent<Hand>();
        laserPointer = gameObject.GetComponent<QuantumVR_LaserPointer>();
        laserPointer.PointerClick += PointerClick;
        laserPointer.PointerIn += PointerIn;
        laserPointer.PointerOut += PointerOut;
        Go.defaultEaseType = GoEaseType.QuintInOut;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        var tp = e.target.parent.GetComponent<TeleportPoint>();
        if (tp != null)
        {
            player.positionTo(1.5f, tp.transform.position);
            player.rotationTo(1.5f, tp.transform.rotation);
        }

        var button = e.target.GetComponent<HoverButton>();
        if (button != null)
        {
            button.onButtonDown.Invoke(hand);
            lastButton = button;
            Invoke(nameof(AfterClick), 0.25f);
        }
    }

    public void AfterClick()
    {
        lastButton.onButtonUp.Invoke(hand);
    }

    public void PointerIn(object sender, PointerEventArgs e)
    {
        var tp = e.target.parent.GetComponent<TeleportPoint>();
        if (tp != null)
        {
            tp.Highlight(true);
        }
        var button = e.target.GetComponent<HoverButton>();
        if (button==null) return;
        lastButton = button;
        lastButton.transform.GetChild(0).gameObject.SetActive(true);
        hovering = true;
    }

    public void PointerOut(object sender, PointerEventArgs e) {
        var tp = e.target.parent.GetComponent<TeleportPoint>();
        if (tp != null)
        {
            tp.Highlight(false);
        }
        var button = e.target.GetComponent<HoverButton>();
        if (button==null) return;
        lastButton.transform.GetChild(0).gameObject.SetActive(false);
        lastButton = null;
        hovering = false;
    }

    void Update() {
        if (hovering && lastButton!=null) {
            lastButton.onButtonIsPressed.Invoke(hand);
        }
    }


}