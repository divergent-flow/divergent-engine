# UEE UI Integration Guide

## 🎨 Building Frontends for UEE

UEE is "Headless". It provides API, you provide the pixels.

### 1. Dynamic Forms (Schema Driven)
Since entities are dynamic, your UI should be too.
1.  Fetch Schema: `GET /api/schemas/ticket`
2.  Render Form:
    *   `type: string` -> `<input type="text">`
    *   `type: enum` -> `<select>`
    *   `type: entity-ref` -> `<EntityPicker entity="user" />`
3.  Submit: `POST /api/entities/ticket`

### 2. Optimistic UI Updates
Because UEE is eventually consistent, a write might not immediately appear in a generic list query.
*   **Strategy:** When user clicks "Save", manually inject the new item into the local React Query / TanStack Query cache.
*   **Correction:** Listen to `SignalR` event. When the real `EntityCreated` event arrives, replace the optimistic version with the server version.

### 3. Real-Time Collaboration
UEE sends events via SignalR.
*   Subscribe to `entity:{id}`.
*   When `FieldChanged` event arrives, flash the field yellow and update the value.
*   Show "Who is viewing" presence using ephemeral Redis keys.

### 4. Timeslider (Time Travel)
Build a slider component that passes `?version=X` to the GET endpoint.
Allow users to visually scrub back through the history of any object.
