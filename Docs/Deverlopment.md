# Hitomi Copy 개발 문서

이 문서엔 히토미 카피를 제작하기 위해 사용한 모든 방법을 정리하고 있는 문서입니다.

## 아티클 관리

아티클은 작품을 구성하는 기본단위입니다. 인터페이스는 `IArticle`이며, `HitomiArticle`, `MMArticle`처럼 쓰입니다. 아티클에는 제목, 식별아이디, 이미지 링크가 필수로 포함되어야 합니다. UI 면에서 아티클 관리는 별도의 기능으로 이루어질 예정입니다.

## 세마포어 관리

이미지 다운로드를 위한 세마포어로 `DriverQueue`와 `DownloadQueue` 두 개가 있습니다. `DriverQueue`는 다중 프로세스로, `DownloadQueue`는 다중 쓰레드로 작업합니다. 추후 동영상 세마포어를 추가해야될 상황이 생기면 `MovieQueue`로 구현할 것입니다.

## 적절한 비동기 처리가 아닌데도 async 키워드가 포함된 경우

정확한 이유는 알 수 없지만, async의 유무에 따라 성능에 차이가 생긴다. 따라서 async 키워드가 필요없는 상황임에도 async 키워드를 남겨둔 경우가 있다.

## UI 업데이트

모든 UI 업데이트는 `Post` 함수를 사용한다. `Post` 함수는 `Foreign.cs`에 포함되어 있다.

## Virtual UI

UI Virtualization의 구현으로, 핸들을 통합 관리한다. 많은 핸들이 존재할 경우 User Objects 제한으로 프로그램이 강제종료될 수 있으므로 상위 핸들로 통합해 하나의 핸들로 보이게 끔 만든다. 컨트롤 이벤트 전달 방식은 현재 완전탐색으로 구현되어있다.

## 플러그인 방식

새로운 다운로더를 추가하려면 많은 공간이 필요한 경우가 있다. 또한 사용자가 편리하게 다운로더를 추가할 수 있게끔 플러그인 기능을 검토할 계획이다. 잘 만들어진 플러그인의 경우 메인 프로그램에 포함될 수 있다.

## 사용하는 오픈소스 라이브러리

|이름|사용|주소|
|---|---|---|
|Html Agility Pack|Html 웹 브라우저 소스를 파싱할 때 사용함|http://html-agility-pack.net/|
|Metro Modern UI|히토미 카피 기본 UI|https://github.com/dennismagno/metroframework-modern-ui|
|Newtonsoft.Json|json 파일관리를 위해 사용함|https://www.newtonsoft.com/json|
|Pixeez|픽시브 다운로더 구현에 사용함|https://github.com/cucmberium/Pixeez|

## 소스코드 참조

|이름|사용|주소|
|---|---|---|
|LibHitomi|Gallery Block 구조 참조|https://github.com/LiteHell/LibHitomi|