using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private RequestManager requestManager;
    [SerializeField] private Cauldron cauldron;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DeliverPotion()
    {
        if (cauldron.itemsInPotion.Count > 0 && !requestManager.requestCompleted)
        {
            Devolution newDevolution = requestManager.ComparePotion(cauldron.GetPotion());
            cauldron.Clean();
        }
    }
}
