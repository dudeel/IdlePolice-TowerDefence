using UnityEngine;

public class UI_CardSelecting : MonoBehaviour
{
    public int Index;
    public UI_SelectingCardMenu SelectingCardMenu;

    private void Start() { }
    public void SendSelected()
    {
        if (!transform.GetComponent<UI_CardSelecting>().isActiveAndEnabled) return;
        SelectingCardMenu.ChangeCard(Index);
    }
}
