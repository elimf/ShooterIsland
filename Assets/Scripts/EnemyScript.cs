using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
  private WeaponScript weapon;

  void Awake()
  {
    // Récupération de l'arme au démarrage
    weapon = GetComponentInChildren<WeaponScript>();
  }

  void Update()
  {
    // Tir auto
    if (weapon != null && weapon.CanAttack)
    {
      weapon.Attack(true);
    }
  }
}