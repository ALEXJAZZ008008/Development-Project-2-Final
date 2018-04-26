using UnityEngine;
using UnityEngine.UI;

public class CopyText : MonoBehaviour
{
    public Text parentText;

    private Text gameObjectText;

    void Awake()
    {
        gameObjectText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObjectText.text = parentText.text;
    }
}
