using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스 추가

public class AnimalManager : MonoBehaviour
{
    public TMP_Text resultText; // Clear! 메시지를 표시할 UI 텍스트
    private int totalAnimals = 6; // 총 동물 수
    private int removedAnimals = 0; // 사라진 동물 수

    // 동물이 사라질 때 호출되는 메서드
    public void OnAnimalGrabbed(GameObject animal)
    {
        // 동물 오브젝트를 제거
        Destroy(animal);
        removedAnimals++;

        // 모든 동물이 사라지면 Clear! 메시지 표시
        if (removedAnimals >= totalAnimals)
        {
            resultText.text = "Clear!";
            Debug.Log("All animals are removed. Clear!");
            FindObjectOfType<GameManager>().CompleteGame3();
        }
    }
}
