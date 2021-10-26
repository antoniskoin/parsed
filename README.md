# parsed
A simple API to extract text and metadata from PDF documents.

## Endpoints
Text extraction
```
http://localhost:5000/extract
```

Metadata
```
http://localhost:5000/metadata
```

## Libraries
### [iText7](https://www.nuget.org/packages/itext7/)
Used to extract the text and the metadata from PDFs.
```
Install-Package itext7 -Version 7.1.16
```

## Runtime Dependencies
1. [ASP.NET Core](https://dotnet.microsoft.com/download/dotnet/5.0/runtime?utm_source=getdotnetcore&utm_medium=referral)
                                                                                                               