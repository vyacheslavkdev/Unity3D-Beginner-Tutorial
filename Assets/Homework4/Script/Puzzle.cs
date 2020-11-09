using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private PuzzleItem[] _items;
    
    void Start()
    {
        _items = gameObject.GetComponentsInChildren<PuzzleItem>();
    }

    public void Trigger(int id)
    {
        bool isAllChanged = true;
        foreach (PuzzleItem item in _items)
        {
            if (item.Id == id)
            {
                item.SetEnabled(true);
            }

            if (!item.isChanged())
            {
                isAllChanged = false;
            }
        }
        
        if (isAllChanged)
        {
            Win();
        }
    }

    public void Win()
    {
        //todo выдать ключ
    }
}
