# UEE Deployment Guide

## 🚢 Going to Production

### Architecture Topography

#### 1. The Container Cluster (Kubernetes)
*   **API Nodes (Stateless):** Run the ASP.NET Core API. Scale horizontally (HPA) based on CPU/Memory.
*   **Worker Nodes (Stateless):** Run the Projection Engine and WASM Hosts. Scale based on Redis Stream Lag.

#### 2. The Data Layer (Managed Services)
Do *not* run databases in K8s for production if possible.
*   **MongoDB Atlas:** Use a Replica Set (min 3 nodes) for high availability.
*   **Redis Cloud:** Use AOF persistence to ensure the Event Stream isn't lost during extensive outages, though Mongo is the source of truth.

### Configuration (Environment Variables)
*   `ConnectionStrings__Mongo`: "mongodb+srv://user:pass@cluster..."
*   `ConnectionStrings__Redis`: "redis-endpoint:6379,password=..."
*   `UEE__TenancyMode`: "DatabasePerTenant" or "DiscriminatorColumn" (default).

### CI/CD Pipeline
1.  **Build:** `dotnet publish` -> Docker Image.
2.  **Test:** Run Unit Tests.
3.  **Push:** ECR / Docker Hub.
4.  **Deploy (staging):** Helm Upgrade.
5.  **Migration:** Run `uee-eval-migrations` (Changes schema definitions, not data).

### Health Checks
*   `/health/live`: Basic ping (Am I on?).
*   `/health/ready`: Dependency check (Can I reach Mongo/Redis?).
