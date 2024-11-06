## Lab4
Запускати програму з папки `Lab4/Vlad_Danilchuk`
```bash
cd Lab4/Vlad_Danilchuk
```
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
### Запуск віртуальних машин
```bash
vagrant up
```

### Запуск серверу BaGet

```bash
docker-compose up
cd Vlad_Danilchuk
dotnet pack --configuration Release
dotnet nuget push -s http://localhost:5555/v3/index.json -k NUGET-SERVER-API-KEY .\bin\Release\Vlad_Danilchuk.1.0.0.nupkg
```
