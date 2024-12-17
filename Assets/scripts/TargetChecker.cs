using System.Collections.Generic;
using UnityEngine;

public class TargetChecker : MonoBehaviour
{
    // 순서를 맞춰야 하는 태그 목록
    public List<string> correctOrderTags = new List<string> { "Disk1", "Disk2", "Disk3", "Disk4", "Disk5" };

    private int currentIndex = 0; // 현재 확인 중인 태그 인덱스

    void OnTriggerEnter(Collider other)
    {
        // 들어온 오브젝트의 태그 확인
        if (other.CompareTag(correctOrderTags[currentIndex]))
        {
            Debug.Log($"원판 {correctOrderTags[currentIndex]} 이(가) 올바른 위치에 들어갔습니다.");
            currentIndex++;

            // 모든 원판이 들어갔을 때 클리어 처리
            if (currentIndex >= correctOrderTags.Count)
            {
                Debug.Log("클리어! 모든 원판이 올바른 순서로 들어갔습니다.");
                ClearLevel();
            }
        }
        else
        {
            Debug.Log("잘못된 원판입니다. 순서를 다시 확인하세요!");
            ResetProgress();
        }
    }

    void ClearLevel()
    {
        // 클리어 상태 처리 (예: 다음 씬으로 이동, 메시지 출력 등)
        Debug.Log("게임 클리어!");
    }

    void ResetProgress()
    {
        // 실패 시 진행 상황 초기화
        Debug.Log("진행 상황이 초기화되었습니다.");
        currentIndex = 0;
    }
}
