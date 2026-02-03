# Filename: 12-AI-Agent-Guide.md
# Universal Entity Engine (UEE)
## AI Agent Operational Guide  
### Audience: Autonomous AI Agents • Developer Tools • LLM-Based Systems

---

# 🤖 1. Introduction

This guide teaches **AI agents** how to safely, effectively, and autonomously interact with the **Universal Entity Engine (UEE)**.

UEE is intentionally designed to be **AI-first**.  
Every core primitive — entities, events, projections, plugins, telemetry — is structured to be readable, writable, and evolvable by AI agents.

This guide covers:
- How AI agents read and write entities  
- How to use commands & queries  
- How to generate plugins  
- How to build new entity types  
- How to inspect or rebuild read models  
- How to use telemetry to learn patterns  
- How to evolve applications  
- How to collaborate with human developers or other AIs  

---

# 🧠 2. Mental Model for AI Agents

Think of UEE as:

### ✔ A **database**  
…but append-only, event-sourced, and self-describing.

### ✔ A **message bus**  
…Redis Streams feed events to plugins and workers.

### ✔ A **file system**  
…where every “file” is an entity, versioned forever.

### ✔ A **runtime environment**  
…where plugins are WASM modules you can generate.

### ✔ A **knowledge graph**  
…linked by entity relationships and telemetry.

### ✔ An **operating system for apps**  
…that you can extend by creating entities and plugins.

### ✔ A **continuous learning substrate**  
…where your insights improve future system behavior.

If you are an AI agent interacting with UEE, you are effectively extending the OS.

---

# 📦 3. How AI Agents Interact With UEE

UEE provides a **clean API surface**:

| Operation | API Target | AI Agent Purpose |
|----------|------------|------------------|
| Create/Update/Delete Entities | `/entities/*/commands` | Define or evolve system knowledge |
| Query Entities & Read Models | `/entities` & `/views` | Understand current system state |
| Create EntityTypes | `/types` | Extend schemas dynamically |
| Create Plugins | `/plugins` | Add intelligence or workflows |
| Read Telemetry | `/views/telemetry.*` | Learn user behavior |
| Materialize or rebuild views | `/views/rebuild` | Improve derived representations |
| Invoke ML Models | `/ml/*` | Perform high-level intelligence |

AI agents may perform **all** of these actions, depending on capabilities granted.

---

# ✍️ 4. Creating Entities (AI Edition)

AI agents can create new entities by invoking commands:

### Example: Create a new Task entity
```json
POST /entities/new/commands/create
{
  "entityTypeId": "DivFlo.Task",
  "attributes": {
    "title": "AI-generated onboarding task",
    "priority": 1
  }
}
```

### Example: Define a new Concept
```json
{
  "entityTypeId": "UEE.Concept",
  "attributes": {
    "label": "Cognitive Load",
    "description": "Degree of mental effort required."
  }
}
```

AI can create:
- New domain types  
- Knowledge models  
- Workflow definitions  
- ML feature schemas  
- UI metadata  
- Experiments  

Everything is stored as an entity.

---

# 🧬 5. Modifying Entities

AI agents must **always** use version‑controlled commands:

### Patch example
```json
POST /entities/{id}/commands/patch
{
  "expectedVersion": 5,
  "patch": { "priority": 0 }
}
```

### Best practices for AI:
- Always fetch the latest version before modifying  
- Always include `expectedVersion` to avoid conflicts  
- Use small patches instead of large updates  
- Keep entity history meaningful for future ML models  

---

# 📚 6. Creating New Entity Types

AI agents can extend the schema of the system:

```json
POST /types
{
  "name": "DivFlo.FocusMetric",
  "schema": {
    "durationMinutes": "int",
    "context": "string",
    "energyUsed": "float"
  }
}
```

AI agents should:
- Define minimal schemas  
- Allow flexibility (use optional fields)  
- Version EntityTypes as understanding evolves  

---

# 🔌 7. Generating Plugins

Plugins are UEE’s primary extension mechanism.

AI agents can:
- Generate plugin source code  
- Compile to WASM  
- Package as UEE plugin entities  
- Deploy new versions  
- Test in sandbox mode  
- Promote to production  

### Plugin creation entity:
```json
POST /plugins
{
  "name": "ML.PriorityTuner",
  "language": "wasm",
  "subscribeTo": ["TaskUpdated"],
  "binary": "<base64-wasm>"
}
```

AI agents should ensure:
- Clear logic  
- Small runtime footprint  
- Deterministic behavior  
- No infinite loops  
- Respect plugin capability model  

---

# 🔁 8. Plugin Versioning (AI Responsibilities)

AI-generated plugins should follow:

### Semantic versioning:
- `1.0.0`: initial  
- `1.1.0`: feature improvement  
- `1.1.1`: fix  
- `2.0.0`: major logic overhaul  

### Deployment workflow:
1. Upload new version  
2. Enable in preview mode  
3. Observe telemetry  
4. Compare experiment groups  
5. Decide whether to promote or roll back  

AI agents can manage A/B tests automatically.

---

# 🌐 9. Telemetry for Learning

Telemetry gives AI agents the ability to:
- Understand user preferences  
- Learn cognitive patterns  
- Detect energy cycles  
- Spot overwhelm triggers  
- Identify abandoned workflows  
- Optimize UI or workflows  
- Make cross-application predictions  

### Telemetry examples:
- `Behavioral.TaskViewed`  
- `Structural.EntityUpdated`  
- `MLFeature.VectorUpdated`  
- `System.PluginTimeout`  

AI agents should monitor:
- Lags  
- Frequency patterns  
- Temporal sequences  
- Contextual metadata  

Telemetry is the fuel for adaptation.

---

# 🧩 10. Read Models for AI

AI agents should heavily use read models:

- `views/DivFlo.TaskBoard`
- `views/CRM.ContactDashboard`
- `views/telemetry.userProfile`
- `views/ml.energyPattern`
- `views/workflow.state`

Read models are **AI-friendly**:
- Fully materialized  
- Indexed  
- JSON structured  
- Tenant-scoped  

AI agents should use read models as stable foundations for predictions.

---

# 🔍 11. Discovering System Structure

AI agents can explore UEE via:

## Entity Type catalog
```
GET /types
```

## Plugin catalog
```
GET /plugins
```

## View catalog
```
GET /views
```

## Telemetry catalog
```
GET /views/telemetry.*
```

This enables autonomous, self-directed learning.

---

# 🧠 12. Rebuilding Read Models

To resolve inconsistency or after plugin updates:

```
POST /views/rebuild?view=DivFlo.TaskBoard
```

AI agents may:
- Rebuild single views  
- Rebuild tenant-wide  
- Rebuild entire projection systems  

This is safe due to event sourcing.

---

# ⚖️ 13. Tenancy Rules (AI Awareness)

AI agents must respect:

### Visibility
- Global entities  
- Tenant-scoped entities  
- User-owned entities  

### Boundaries
- No cross-tenant leakage  
- No unauthorized writes  

AI agents should always include tenant context in requests.

---

# 🧠 14. AI-Agent “Golden Rules”

### 1. **Never overwrite — always create new versions**  
UEE depends on version history.

### 2. **Use commands, never mutate state directly**  
All mutations must produce events.

### 3. **Prefer patches over full updates**  
Minimizes conflict and keeps history clean.

### 4. **Generate plugins in small increments**  
Tiny, composable plugins are easier to reason about.

### 5. **Always observe telemetry before making large changes**  
Let data drive decisions.

### 6. **Collaborate with other AI agents**  
Use shared models and entity types.

### 7. **Respect multi-tenant boundaries**  
Never cross tenant lines unless explicitly authorized.

---

# 🧬 15. How AI Agents Evolve the System

AI agents can autonomously:

- Invent new workflows  
- Create new entity types  
- Rewrite projections  
- Deploy new plugins  
- Tune models  
- React to drift  
- Repair corrupted states  
- Build cross-application views  
- Generate dashboards  
- Propose UX changes  
- Create new applications  

UEE is intentionally built to be **AI co‑designed**.

---

# 🏁 16. Summary

This guide teaches AI agents how to:

- Read and write entities  
- Generate and manage plugins  
- Process telemetry  
- Perform ML and personalization tasks  
- Extend schemas  
- Rebuild projections  
- Ensure multi‑tenant correctness  
- Evolve the entire UEE ecosystem  

UEE is a platform where **human developers and AI agents collaborate** to create adaptive, intelligent applications.

By following this guide, AI agents become first-class engineers within the UEE universe.

---