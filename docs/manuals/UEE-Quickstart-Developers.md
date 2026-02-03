# UEE Developer Quickstart

## 🚀 Getting Started

This guide will get you up and running with the Universal Entity Engine (UEE) locally.

### Prerequisites

* **.NET 10.0 SDK**
* **Docker Desktop** (for MongoDB & Redis)
* **VS Code** or **Rider**

### 1. Start Infrastructure

Run the provided docker-compose file to spin up the persistence layer.

```bash
docker-compose up -d
```

This starts:

* MongoDB (Port 27017)
* Redis (Port 6379)
* Seq (Port 5341) - *Optional logging*

### 2. Boot the Engine

Navigate to the API project and run it.

```bash
cd src/DivergentEngine.API
dotnet run
```

The API will be available at `https://localhost:7100`.

### 3. Create a Tenant

UEE is multi-tenant by default. Even a Tenant is just an Entity (Type: `uee:tenant`).
We create it in the `null` (Global) scope.

```bash
curl -X POST https://localhost:7100/api/entities/uee:tenant \
   -H "Content-Type: application/json" \
   -d '{
         "entityTypeId": "uee:tenant",
         "attributes": {
           "name": "DevTenant",
           "code": "dev01",
           "subscriptionPlan": "Free"
         }
       }'
```
*Save the `entityId` returned, you will use it as the `X-Tenant-Id` header.*

### 4. Define the Task Type

Before creating a Task, we must define what a "Task" is. This registers the code `task` in the Type Index.

```bash
curl -X POST https://localhost:7100/api/entities/uee:entityType \
   -H "Content-Type: application/json" \
   -d '{
         "entityTypeId": "uee:entityType",
         "attributes": {
            "name": "Task",
            "code": "task",
            "attributeDefinitions": [
                { "key": "title", "type": "string" },
                { "key": "priority", "type": "int" }
            ]
         }
       }'
```
*Note: The API will treat `uee:entityType` as a bootstrap alias for the System Type GUID.*

### 5. Create your first Entity

Now, create a "Task" entity. The API will resolve the alias `task` to the GUID of the entity you just created.

```bash
curl -X POST https://localhost:7100/api/entities/task \
   -H "X-Tenant-Id: <YOUR_TENANT_ID>" \
   -H "Content-Type: application/json" \
   -d '{
         "entityTypeId": "task",
         "attributes": {
            "title": "Learn UEE",
            "status": "todo",
            "priority": 1
         }
       }'
```
         "priority": 1
       }'
```

### 5. Query it back

```bash
curl -X GET https://localhost:7100/api/entities/task/{entityId} \
   -H "X-Tenant-Id: dev01"
```

### Next Steps

* [Define a Schema](UEE-Data-Modeling-Handbook.md)
* [Write a Plugin](UEE-Plugin-Cookbook.md)
