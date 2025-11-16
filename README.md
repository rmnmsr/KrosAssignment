# Kros Assignment - REST API pre organizačnú štruktúru firiem

REST API aplikácia pre správu 4-úrovňovej hierarchickej organizačnej štruktúry firiem a evidenciu zamestnancov.

## Hierarchická štruktúra

```
Firma (Company)
  └── Divízia (Division)
       └── Projekt (Project)
            └── Oddelenie (Department)
                 └── Zamestnanec (Employee)
```

Každý uzol organizačnej štruktúry má:
- Názov (Name)
- Kód (Code)
- Vedúceho (Leader) - zamestnanec

## Technológie

- **.NET 9.0** - Framework
- **ASP.NET Core Minimal APIs** - REST API
- **Entity Framework Core 9.0** - ORM
- **PostgreSQL** - Databáza
- **Scalar** - OpenAPI dokumentácia a testovanie

## Požiadavky

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://www.docker.com/get-started) (pre PostgreSQL databázu)

## Inštalácia a spustenie

### 1. Klonovanie repozitára

```bash
git clone <url-repozitára>
cd KrosAssignment
```

### 2. Spustenie PostgreSQL databázy

Použite Docker Compose na spustenie PostgreSQL kontajnera:

```bash
docker compose up -d
```

Tento príkaz spustí PostgreSQL databázu v Docker kontajneri s nasledujúcimi nastaveniami:
- **Host**: localhost
- **Port**: 5432
- **Database**: kros_assignment_db
- **Username**: postgres
- **Password**: supersecurepassword

Databáza sa automaticky vytvorí pri prvom spustení kontajnera.

### 3. Aplikovanie migrácií

```bash
dotnet restore
dotnet ef database update
```

### 4. Spustenie aplikácie

```bash
dotnet run
```

Aplikácia sa spustí na `http://localhost:5223`

### Zastavenie databázy

Keď chcete zastaviť PostgreSQL kontajner:

```bash
docker compose down
```

Ak chcete vymazať aj uložené dáta:

```bash
docker compose down -v
```

## API Dokumentácia

Po spustení aplikácie je k dispozícii interaktívna dokumentácia:

- **Scalar UI**: `http://localhost:5223/scalar/v1`

## Endpointy

### Companies (Firmy)

- `GET /api/companies` - Zoznam všetkých firiem
- `GET /api/companies/{id}` - Detail firmy
- `POST /api/companies` - Vytvorenie novej firmy
- `PUT /api/companies/{id}` - Aktualizácia firmy
- `DELETE /api/companies/{id}` - Vymazanie firmy

### Divisions (Divízie)

- `GET /api/divisions` - Zoznam všetkých divízií
- `GET /api/divisions/{id}` - Detail divízie
- `GET /api/divisions/by-company/{companyId}` - Divízie podľa firmy
- `POST /api/divisions` - Vytvorenie novej divízie
- `PUT /api/divisions/{id}` - Aktualizácia divízie
- `DELETE /api/divisions/{id}` - Vymazanie divízie

### Projects (Projekty)

- `GET /api/projects` - Zoznam všetkých projektov
- `GET /api/projects/{id}` - Detail projektu
- `GET /api/projects/by-division/{divisionId}` - Projekty podľa divízie
- `POST /api/projects` - Vytvorenie nového projektu
- `PUT /api/projects/{id}` - Aktualizácia projektu
- `DELETE /api/projects/{id}` - Vymazanie projektu

### Departments (Oddelenia)

- `GET /api/departments` - Zoznam všetkých oddelení
- `GET /api/departments/{id}` - Detail oddelenia
- `GET /api/departments/by-project/{projectId}` - Oddelenia podľa projektu
- `POST /api/departments` - Vytvorenie nového oddelenia
- `PUT /api/departments/{id}` - Aktualizácia oddelenia
- `DELETE /api/departments/{id}` - Vymazanie oddelenia

### Employees (Zamestnanci)

- `GET /api/employees` - Zoznam všetkých zamestnancov
- `GET /api/employees/{id}` - Detail zamestnanca
- `GET /api/employees/by-department/{departmentId}` - Zamestnanci podľa oddelenia
- `POST /api/employees` - Vytvorenie nového zamestnanca
- `PUT /api/employees/{id}` - Aktualizácia zamestnanca
- `DELETE /api/employees/{id}` - Vymazanie zamestnanca

## Testovanie

### Automatické testy (TeaPie)

Projekt obsahuje kompletnú sadu automatických testov v priečinku `Tests/`. Testy pokrývajú všetky endpointy a základné scenáre.

#### Inštalácia TeaPie

```bash
dotnet tool install -g TeaPie.Tool
```

#### Spustenie testov

Pred spustením testov uistite sa, že aplikácia beží na `http://localhost:5223`.

**Spustenie všetkých testov:**
```bash
teapie test ./Tests
```

**Spustenie konkrétnej testovacej kolekcie:**
```bash
# Testy pre Companies
teapie test ./Tests/001-Companies

# Testy pre Divisions
teapie test ./Tests/002-Divisions

# Testy pre Departments
teapie test ./Tests/003-Departments

# Testy pre Projects
teapie test ./Tests/004-Projects

# Testy pre Employees
teapie test ./Tests/005-Employees

# Kompletný hierarchický flow
teapie test ./Tests/006-Full-Hierarchy-Flow
```

**Spustenie konkrétneho testu:**
```bash
teapie test "./Tests/001-Companies/001-Create-Company-req.http"
```

### Interaktívne testovanie

Pre manuálne testovanie môžete použiť **Scalar UI** na `http://localhost:5223/scalar/v1`:
- Prezeranie všetkých dostupných endpointov
- Interaktívne testovanie API volaní
- Prezeranie schém dát a modelov
- Dokumentácia s príkladmi

## Validácie

API obsahuje nasledujúce validácie:

### Povinné polia
- **Company**: Code, Name
- **Division**: Code, Name, CompanyId
- **Project**: Code, Name, DivisionId
- **Department**: Code, Name, ProjectId
- **Employee**: Title, FullName, Phone, Email

### Biznis pravidlá
- Nemožno vymazať entitu, ktorá má závislosť na iných entitách
- Nemožno vymazať zamestnanca, ktorý je vedúcim
- LeaderId musí odkazovať na existujúceho zamestnanca
- Foreign keys (CompanyId, DivisionId, ProjectId, DepartmentId) musia odkazovať na existujúce entity
- Unikátne kódy (Code) pre Company, Division, Project a Department

## Testovanie

### Automatické testy (TeaPie)

Projekt obsahuje kompletnú sadu automatických testov v priečinku `Tests/`. Na spustenie testov použite nástroj **TeaPie**:

1. **Nainštalujte TeaPie**:
   ```bash
   dotnet tool install -g TeaPie.Tool
   ```

2. **Spustite všetky testy**:
   ```bash
   teapie test ./Tests
   ```

3. **Spustite konkrétnu skupinu testov**:
   ```bash
   teapie test ./Tests/001-Companies      # Testy pre Companies
   teapie test ./Tests/002-Divisions      # Testy pre Divisions
   teapie test ./Tests/003-Departments    # Testy pre Departments
   teapie test ./Tests/004-Projects       # Testy pre Projects
   teapie test ./Tests/005-Employees      # Testy pre Employees
   teapie test ./Tests/006-Full-Hierarchy-Flow  # End-to-end testy
   ```

4. **Spustite konkrétny test**:
   ```bash
   teapie test ./Tests/001-Companies/001-Create-Company-test.csx
   ```

### Interaktívne testovanie

Používajte nástroj **Scalar** na `http://localhost:5223/scalar/v1` pre:
- Prezeranie dostupných endpointov
- Testovanie API volaní
- Prezeranie schém dát
- Interaktívnu dokumentáciu

## Štruktúra projektu

```
KrosAssignment/
├── Data/
│   └── AppDbContext.cs          # Entity Framework DbContext
├── Models/
│   ├── Company.cs                # Model firmy
│   ├── Division.cs               # Model divízie
│   ├── Project.cs                # Model projektu
│   ├── Department.cs             # Model oddelenia
│   └── Employee.cs               # Model zamestnanca
├── Endpoints/
│   ├── CompanyEndpoints.cs       # API endpointy pre firmy
│   ├── DivisionEndpoints.cs      # API endpointy pre divízie
│   ├── ProjectEndpoints.cs       # API endpointy pre projekty
│   ├── DepartmentEndpoints.cs    # API endpointy pre oddelenia
│   └── EmployeeEndpoints.cs      # API endpointy pre zamestnancov
├── Migrations/                   # Entity Framework migrácie
├── Tests/                        # TeaPie automatické testy
│   ├── 001-Companies/            # Testy pre Companies
│   ├── 002-Divisions/            # Testy pre Divisions
│   ├── 003-Departments/          # Testy pre Departments
│   ├── 004-Projects/             # Testy pre Projects
│   ├── 005-Employees/            # Testy pre Employees
│   └── 006-Full-Hierarchy-Flow/  # End-to-end testy
├── Program.cs                    # Hlavný súbor aplikácie
├── appsettings.json              # Konfigurácia aplikácie
├── docker-compose.yml            # Docker Compose pre PostgreSQL
├── database_schema.sql           # SQL skript pre vytvorenie databázy
└── README.md                     # Táto dokumentácia
```

## Poznámky

- ID všetkých entít sú automaticky generované databázou (IDENTITY column)
- Všetky DELETE operácie kontrolujú závislosti pred vymazaním
- API vracia správne HTTP status kódy (200, 201, 400, 404, atď.)
- Chybové správy sú v slovenskom jazyku
- Databáza používa RESTRICT na všetkých foreign key obmedzeniach

## Autor

Roman Masár
