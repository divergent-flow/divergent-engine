# UEE WASM Developer Guide

## 🦀 Developing Plugins for UEE

UEE plugins run in a Wasmtime container. You can write them in Rust, AssemblyScript, or C#.

### The Core ABI (Application Binary Interface)
Your plugin must export specific functions that the UEE interacts with.

#### `alloc` & `dealloc`
Standard memory management functions so the host can write data into the plugin's memory.

#### `run(ptr: i32, len: i32) -> i32`
The main entry point.
1.  **Input:** Pointer to a JSON string (serialized `PluginContext`).
2.  **Output:** Pointer to a JSON string (serialized `PluginResult`).

### Host Functions (Imports)
The host provides these functions to your plugin:

*   `db_get_entity(id_ptr: i32, id_len: i32) -> i32`
*   `db_save_entity(json_ptr: i32, json_len: i32) -> i32`
*   `log_info(msg_ptr: i32, msg_len: i32)`

### Rust Example
Use the `uee-sdk` crate (hypothetical).

```rust
#[no_mangle]
pub extern "C" fn on_event(ptr: i32, len: i32) -> i32 {
    let ctx = read_context(ptr, len);
    
    // Logic here
    log_info(format!("Processing entity: {}", ctx.entity_id));
    
    return write_result(PluginResult::Success);
}
```

### Compiling
Target `wasm32-unknown-unknown`.
```bash
cargo build --target wasm32-unknown-unknown --release
```
The resulting `.wasm` file is what you upload to UEE.
