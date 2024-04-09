using UnityEngine;

[CreateAssetMenu(fileName = "InfoNave", menuName = "ScriptableObjects/Cositos/TheBest", order = 1)]
public class Nave : ScriptableObject
{
    public Sprite Imagen;
    public int vida;
    public float velocidadHorizontal;
    public float velocidadVertical;

}
