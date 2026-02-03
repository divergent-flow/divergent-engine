# UEE Plugin Cookbook

## 🍳 Recipes for Extending the Engine

This cookbook provides WASM patterns for common extension scenarios.

### Recipe 1: Calculated Field
**Goal:** Automatically calculate `total` when `price` or `qty` changes.

*trigger: on_entity_save(line_item)*
```rust
fn on_save(entity: Entity) -> Entity {
    let price = entity.get_float("price");
    let qty = entity.get_int("qty");
    entity.set_float("total", price * qty);
    return entity;
}
```

### Recipe 2: External Validation
**Goal:** Prevent saving a user if the email is banned.

*trigger: before_save(user)*
```rust
fn validate(entity: Entity) -> Result {
    let email = entity.get_string("email");
    if (email.contains("@banned.com")) {
        return Error("Email domain not allowed");
    }
    return Ok();
}
```

### Recipe 3: Side Effect (Webhook)
**Goal:** Call an external Slack webhook when a high-priority ticket is created.

*trigger: on_event(ticket_created)*
```rust
fn handle_event(evt: Event) {
    if (evt.data.priority == "High") {
        let payload = json!({ "text": "New High Priority Ticket!" });
        host.http_post("https://hooks.slack.com/...", payload);
    }
}
```

### Recipe 4: Auto-Numbering
**Goal:** Generate a human-readable ID like `TKT-1024`.

*trigger: before_create(ticket)*
```rust
fn before_create(entity: Entity) -> Entity {
    let next_id = host.increment_counter("ticket_seq");
    entity.set_string("readableId", format!("TKT-{}", next_id));
    return entity;
}
```
