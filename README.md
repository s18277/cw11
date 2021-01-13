# cw11
## Paweł Rutkowski s18277
Modele reprezentujące bazę danych z treści zadania można znaleźć w podkatalogu `Cw11/Models/`.
Znajduje się tam również kontekst bazy danych `Cw11.Models.ClinicDbContext`.

Kontekst wykorzystuje zewnętrzne klasy konfigurujące strukturę tabel (zamiast adnotacji w modelach).
Klasy te można znaleźć w podkatalogu `Cw11/Configurations/`.

W kontekście można znaleźć również metodę pomocniczą seedujacą bazę danymi
`Cw11.Models.ClinicDbContext.SeedDataToDb`.

Kontroler obsługujący zapytania pod ścieżką `api/doctors` to `Cw11.Controllers.DoctorsController`.
Zapewnia on 5 końcówek:
* Pobranie informacji o wszystkich studentach - zapytanie `HTTP GET` na ścieżkę `api/doctors`
* Pobranie informacji o jednym studencie - zapytanie `HTTP GET` na ścieżkę `api/doctors/{id}`
* Dodanie nowego studenta - zapytanie `HTTP POST` na ścieżkę `api/doctors`
* Modyfikacja studenta - zapytanie `HTTP PUT` na ścieżkę `api/doctors/{id}`
* Usunięcie studenta - zapytanie `HTTP DELETE` na ścieżkę `api/doctors/{id}`

Komunikacja z bazą danych jest realizowana przez serwis - interfejs `Cw11.Services.IClinicDbService`
i jego implementację `Cw11.Services.EfcClinicDbService`. Implementacja ta wykorzystuje `Entity
Framework Core` i `LINQ`.

W repozytorium znajdują się również dwie migracje:
* `InitialModelsAndConfigurations` - struktura tabel
* `SeedData` - dodanie przykładowych danych do bazy