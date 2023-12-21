# Unity17TeamProject
 ## 유니티 숙련주차 17조 팀프로젝트 스랜디(스파르타 랜덤 디펜스)

 ## ❤️개발환경 / 에셋소스
Unity Ver: 2022.3.2f1<br/><br/>
IDE: VS Code<br/><br/>
개발기간: 12월 15일 ~ 12월 20일<br/><br/>

<br/><br/>
## 🧡Wireframe
![image](https://github.com/Leejungsuk96/Unity17TeamProject/assets/114940193/92651874-950d-48a4-9d6f-0b3e6aee97fb)
<br/><br/>
타워 로직<br/><br/>
![image](https://github.com/Leejungsuk96/Unity17TeamProject/assets/114940193/b26d94f9-7409-4b15-981c-e77cf7be86f7)
<br/><br/>
적 로직<br/><br/>
![image](https://github.com/Leejungsuk96/Unity17TeamProject/assets/114940193/d1e6a50a-1e69-4d69-8027-1fec206f26d8)


<br/><br/>
## 💚팀원 역할 분담
![image](https://github.com/Leejungsuk96/Unity17TeamProject/assets/114940193/e407d35c-0262-4a29-b033-db3e64f71ff9)
<br/><br/>
GitHub관리<br/><br/>
![image](https://github.com/Leejungsuk96/Unity17TeamProject/assets/114940193/b2c995df-e482-4de2-9860-c7cf6bc488b6)


<br/><br/>
## 💙주요기능
타워가 고정되어있는것이 아니라 움직이면서 몬스터를 때리는것과몬스터가 죽게되면 보상을 주고 보상으로 또다른 타워를 구매할수있는것<br/><br/>
생성된 적이 맵을 무한으로 돌 수 있게 하는 것<br/><br/>
적과 본인의 건물에 SO적용, 아군타워 설치 및 설치물 이동,  공격관련 스텟 계산,  SO 를 통한 스크립트 설정, 골드획득<br/><br/>


## 💜문제 및 해결
게임 특성상 타워가 공격헀을 때 빗나가면 안되는데 빗나가는 경우 발생 OverlapCircleAll을 사용해서 총알이 목표 Transform으로 이동할 수 있게 해주었다.<br/><br/>
병합 과정에서 발생한 충돌을 게임매니저의 상속과 오버라이딩을 통해 해결
