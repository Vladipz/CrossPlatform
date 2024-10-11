## Lab3
### Запуск програми
```bash
dotnet run --project App
```
### Запуск тестів
Без проміжних результатів
```bash
dotnet test Tests
```
З проміжними результатами
```bash
dotnet test Tests --logger "console;verbosity=detailed"
```

### Результати

Вхідні дані беруться з файлу `INPUT.TXT`, результати записуються в файл `OUTPUT.TXT`
