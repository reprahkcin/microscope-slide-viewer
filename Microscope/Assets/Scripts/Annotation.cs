using UnityEngine;

public class Annotation : MonoBehaviour
{
    private string _header;
    private string _body;
    private Vector2 _pos;

    public Annotation(string header, string body, float x, float y)
    {
        _header = header;
        _body = body;
        _pos = new Vector2(x,y);
        gameObject.GetComponent<RectTransform>().position = _pos;
    }
}
