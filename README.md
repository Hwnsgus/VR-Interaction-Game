# 가상현실 기말 프로젝트

## Unity VR Toolkit – Interaction Learning Game

이 프로젝트는 **Unity XR Interaction Toolkit**을 활용한 **기초 VR 상호작용 학습용 게임**입니다.  
플레이어는 다양한 VR 상호작용(잡기, 놓기, 충돌, 클릭 등)을 체험하며  
세 가지 미니게임을 통해 VR 환경에서의 물리 및 이벤트 흐름을 학습할 수 있습니다.

## 프로젝트 개요

| 미니게임 | 설명 | 주요 스크립트 |
|-----------|------|----------------|
| **Game 1: Disk Order Game** | 디스크를 올바른 순서로 고리에 던져 넣기 | `TargetChecker.cs` |
| **Game 2: Car Weight Game** | 자동차 중 가장 무거운 차량을 선택하기 | `CarGameManager.cs` |
| **Game 3: Animal Catch Game** | 동물 오브젝트를 잡아서 제거하기 | `AnimalGrabInteractable.cs`, `AnimalManager.cs` |
| **전체 관리** | 세 게임 모두 완료 시 “All Clear!” 표시 | `GameManager.cs` |