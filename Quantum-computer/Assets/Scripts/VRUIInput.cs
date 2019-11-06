using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;


public class VRUIInput : MonoBehaviour
{

    private QuantumVR_LaserPointer laserPointer;
    private HoverButton lastButton;
    private Hand hand;
    private bool hovering;

    void Awake()
    {
        hand = gameObject.GetComponent<Hand>();
        laserPointer = gameObject.GetComponent<QuantumVR_LaserPointer>();
        laserPointer.PointerClick += PointerClick;
        laserPointer.PointerIn += PointerIn;
        laserPointer.PointerOut += PointerOut;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        var button = e.target.GetComponent<HoverButton>();
        if (button==null) return;
        button.onButtonDown.Invoke(hand);
        lastButton = button;
        Invoke(nameof(AfterClick), 0.25f);
    }

    public void AfterClick()
    {
        lastButton.onButtonUp.Invoke(hand);
    }

    public void PointerIn(object sender, PointerEventArgs e)
    {
        var button = e.target.GetComponent<HoverButton>();
        if (button==null) return;
        lastButton = button;
        lastButton.transform.GetChild(0).gameObject.SetActive(true);
        hovering = true;
    }

    public void PointerOut(object sender, PointerEventArgs e) {
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