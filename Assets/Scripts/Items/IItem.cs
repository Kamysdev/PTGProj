
using UnityEngine;

public interface IItem
{
    public string GetName();
    public void Use(Collider player);
}