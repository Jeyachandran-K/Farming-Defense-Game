using UnityEngine;

public class SoilShop : MonoBehaviour
{
    private InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Player.Enable();
    }
    private void Start()
    {
        Player.Instance.OnSeeingSoilShop += Player_OnSeeingSoilShop;

    }

    private void Player_OnSeeingSoilShop(object sender, System.EventArgs e)
    {
        Interact();
    }
    private void Interact()
    {
        Debug.Log("Player in shop range");

        if (input.Player.Interact.WasPressedThisFrame())
        {

            Soil soil= GetComponentInChildren<Soil>();
            soil.transform.SetParent(Player.Instance.transform);
            soil.transform.localPosition = new Vector3(0, 1, 1);

        }
    }
}
