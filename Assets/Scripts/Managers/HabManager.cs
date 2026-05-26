using UnityEngine;

public class HabManager : MonoBehaviour
{
    public GameObject player;
    public void addHeaLoNkILL()
    {
        player.AddComponent<HealOnKill>();
    }
}
