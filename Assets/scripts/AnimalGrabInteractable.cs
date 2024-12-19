using UnityEngine;

public class AnimalGrabInteractable : MonoBehaviour
{
    public AnimalManager animalManager; // AnimalManager 참조

    // 오브젝트가 Grab되었을 때 호출
    public void OnGrab()
    {
        if (animalManager != null)
        {
            animalManager.OnAnimalGrabbed(gameObject);
        }
    }
}
