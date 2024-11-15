using UnityEngine;

public class Item
{
    #region FIELDS

    private static int _idCount = 0;
    private int _itemID;
    private string _itemName;
    private Sprite _itemSprite;

    #endregion

    #region PROPERTIES

    public static int IdCount
    {
        get { return _idCount; }
    }
    public int ItemID
    {
        get { return _itemID; }
    }
    public string ItemName
    {
        get { return _itemName; }
    }
    public Sprite ItemSprite
    {
        get { return _itemSprite; }
    }
    
    #endregion      
    
    #region UTILITY FUNCTIONS
    public Item(string name, Sprite sprite)
    {
        _itemID = _idCount;
        _idCount++;
        _itemName = name;
        _itemSprite = sprite;
    }
    #endregion
}