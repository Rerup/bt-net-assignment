# How to run
- Run the whole solution in Visual Studio
- Make sure API and Gateway is running

 Now try and send a request to
 
```bash
http://localhost:5097/v1/products
```

You can open the ocelot.json file in the ProductGateway project to see the defined routes.

eg. 
```bash
GET: http://localhost:5097/v1/products
GET: http://localhost:5097/v1/products/{guid}
DELETE: http://localhost:5097/v1/products/{guid}
POST: http://localhost:5097/v1/products/create
```

The persistence layer is using GUID as PK, and therefore you should first find an ID and then call the remaining routes.

# Check the timed request
See the x-time header to see the response time in ms.
I recommend using Postman or something similar.

# Additional features
- Repository pattern for increased maintainability
- Introduced caching in the ProductGateway
- Added API Versioning at API level and Gateway level


# Additonal considerations
- Adding Authentication and Authroization and enforce it at Gateway level
- Adding RateLimitting at the Gateway level
- Containerize the application, so that we can enforce isolation and make the API private.
