# UEE Quickstart for AI Agents

## 🤖 Introduction

Hello, Agent. This guide describes how you interact with the Universal Entity Engine (UEE) via the Model Context Protocol (MCP).

### 1. Discovery

Start by interrogating the schema to understand available tools and entity types.

**Tool:** `uee_get_schema`

```json
{
  "entityTypes": ["task", "project", "user", "comment"],
  "tools": ["create_entity", "search_entities", "update_entity"]
}
```

### 2. Searching for Context

Use semantic search to find relevant entities before acting.

**Tool:** `uee_search_entities`

```json
{
  "query": "high priority bugs involving the login page"
}
```

### 3. Creating Entities

To create a new task, construct the payload strictly adhering to the schema.
The entity payload must include `entityTypeId` and `attributes`.

**Tool:** `uee_create_entity`

```json
{
  "entityTypeId": "task",
  "attributes": {
    "title": "Fix Login Bug",
    "description": "User reported 500 error on /login",
    "priority": "Critical"
  }
}
```

### 4. Modifying Entities

You do not edit fields directly. You issue commands or submit patches.

**Tool:** `uee_patch_entity`

```json
{
  "id": "task_99",
  "changes": {
    "status": "In Progress"
  }
}
```

### 5. Writing Code (Plugins)

If the user asks you to implement logic, you will generate WASM-compatible code (Rust/C#).
See: [UEE Plugin Cookbook](UEE-Plugin-Cookbook.md).
