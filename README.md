# Hitomi Copy Source Tree

## Contact us

Mail to koromo.software@gmail.com

## Download

Hitomi, Ex-Hentai, Marumaru Intergration downloader

https://github.com/dc-koromo/hitomi-downloader-2/releases/tag/3.26

## History

### Alpha Version 
![hitomi history](Docs/Image2/1.png)

### Version 1.0
![hitomi history](Docs/Image2/2.png)

### Version 2.0
![hitomi history](Docs/Image2/3.png)

![hitomi history](Docs/Image2/4.png)

### Version 3.0
![hitomi history](Docs/Image2/5.png)

![hitomi history](Docs/Image2/6.png)

----------------------------------------------------------------------

# Hitomi Copy엔 이런 기능들이 있습니다 (꼭 읽어주세요)

따로 설명서를 만든적이 없어 기능들 중의 일부만을 사용하고 계셨을 것 같습니다. 따라서 이번 기회에 모든 기능들을 설명하고자합니다.

## 마루마루 다운로더
마루마루 만화주소를 붙여넣으면 자동으로 마루마루 만화를 다운로드합니다. (Protected된 만화는 못 뚫어요) 2.0버전부터 있던 기능인데 모르셨던 분들 많을 것같습니다. 다운로드된 만화는 프로그램이 있는 폴더에 저장됩니다. 다운로드 과정이 자세히 표시되지 않으니, UsingLog와 같이 사용하세요.

## 익헨 다운로더
익헨 주소를 붙여넣으면 자동으로 익헨 갤러리를 다운로드합니다. 이것도 2.0 버전부터 있던겁니다.

## 통계 기능
이 다운로더는 2.0버전부터 통계기능을 지원했으나 3.0버전에선 최근에 다시 추가한 기능입니다. 설정-통계 버튼을 통해 히토미 트렌드, 다운로드 통계 정보 등을 볼 수 있습니다.

## 갤러리 더블 클릭
검색창에서 갤러리를 더블클릭하면 자세한 정보를 볼 수 있습니다. 작가별, 그룹별, 태그별 등으로 색인된 결과를 볼 수 있습니다.

## 검색창에선 모든 정보가 표시되는 것이 아닙니다!
히토미 DB가 업데이트가 되지 않아 표시되지 않는 항목도 많이 존재합니다. 작가별, 그룹별 창은 DB를 사용하는 것이 아닌 히토미 사이트에서 직접 목록을 가져오므로 모든 결과가 표시됩니다. 단일 작가나 단일 그룹을 모두 다운로드 하려면 검색창에서 갤러리 더블 클릭을 통해 작가별, 그룹별 색인 결과로 모두 다운로드하세요.

----------------------------------------------------------------------

# 고급기능 사용법

여기선 UsingLog를 사용하여 구현되지 않은 기능을 수행하는 방법을 알려드립니다.

## 커스텀 작가 추천

작가 추천 목록을 커스티마이징하는 방법을 알아봅시다.
먼저 다음 명령을 순서대로 입력합니다.

```
; 커스텀 분석 시작 (ra off 도 구현됨)
ra on
; 커스텀 태그에 추가된 것들이 모두 작품에 있을 때만 작가 추천항목에 넣음 (ra mioff 도 구현됨)
ra mion
; 작가 추천 목록 업데이트
ra update
```

이제 원하는 태그나 작가를 추가합니다.

```
; 태그 추가 (마지막 숫자는 점수)
ra + female:big_breasts 1
; 작가 추가 (작가가 가진 모든 태그를 추가함)
ra +a hisasi
```

다음은 목록을 생성하는데 유용한 명령어 입니다.

```
; 수동으로 작가 추가
ra add sekiya_asami
; 모든 커스텀 태그 열거
ra list
; 점수 내림차순으로 작가 추천 목록 열거 (ra update가 먼저 수행되어야 합니다.)
ra rank
; 점수 오름차순으로 작가 추천 목록 열거 (ra update가 먼저 수행되어야 합니다.)
get hitomi_analysis
; 커스텀 태그 모두 삭제
ra clear
```
