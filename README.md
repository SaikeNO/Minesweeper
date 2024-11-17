# Saper - Gra w .NET 8

## Opis projektu

Jest to implementacja klasycznej gry Saper, napisanej w .NET 8. Aplikacja zosta³a podzielona na trzy g³ówne warstwy:

1. **Warstwa logiki gry** – Odpowiedzialna za mechanikê gry, generowanie planszy oraz obs³ugê warunków wygranej i przegranej.
   
2. **Warstwa tekstowa** – Interfejs u¿ytkownika oparty na trybie tekstowym, zrealizowany z u¿yciem [Spectre.Console](https://spectreconsole.net/).
   
3. **Warstwa graficzna** – Interfejs graficzny stworzony za pomoc¹ [WPF](https://learn.microsoft.com/pl-pl/dotnet/desktop/wpf/?view=netdesktop-8.0).

## Wymagania

Aby uruchomiæ projekt, potrzebne s¹ nastêpuj¹ce narzêdzia:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Spectre.Console](https://spectreconsole.net/) – do obs³ugi tekstowego interfejsu u¿ytkownika.
- [WPF](https://learn.microsoft.com/pl-pl/dotnet/desktop/wpf/?view=netdesktop-8.0) – do stworzenia interfejsu graficznego.

## Instalacja

1. Pobierz i zainstaluj .NET 8 SDK:

   [Pobierz .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)


## Uruchomienie aplikacji

1. Skonfiguruj projekt w œrodowisku IDE (np. Visual Studio) lub za pomoc¹ wiersza poleceñ.
   
2. Aby uruchomiæ wersjê graficzn¹ gry, uruchom aplikacjê za pomoc¹ interfejsu graficznego WPF.

3. Aby uruchomiæ wersjê tekstow¹, uruchom aplikacjê w trybie konsolowym, który korzysta z biblioteki Spectre.Console.

## Struktura projektu

Projekt jest podzielony na trzy g³ówne komponenty:

1. **Warstwa logiki gry** – Odpowiada za mechanikê i regu³y gry, takie jak rozmieszczenie min, odkrywanie pól, oznaczanie min oraz sprawdzanie warunków wygranej i przegranej.

2. **Warstwa tekstowa** – Umo¿liwia grê w trybie tekstowym w konsoli, wykorzystuj¹c bibliotekê Spectre.Console. Obs³uguje wyœwietlanie planszy oraz interakcje z u¿ytkownikiem.

3. **Warstwa graficzna** – Zawiera interfejs u¿ytkownika w formie graficznej stworzony za pomoc¹ WPF, zapewniaj¹c bardziej wizualne i interaktywne œrodowisko gry.
