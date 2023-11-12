using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    Material bgMaterial;
    Vector2 bgOffset;

    // Start is called before the first frame update
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
        bgOffset = new Vector2(0f, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        bgMaterial.mainTextureOffset += bgOffset * Time.deltaTime;
    }
}
