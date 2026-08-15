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
        Devolution newDevolution = requestManager.ComparePotion(cauldron.GetPotion());
    }
}
