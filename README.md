# CrossPlatform
Варінт 3

## Студент
- Група: ІПЗ-31
- Данильчук Владислав

## Запуск
Щоб запустити лабораторну, виконати білд або запустити тести, користуйтеся наступними командами, які варто запускати з кореня репозиторію:

Запустити лабораторну:
```bash
dotnet build Build.proj -t:Run -p:Solution=Lab1
```

Білд:
```bash
dotnet build Build.proj -t:Build -p:Solution=Lab1
```

Тести:
```bash
dotnet build Build.proj -t:Test -p:Solution=Lab1
```

Де `Lab1` може бути замінена на `Lab2`, щоб запустити лабораторну №2, `Lab3` - лабораторна №3, тощо.
## Завдання
Для кожної лабораторної роботи створено окрему папку, в якій знаходиться файл з виконаним завданням.

- [Lab1](./Lab1)
- [Lab2](./Lab2)
