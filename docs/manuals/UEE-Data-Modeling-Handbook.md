# UEE Data Modeling Handbook

## 🧠 Thinking in Entities

In UEE, you don't design tables. You design **Entities** and **Events**.

### The Golden Rules

1. **Tiny Aggregates:** Keep entities small. A `Customer` is fine. A `CustomerWithAllOrders` is bad.
2. **Schema on Read (Mostly):** You can save any JSON attributes you want. Validation happens at the *Command* level or via *Plugins*.
3. **Immutability:** You never "change" a field. You apply an event that says the field changed.

### Entity Types are Entities (The "Turtle" Problem)

Since "Everything is an Entity", an `EntityType` is just an entity with a specific structure.

* **System Type:** `uee:entityType` (The definition of a definition).
* **Your Type:** A new entity with `entityTypeId = "uee:entityType"` (or its GUID equivalent).

#### Type Resolution (GUIDs vs Codes)

Strictly speaking, the `entityTypeId` field implies a **GUID** reference to the definition entity.
However, using GUIDs in APIs is painful (`POST /api/entities/550e8400-e29b...`).

**The Solution: The Type Registry Projection**
The system maintains a cached projection that maps **codes** to **IDs**.

* `"task"` -> `a1b2-c3d4-...`
* `"ticket"` -> `e5f6-a7b8-...`

When you send `POST /api/entities/task`, the API Middleware:

1. Looks up "task" in the Type Registry.
2. Resolves it to the specific `EntityType` GUID.
3. Writes the Event with the correct **GUID** in `entityTypeId`.

### Defining an Entity Type

To register "ticket", you create an entity of type `uee:entityType`.

```json
{
  "entityTypeId": "uee:entityType",
  "attributes": {
    "code": "ticket",
    "name": "Support Ticket",
    "attributeDefinitions": [
      { "key": "title", "type": "string", "required": true },
      { "key": "severity", "type": "enum", "options": ["Low", "High"] },
      { "key": "assignedTo", "type": "entity-ref", "target": "user" }
    ]
  }
}
```

### Relationships

UEE supports loose coupling via **Entity References**.

* **Direct Reference:** Store the `ID` of another entity in an attribute.
  * `"managerId": "ent_123"`
* **Edge Collection:** Use the Graph API to link entities.
  * `Link(parent, child, "contains")`

### Versioning

Every save increments the `_v` (Version).

* v1: Created `{"status": "new"}`
* v2: Updated `{"status": "active"}`

You can query `MyEntity?v=1` to see the past.
