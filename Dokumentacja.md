## 1 Opis projektu (główne założenia, jaki jest cel i istota aplikacji)
Projekt zakładał stworzenie gry z gatunku roguelike, w której gracz poruszałby się po generowanych losowo lochach zwiedzając kolejne pokoje i pokonując znajdujących się w nich przeciwników. Pokonani przeciwnicy dają graczowi punkty doświadczenia potrzebne do zdobycia poziomu i przedmioty. Przedmioty oraz zdobyte poziomy pozwalają wzmocnić statystyki bohatera. Po pokonaniu przeciwników w lochu, gracz przechodzi do następnego poziomu. Gra nie posiada fabuły ani zakończenia a po przegranej zaczyna się ją od początku. W przeciwieństwie do wersji poprzedniej, wersja Unity posiada również warstwę graficzną w stylu pixelart oraz podstawowe animacje.
## 2 Opis funkcjonalności (wymienione główne funkcjonalności oraz ich omówienie)
a) Generowanie losowego układu pokoi w lochu z losowymi zdarzeniami w pokojach – przy każdym rozpoczęciu nowej gry gracz otrzymuje unikatowe doświadczenie którego prawdopodobnie nie uda się powtórzyć przy kolejnych podejściach <br />
b) System permanentnej śmierci – gra nie posiada opcji zapisu a każde podejście zaczyna się od pierwszego poziomu postaci i pierwszego lochu <br />
c) Możliwość rozwoju bohatera poprzez statystyki i przedmioty – wprowadzenie elementu strategicznego pozwalającego graczowi budować postać i wypróbowywać różne podejścia do gry <br />

## 3 Szczególnie interesujące zagadnienia projektowe (problemy, z jakimi zmierzyli się programiści, sposób ich rozwiązania, ciekawe fragmenty kodu itp.)
Przeniesienie projektu z konsolowej aplikacji na pełnoprawnę grę na silniku Unity wiązało się z paroma wyzwaniami aby gra działała na "backendzie" zapisanym w naszym Core z poprzedniego projektu.<br />
Przykładowym problemem był brak możliwości wykorzystania wcześniej napisanych skryptów w sposób bezpośredni, gdyż nie obsługiwały one bibliotek Unity. Ten problem udało się rozwiązać używając delegatów w skryptach Unity.<br />
Unity jest silnikiem prostym i intuicyjnym do robienia w nim gier, jednak jest też dość sztywny i przenoszenie projektu napisanego w innej technologii bywa uciążliwe.
Jeśli chodzi o samo użycie Unity, chyba największym problemem było właśnie dodanie animacji, jednak z pomocą internetowego poradnika udało się osiągnąć zadowalający efekt.

## 4 Instrukcja instalacji (komplet wiedzy potrzebnej użytkownikowi do zainstalowania aplikacji)
Aby odpalić grę, należy pobrać i uruchomić plik Croissant_Crawler.exe.

## 5 Instrukcja konfiguracji (jeśli użytkownik potrzebuje wykonać dodatkowe czynności niezwiązane z instalacją, np. stworzenie i wypełnienie pliku konfiguracyjnego, stworzenie katalogu tymczasowego na dysku itp.)
Nie jest wymagana żadna dodatkowa konfiguracja, gra jest gotowa do użycia. Można jednak wejść w opcje aby zmienić rozdzielczość na preferowaną.

## 6 Instrukcja użytkownika (komplet wiedzy potrzebnej użytkownikowi do efektywnego korzystania z aplikacji),
Gra wita gracza ekranem startowym. Aby rozpocząć nową grę, należy wybrać i kliknąć przycisk "New Game"
Poruszanie postacią po mapie odbywa się za pomocą klawiszy WSAD
W trybie mapy możemy wejść do okna rozwoju postaci za pomocą Q (i tak samo z niego wychodzimy).
W oknie rozwoju postaci możemy ulepszać 3 statystyki postaci za pomocą przycisków widocznych na ekranie.
Z walki można wyjść dopiero po jej ukończeniu (nie zależnie od wyniku).
W czasie walki wybieramy cel ataku za pomocą klawiszy W i S, oraz atakujemy przy pomocy D.

## 7 Wnioski
Unity to świetne narzędzie do robienia gier kiedy robimy je w Unity od początku. Oferuje masę prostych i intuicyjnych rozwiązań, darmowe assety i pomocne bibliioteki umożliwiające szybką i wygodną implementację wielu podstawowych funkcji. Niestety, Unity nie jest zbyt przyjazne kiedy próbujemy przenieść do niego gotowy projekt wykonany w innej technologii. Sztywnośc pewnych rozwiązań jest kosztem, jaki Unity ponosi za bycie prostym w obsłudze i szybkim w nauce.

## 8 Samoocena
Uważamy, że nasza gra spełnia większość założeń przedstawionych w wymaganiach projektowych. Posiada animacje i możliwość dostosowania rozdzielczości ekranu. W trakcie gry można przenosić się między widokiem mapy i statystyk zarówno korzystając z klawiatury jak i myszy.


<style>
body{
    /* That Comic Sans is here in case you don't have my favourite font :< */
    /* font-family: Consolas, Comic Sans; */
    font-family: Consolas;
    margin-left: 10%;
    margin-right: 10%;
}
</style>