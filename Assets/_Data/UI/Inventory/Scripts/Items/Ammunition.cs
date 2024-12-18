using System.Text;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "New Ammunition", menuName = "Items/Ammunition")]
public class Ammunition : InventoryItem
{
    [SerializeField] private GameObject ammunitionPrefab = null;

    public GameObject AmmunitionPrefab => ammunitionPrefab;

    public override string GetInfoDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(Rarity.Name).AppendLine();
        builder.Append("Max Stack: ").Append(MaxStack).AppendLine();
        builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

        return builder.ToString();
    }
    public override void Use(GameObject user)
    {
        if (behavior != null)
        {
            behavior.Execute(user, value);
        }
        else
        {
            Debug.LogWarning("Item không có hành vi được gắn.");
        }
    }
}

