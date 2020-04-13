# DataConverter
* Конвертер форматов данных поддерживает *XML* и *JSON*. 
* Данные можно преобразовать как из файла, так и из строки.
* Доступен дамп C# объектов в файлы соответствующих форматов.
* Реализован CLI-интерфейс:

    `src.exe --convert-file --from <json|xml> --to <xml|json> --source <filepath> --target <filepath>`

    `src.exe --convert-string --from <json|xml> --to <xml|json> <string>`
    
    `src.exe --help`