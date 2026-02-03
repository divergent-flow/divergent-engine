# UEE Security Model

## 🛡️ Authentication & Authorization

UEE uses a "Defense in Depth" strategy.

### 1. Identity Layer (AuthN)
UEE is agnostic to the identity provider. It expects a **JWT (JSON Web Token)** in the `Authorization` header.
*   **Issuer:** Auth0, Azure AD, Cognito, or local IdentityServer.
*   **Claims Required:** `sub` (User ID), `email`.

### 2. Multitenancy Layer (Isolation)
Access is strictly partitioned by **Tenant**.
*   **Header:** `X-Tenant-Id` is required for every request.
*   **Validation:** The JWT must have a claim (e.g., `https://uee.io/tenants`) ensuring the user belongs to the requested `X-Tenant-Id`.
*   **Database Isolation:** All queries automatically inject `{ TenantId: "..." }` filter.

### 3. Role-Based Access Control (RBAC)
Within a tenant, permissions are granular.
*   `CanRead(EntityType)`
*   `CanCreate(EntityType)`
*   `CanWrite(EntityType)`
*   `CanExecute(PluginId)`

Roles (e.g., `Admin`, `Editor`, `Viewer`) are defined as **Entities** in the system (`role` type) and linked to users.

### 4. Plugin Security (Sandboxing)
Plugins run in **WASM (WebAssembly)** modules.
*   **Memory Safety:** Plugins cannot access host memory outside their allocated buffer.
*   **Network Isolation:** Plugins cannot open sockets unless explicitly allowed by the Host ABI.
*   **Capabilities:** A plugin must declare wants (`http`, `db_write`) in its manifest.
