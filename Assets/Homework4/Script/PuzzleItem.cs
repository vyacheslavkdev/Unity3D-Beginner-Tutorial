using UnityEngine;

public class PuzzleItem : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Material _material;
    private Material _defaultMaterial;

    private Renderer _componentInChildren;
    void Start()
    {
        _componentInChildren = gameObject.GetComponentInChildren<Renderer>();
        _defaultMaterial = _componentInChildren.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<Puzzle>().Trigger(id);
    }

    public void SetEnabled(bool isEnabled)
    {
        _componentInChildren.sharedMaterial = isEnabled ? _material : _defaultMaterial;
    }

    public int Id => id;

    public bool isChanged()
    {
        return _componentInChildren.sharedMaterial == _material;
    }
}