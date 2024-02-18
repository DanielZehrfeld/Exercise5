# **Excercise 5**

Test-URL: https://flapotest.blob.core.windows.net/test/ProductData.json

**Routes**:

+ /api/products/Analyse?url=
+ /api/products/Analyse/maxNumberOfBottles?url=
+ /api/products/Analyse/minMaxPricePerLitre?url=
+ /api/products/Analyse/exactPrice?url=
+ /api/products/Analyse/exactPrice/9.99?url=
 

**All**
[HTTP GET] http://localhost:5269/api/products/Analyse?url=https://flapotest.blob.core.windows.net/test/ProductData.json

**Max number of bottles**
[HTTP GET] http://localhost:5269/api/products/Analyse/maxNumberOfBottles?url=https://flapotest.blob.core.windows.net/test/ProductData.json

**Min-Max price**
[HTTP GET] http://localhost:5269/api/products/Analyse/minMaxPricePerLitre?url=https://flapotest.blob.core.windows.net/test/ProductData.json

**Exact price**:
[HTTP GET] http://localhost:5269/api/products/Analyse/exactPrice?url=https://flapotest.blob.core.windows.net/test/ProductData.json

**Exact price (value)**: [HTTP GET] http://localhost:5269/api/products/Analyse/exactPrice/9.99?url=https://flapotest.blob.core.windows.net/test/ProductData.json

**Swagger Documentation** https://localhost:7233/swagger/index.html
