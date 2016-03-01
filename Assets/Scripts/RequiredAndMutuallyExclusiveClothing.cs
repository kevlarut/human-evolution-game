using UnityEngine;
using System.Collections;

public class RequiredAndMutuallyExclusiveClothing : MonoBehaviour
{
    public string Key;

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
