## Lab4
### Запуск програми
```bash
dotnet run -- run lab{lab_number} -i {input_file_path} -o {output_file_path}
```
```bash
dotnet run -- -h
```
```bash
dotnet run -- set-path -p {path}
```

Запускати програму з папки `Lab4`
### Запуск серверу BaGet

```bash
docker-compose up
```
### Пакування пакету
```bash
dotnet pack --configuration Release
```
### Публікація пакету
```bash
dotnet nuget push -s http://localhost:5555/v3/index.json -k NUGET-SERVER-API-KEY .\bin\Release\Vlad_Danilchuk.1.0.0.nupkg
```

### Запуск віртуальних машин
```bash
vagrant up
```
