# Wymagania aplikacji Saper

## Wymagania funkcjonalne

### Gra Saper

- **Zasady gry**: Gra powinna bazowa� na klasycznych zasadach gry Saper. Gracz odkrywa pola, pr�buj�c unika� min, a celem gry jest odkrycie wszystkich p�l bez min.
  
- **Poziomy trudno�ci**:
  - **�atwy**: 10x10 plansza z 10 minami.
  - **�redni**: 16x16 plansza z 40 minami.
  - **Trudny**: 24x24 plansza z 99 minami.
  
- **Interakcja gracza**:
  - Odkrywanie pola.
  - Oznaczanie pola jako zawieraj�cego min�.
  - Reset gry.

- **System wygranej/przegranej**:
  - Wygrana, gdy wszystkie pola bez min zostan� odkryte.
  - Przegrana, gdy gracz odkryje pole z min�.

### Warstwa logiki gry

- **Logika**:
  - Generowanie planszy, rozmieszczenie min, odkrywanie p�l, oznaczanie min oraz obliczanie s�siedztwa min (ilo�� min w otoczeniu danego pola).
  - Obs�uga wygranej i przegranej.
  - Mo�liwo�� resetowania planszy.
  - Mo�liwo�� prze��czania poziom�w trudno�ci.

### Warstwa wizualna � tryb tekstowy

- **Interfejs konsolowy**:
  - Oparty na Spectre.Console.
  - Przedstawienie planszy za pomoc� tekstu (X dla nieodkrytych p�l, liczby dla odkrytych p�l wskazuj�ce liczb� s�siaduj�cych min, M dla oznaczonego pola z min�).
  - Mo�liwo�� poruszania si� po planszy i zaznaczania p�l.
  - Wy�wietlanie wynik�w gry w formie tekstowej (wygrana/przegrana).

### Warstwa wizualna � tryb graficzny

- **Interfejs graficzny**:
  - Prosty graficzny interfejs u�ytkownika.
  - Graficzne przedstawienie planszy (kwadraty dla p�l, liczby dla odkrytych p�l, symbole min i oznacze�).
  - Pod�wietlanie aktywnego pola.
  - Obs�uga myszki do odkrywania/oznaczania p�l.
  - Animacje pod�wietlaj�ce wygran� lub przegran�.

## Wymagania techniczne

### Platforma

- Aplikacja powinna by� napisana w .NET 8.
- Zastosowanie wzorca projektowego MVC lub MVVM dla oddzielenia logiki od warstwy wizualnej.

### Warstwa logiki (backend)

- **J�zyk**: C#.
- Odpowiedzialna za ca�� logik� gry, w tym:
  - Generowanie planszy i rozmieszczenie min.
  - Obs�uga odkrywania p�l i oznaczania min.
  - Sprawdzanie warunk�w wygranej/przegranej.
- Ta cz�� b�dzie niezale�na od sposobu prezentacji danych, co umo�liwi ponowne wykorzystanie logiki zar�wno w wersji konsolowej, jak i graficznej.

### Warstwa wizualna � tryb tekstowy

- **Biblioteka**: Spectre.Console - framework umo�liwiaj�cy tworzenie bogatych aplikacji konsolowych w trybie tekstowym.
  
- **Funkcje**:
  - Interaktywna obs�uga u�ytkownika.
  - Dynamiczne od�wie�anie planszy.
  - Mo�liwo�� poruszania si� po planszy za pomoc� strza�ek i zaznaczania p�l.

### Warstwa wizualna � tryb graficzny

- **Proponowana biblioteka**: WPF - framework graficzny dla .NET, kt�ry pozwala tworzy� aplikacje na systemy Windows

- **Zalety WPF**:
  - Intuicyjny system XAML do definiowania interfejs�w u�ytkownika.
  - Obs�uga myszki i klawiatury.
  - Nowoczesne, lekkie animacje.
