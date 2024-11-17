# Wymagania aplikacji Saper

## Wymagania funkcjonalne

### Gra Saper

- **Zasady gry**: Gra powinna bazowaæ na klasycznych zasadach gry Saper. Gracz odkrywa pola, próbuj¹c unikaæ min, a celem gry jest odkrycie wszystkich pól bez min.
  
- **Poziomy trudnoœci**:
  - **£atwy**: 10x10 plansza z 10 minami.
  - **Œredni**: 16x16 plansza z 40 minami.
  - **Trudny**: 24x24 plansza z 99 minami.
  
- **Interakcja gracza**:
  - Odkrywanie pola.
  - Oznaczanie pola jako zawieraj¹cego minê.
  - Reset gry.

- **System wygranej/przegranej**:
  - Wygrana, gdy wszystkie pola bez min zostan¹ odkryte.
  - Przegrana, gdy gracz odkryje pole z min¹.

### Warstwa logiki gry

- **Logika**:
  - Generowanie planszy, rozmieszczenie min, odkrywanie pól, oznaczanie min oraz obliczanie s¹siedztwa min (iloœæ min w otoczeniu danego pola).
  - Obs³uga wygranej i przegranej.
  - Mo¿liwoœæ resetowania planszy.
  - Mo¿liwoœæ prze³¹czania poziomów trudnoœci.

### Warstwa wizualna – tryb tekstowy

- **Interfejs konsolowy**:
  - Oparty na Spectre.Console.
  - Przedstawienie planszy za pomoc¹ tekstu (X dla nieodkrytych pól, liczby dla odkrytych pól wskazuj¹ce liczbê s¹siaduj¹cych min, M dla oznaczonego pola z min¹).
  - Mo¿liwoœæ poruszania siê po planszy i zaznaczania pól.
  - Wyœwietlanie wyników gry w formie tekstowej (wygrana/przegrana).

### Warstwa wizualna – tryb graficzny

- **Interfejs graficzny**:
  - Prosty graficzny interfejs u¿ytkownika.
  - Graficzne przedstawienie planszy (kwadraty dla pól, liczby dla odkrytych pól, symbole min i oznaczeñ).
  - Podœwietlanie aktywnego pola.
  - Obs³uga myszki do odkrywania/oznaczania pól.
  - Animacje podœwietlaj¹ce wygran¹ lub przegran¹.

## Wymagania techniczne

### Platforma

- Aplikacja powinna byæ napisana w .NET 8.
- Zastosowanie wzorca projektowego MVC lub MVVM dla oddzielenia logiki od warstwy wizualnej.

### Warstwa logiki (backend)

- **Jêzyk**: C#.
- Odpowiedzialna za ca³¹ logikê gry, w tym:
  - Generowanie planszy i rozmieszczenie min.
  - Obs³uga odkrywania pól i oznaczania min.
  - Sprawdzanie warunków wygranej/przegranej.
- Ta czêœæ bêdzie niezale¿na od sposobu prezentacji danych, co umo¿liwi ponowne wykorzystanie logiki zarówno w wersji konsolowej, jak i graficznej.

### Warstwa wizualna – tryb tekstowy

- **Biblioteka**: Spectre.Console - framework umo¿liwiaj¹cy tworzenie bogatych aplikacji konsolowych w trybie tekstowym.
  
- **Funkcje**:
  - Interaktywna obs³uga u¿ytkownika.
  - Dynamiczne odœwie¿anie planszy.
  - Mo¿liwoœæ poruszania siê po planszy za pomoc¹ strza³ek i zaznaczania pól.

### Warstwa wizualna – tryb graficzny

- **Proponowana biblioteka**: WPF - framework graficzny dla .NET, który pozwala tworzyæ aplikacje na systemy Windows

- **Zalety WPF**:
  - Intuicyjny system XAML do definiowania interfejsów u¿ytkownika.
  - Obs³uga myszki i klawiatury.
  - Nowoczesne, lekkie animacje.
