using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform character;  // Reference to your character (the Cube)
    public Vector3 offset = new Vector3(0, 1, -3);      // Offset from the character's position (x, y and z updates)

    void Update()
    {
        if (character != null)
        {
            transform.position = character.position + offset; //Follows character periodically
        }
    }
}
