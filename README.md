# Saper - Gra w .NET 8

## Opis projektu

Jest to implementacja klasycznej gry Saper, napisanej w .NET 8. Aplikacja zosta�a podzielona na trzy g��wne warstwy:

1. **Warstwa logiki gry** � Odpowiedzialna za mechanik� gry, generowanie planszy oraz obs�ug� warunk�w wygranej i przegranej.
   
2. **Warstwa tekstowa** � Interfejs u�ytkownika oparty na trybie tekstowym, zrealizowany z u�yciem [Spectre.Console](https://spectreconsole.net/).
   
3. **Warstwa graficzna** � Interfejs graficzny stworzony za pomoc� [Avalonia UI](https://avaloniaui.net/).

## Wymagania

Aby uruchomi� projekt, potrzebne s� nast�puj�ce narz�dzia:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Spectre.Console](https://spectreconsole.net/) � do obs�ugi tekstowego interfejsu u�ytkownika.
- [Avalonia UI](https://avaloniaui.net/) � do stworzenia interfejsu graficznego.
- [MessageBox.Avalonia](https://www.nuget.org/packages/MessageBox.Avalonia) � do obs�ugi okien dialogowych w interfejsie graficznym.

## Instalacja

1. Pobierz i zainstaluj .NET 8 SDK:

   [Pobierz .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)

2. Zainstaluj wymagane biblioteki za pomoc� NuGet:

``` bash
   dotnet add package Spectre.Console
   dotnet add package Avalonia
   dotnet add package MessageBox.Avalonia
```

## Uruchomienie aplikacji

1. Skonfiguruj projekt w �rodowisku IDE (np. Visual Studio) lub za pomoc� wiersza polece�.
   
2. Aby uruchomi� wersj� graficzn� gry, uruchom aplikacj� za pomoc� interfejsu graficznego Avalonia UI.

3. Aby uruchomi� wersj� tekstow�, uruchom aplikacj� w trybie konsolowym, kt�ry korzysta z biblioteki Spectre.Console.

## Struktura projektu

Projekt jest podzielony na trzy g��wne komponenty:

1. **Warstwa logiki gry** � Odpowiada za mechanik� i regu�y gry, takie jak rozmieszczenie min, odkrywanie p�l, oznaczanie min oraz sprawdzanie warunk�w wygranej i przegranej.

2. **Warstwa tekstowa** � Umo�liwia gr� w trybie tekstowym w konsoli, wykorzystuj�c bibliotek� Spectre.Console. Obs�uguje wy�wietlanie planszy oraz interakcje z u�ytkownikiem.

3. **Warstwa graficzna** � Zawiera interfejs u�ytkownika w formie graficznej stworzony za pomoc� Avalonia UI, zapewniaj�c bardziej wizualne i interaktywne �rodowisko gry.
