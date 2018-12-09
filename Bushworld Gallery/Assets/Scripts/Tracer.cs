using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracer : MonoBehaviour
{
    public RawImage current;
    public List<Texture> textures;
    // Use this for initialization
    void Start()
    {
        current.gameObject.GetComponent<RawImage>().texture = textures[0];
    }

    public void updateSelection(int i)
    {
        current.gameObject.GetComponent<RawImage>().texture = textures[i];
    }
}
