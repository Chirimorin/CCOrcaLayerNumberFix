﻿var gcodePath = string.Join(' ', args);

if (!File.Exists(gcodePath))
{
    return;
}

using var file = File.Open(gcodePath, FileMode.Open, FileAccess.ReadWrite);
using var reader = new StreamReader(file,  bufferSize: 1);
using var writer = new StreamWriter(file);

var lineToEdit = 2;
var currentLine = 0;
var position = 0;

while (currentLine < lineToEdit)
{
    do
    {
        position++;
    }
    while (reader.Read() != ';');
    currentLine++;
}

file.Seek(position, SeekOrigin.Begin);

await writer.WriteAsync(" generated by ElegooSlicer ");
