using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public enum Team
    {
        player,
        enemy,
    }
    public Team team = new Team();
}
