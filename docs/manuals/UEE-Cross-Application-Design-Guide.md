# UEE Cross Application Design Guide

## 🌐 One Engine, Many Apps

UEE allows multiple "Applications" to coexist on the same data substrate.
For example, a **CRM App** and a **Project Management App** can both view the same `User` entity, but augment it differently.

### Pattern: The "Core vs. Extension" Model
Do not create monolithic entities like `UserWithCrmAndPmData`.

#### 1. The Core Entity
Owned by the "System".
*   `type: user`
*   `id: user_123`
*   `name: "Alice"`

#### 2. The App-Specific Extension
Owned by the specific application.
*   `type: crm_profile`
*   `id: crm_user_123`
*   `userId: user_123` (Link)
*   `leadScore: 99`

#### 3. The Unified View (Projection)
Create a Read Model that joins them.
*   `UserProfileReadModel` -> `{ Name: "Alice", LeadScore: 99 }`

### App-Specific Contexts
When the CRM App logs in, it requests `Tenant: Sales`.
When the PM App logs in, it requests `Tenant: Engineering`.
But if they share a tenant (e.g., "Contoso Corp"), they can share data visibility via **Permissions**.

### Shared Events
The CRM App creates a `DealClosed` event.
The PM App listens to `DealClosed` and automatically provisions a `KickoffProject`.

This decoupling allows teams to build apps independently while sharing the same business reality.
