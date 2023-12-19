# DotNetMicroservicesWrapUp

Create global.json file
```text
{
    "sdk": {
        "version": "5.0.408"
    }
}
```
Dowload package
```powershell
dotnet add package MongoDb.Driver
```

Setting docker image
```powershell
docker run -d --rm --name mongoDbContainer -p 27017:27017 -v mongoDbData:/data/db mongo
```