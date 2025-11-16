# API Tests - TeaPie

Testy pre Kros Assignment API vytvorené pomocou [TeaPie](https://github.com/Kros-sk/TeaPie) frameworku.

## Inštalácia TeaPie

```bash
dotnet tool install -g TeaPie.Tool
```

## Spustenie testov

### Všetky testy
```bash
teapie test ./Tests
```

### Konkrétna kolekcia (napr. Company testy)
```bash
teapie test ./Tests/001-Companies
```

### Konkrétny test
```bash
teapie test "./Tests/001-Companies/001-Create-Company-req.http"
```

## Štruktúra testov

```
Tests/
├── env.json                    # Environment variables
├── 001-Companies/              # Company endpoint testy
│   ├── 001-Create-Company-req.http
│   ├── 001-Create-Company-test.csx
│   ├── 002-Get-All-Companies-req.http
│   └── ...
├── 002-Divisions/              # Division endpoint testy
├── 003-Departments/            # Department endpoint testy
├── 004-Projects/               # Project endpoint testy
└── 005-Employees/              # Employee endpoint testy
```

## Konvencie

- **`-req.http`**: HTTP request súbor
- **`-init.csx`**: Pre-request script (setup)
- **`-test.csx`**: Post-response script (validácia/testy)

## Premenné

Testy používajú request variables na zdieľanie dát medzi testami:
- `{{CreateCompany.response.body.$.id}}` - ID vytvorenej company
- `{{CreateDivision.response.body.$.id}}` - ID vytvorenej division
- atď.

## Pred spustením testov

Uistite sa, že:
1. Aplikácia beží na `http://localhost:5223`
2. Databáza je dostupná a inicializovaná
