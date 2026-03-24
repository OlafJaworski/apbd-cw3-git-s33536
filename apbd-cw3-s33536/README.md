# Instrukcja uruchomienia
    1. otwórz projekt
    2. wciśnij F5 albo zielony trójkąt



### Opis i podział klas
    Projekt umożliwia wypożyczenie wybranego sprzętu przez danego użytkownika według mnie w nieskomplikowany i zwięzły sposób.
    Klasy zostały podzielone w sposób moim zdaniem bardzo prosty i zrozumiały, to znaczy wszystkie klasy związane 
    z użytkownikiem czyli User oraz dziedziczące po nim Student oraz Pracownik są w oddzielnym folderze, tak samo ze 
    sprzętem oraz klasą rental - wszystkie te klasy są tak naprawdę tylko kontenerami na dane, sama logika progamu jest w 
    oddzielnym folderze Services, a głównie klasie Service gdzie zachodzą wszystkie obliczenia związane z dodawaniem
    oraz zwracaniem przedmiotów. Jest również oddzielna klasa dla obsługiwania wyjątków takich jak np. próba wypożyczenia 
    przedmiotu który nie jest dostępny.