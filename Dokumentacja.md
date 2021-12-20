## 1 Opis projektu (główne założenia, jaki jest cel i istota aplikacji)
Projekt zakładał stworzenie gry z gatunku roguelike, w której gracz poruszałby się po generowanych losowo lochach zwiedzając kolejne pokoje i pokonując znajdujących się w nich przeciwników. Pokonani przeciwnicy dają graczowi punkty doświadczenia potrzebne do zdobycia poziomu. Zdobyte poziomy pozwalają wzmocnić statystyki bohatera. Po pokonaniu przeciwników w lochu, gracz przechodzi do następnego poziomu. Gra nie posiada fabuły ani zakończenia, a po przegranej zaczyna się ją od początku. W przeciwieństwie do wersji poprzedniej, wersja Unity posiada również warstwę graficzną w stylu pixelart oraz podstawowe animacje.
## 2 Opis funkcjonalności (wymienione główne funkcjonalności oraz ich omówienie)
a) Generowanie losowego układu pokoi w lochu z losowymi zdarzeniami w pokojach – przy każdym rozpoczęciu nowej gry gracz otrzymuje unikatowe doświadczenie którego prawdopodobnie nie uda się powtórzyć przy kolejnych podejściach <br />
b) System permanentnej śmierci – gra nie posiada opcji zapisu a każde podejście zaczyna się od pierwszego poziomu postaci i pierwszego lochu <br />
c) Możliwość rozwoju bohatera poprzez statystyki – wprowadzenie elementu strategicznego pozwalającego graczowi budować postać i wypróbowywać różne podejścia do gry <br />

## 3 Opis realizacji zmiany warstwy prezentacji z wyszczególnieniem oddzielenia od niej logiki aplikacji
W ramach adaptowania kodu do Unity udało się zachować go w stanie niemalże nie naruszonym (a przynajmniej API pozostało nienaruszone). Jedyne pliki które uległy zmianie to:
- Core/Stats_Prototype.cs - gdzie wszystkie własności trzeba było przerobić na pola (praktycznie nie wpłynęło to na wykorzstanie ich w kodzie) i dorzucić atrybut [System.Serializable] ponieważ Unity korzysta z innej biblioteki do obsługiwania JSON'ów niż .NET która wymagała tych zmian,
- Core/EnemyData.cs - ten plik został dodany na potrzeby serializacji danych z JSON'a (serializator używany przez Unity nie wspiera bezpośrednio takich struktur jak listy),
- Core/EnemyList.cs - w tym pliku należało kompletnie przerobić implementację operacji I/O żeby mogło być zintegrowane z Unity,
- Core/RunSummary.cs - dorzuciliśmy metodę statyczną Reset(), po to by można było resetować podsumowanie, bez potrzeby wyłączania gry.

Do tego by ułatwić używanie klas i struktur namespace'a Croisant_Crawler.Data stworzyliśmy klasę rozszerzeń Vector2_Extensions która zajmuje się tłumaczeniem struktur Unity na struktury obecne w namespace'ie Data i spowrotem.

Żeby sprawić, by kod działał w środowisku Unity wymagane było stworzenie wrapperów na klasy zawarte w namespace'ie Core (załóżmy klasa Enemy jest wrapperem na Core.Stats), które to zajmują się wyświetlaniem grafiki, oraz przyjmowaniem i tłumaczeniem wiadomości od Unity.

Poza tym do wyświetlania statystyk gracza i przeciwników także i w tym projekcie wykorzystaliśmy podejście event-driven, gdzie poszczególne elementy UI same subskrybują do zmian w statystykach i zmieniają swój wygląd.

## 4 Szczególnie interesujące zagadnienia projektowe (problemy, z jakimi zmierzyli się programiści, sposób ich rozwiązania, ciekawe fragmenty kodu itp.)
Przeniesienie projektu z konsolowej aplikacji na pełnoprawnę grę na silniku Unity wiązało się z paroma wyzwaniami aby gra działała na "backendzie" zapisanym w naszym Core z poprzedniego projektu.

Unity jest silnikiem prostym i intuicyjnym do robienia w nim gier, jednak jest też dość sztywny i przenoszenie projektu napisanego w innej technologii bywa uciążliwe. Załóżmy Unity nie wspiera wszystkich bibliotek .NET, załóżmy żeby zrobić ładowanie przeciwników z pliku .json musieliśmy mocno przerobić klasę EnemyList i Stats_Prototype, by działały w sposób jaki oczekuje od nich Unity.

Jeśli chodzi o samo użycie Unity, chyba największym problemem było właśnie dodanie animacji, jednak z pomocą internetowego poradnika udało się osiągnąć zadowalający efekt.

Żeby ułatwić zarządzanie wieloma podwidokami w widoku głównym aplikacji stworzyliśmy klasę singleton ViewManager, w której to zastosowaliśmy stos widoków który to pozwala na bardzo łatwe dodawanie i otwieranie nowych widoków. Nad czym ubolewamy, to że Unity nie wspiera krotek w edytorze, wtedy moglibyśmy nowe widoki dodawać do listy w której bym przechowywał ich enuma skorelowanego z tym widokie, tak musiałem je dodawać ręcznie. Można to było obejść tworząc nową strukturę przechowującą 2 elementy zamiast krotki, ale to wiąże się z innymi problemami, więc z racji na ograniczony czas, ostatecznie poprzestaliśmy na hard-code'owanym podejściu.

## 5 Instrukcja instalacji (komplet wiedzy potrzebnej użytkownikowi do zainstalowania aplikacji)
Aby odpalić grę, należy pobrać z zakładki Releases na GitHub'ie archiwum z nazwą systemu który używamy, po pobraniu rozpakować. Grę uruchamiamy za pomocą pliku wykonywalnego wewnątrz.

## 6 Instrukcja konfiguracji (jeśli użytkownik potrzebuje wykonać dodatkowe czynności niezwiązane z instalacją, np. stworzenie i wypełnienie pliku konfiguracyjnego, stworzenie katalogu tymczasowego na dysku itp.)
Nie jest wymagana żadna dodatkowa konfiguracja, gra jest gotowa do użycia.

## 7 Instrukcja użytkownika (komplet wiedzy potrzebnej użytkownikowi do efektywnego korzystania z aplikacji),
Gra wita gracza ekranem startowym. Aby rozpocząć nową grę, należy wybrać i kliknąć przycisk "New Game"
Poruszanie postacią po mapie odbywa się za pomocą klawiszy WSAD
W trybie mapy możemy wejść do okna rozwoju postaci za pomocą Q (i tak samo z niego wychodzimy).
W oknie rozwoju postaci możemy ulepszać 3 statystyki postaci za pomocą przycisków widocznych na ekranie.
Z walki można wyjść dopiero po jej ukończeniu (nie zależnie od wyniku).
W czasie walki wybieramy cel ataku za pomocą klawiszy W i S, oraz atakujemy przy pomocy D.
W każdym momencie możemy wyjść z gry, lub zresetować obecne podejście wchodząc w menu za pomocą klawisza Escape.

## 8 Wnioski
Unity to świetne narzędzie do robienia gier kiedy robimy je w Unity od początku. Oferuje masę prostych i intuicyjnych rozwiązań, darmowe assety i pomocne bibliioteki umożliwiające szybką i wygodną implementację wielu podstawowych funkcji. Niestety, Unity nie jest zbyt przyjazne kiedy próbujemy przenieść do niego gotowy projekt wykonany w innej technologii. Sztywnośc pewnych rozwiązań jest kosztem, jaki Unity ponosi za bycie prostym w obsłudze i szybkim w nauce.

## 9 Samoocena
Uważamy, że nasza gra spełnia większość założeń przedstawionych w wymaganiach projektowych. Posiada nawet szczątkowe animacje (animacja bohatera w HeroTab'ie, oraz animacje kamery). W trakcie gry można przenosić się między widokiem mapy i statystyk zarówno korzystając z klawiatury jak i myszy.


<style>
body{
    /* That Comic Sans is here in case you don't have my favourite font :< */
    /* font-family: Consolas, Comic Sans; */
    font-family: Consolas;
    margin-left: 10%;
    margin-right: 10%;
}
</style>