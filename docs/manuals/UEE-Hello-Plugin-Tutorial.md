# UEE "Hello World" Plugin Tutorial

## 👋 Your First Extension

We will build a simple plugin that adds a "timestamp" comment to any task created.

### 1. Setup Project
Assuming you are using Rust (Command line):
```bash
cargo new --lib timestamp_plugin
cd timestamp_plugin
```
Update `Cargo.toml` to `crate-type = ["cdylib"]`.

### 2. Write the Logic
In `src/lib.rs`:

```rust
use serde_json::{Value, json};

#[no_mangle]
pub extern "C" fn on_task_created(ptr: i32, len: i32) -> i32 {
    // 1. Read the event context provided by host
    let context = uee::read_context(ptr, len);
    
    // 2. Extract the Task ID
    let task_id = context["entityId"].as_str().unwrap();

    // 3. Create a Comment Entity via Host Function
    let comment = json!({
        "type": "comment",
        "parentId": task_id,
        "text": "Task created at " + uee::now()
    });

    uee::save_entity(comment);

    // 4. Return success
    return 0;
}
```

### 3. Build it
```bash
cargo build --target wasm32-unknown-unknown --release
```

### 4. Register it
Upload the `.wasm` file to UEE API.
```bash
curl -F "file=@target/.../timestamp_plugin.wasm" \
     -F "trigger=event:task_created" \
     https://api.uee.io/admin/plugins
```

### 5. Test it
Create a task via the API. Query for comments linked to that task. You should see your auto-generated comment!
