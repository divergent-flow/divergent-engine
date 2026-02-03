# UEE Testing Strategy

## 🧪 Ensuring Reliability

Because UEE is Event Sourced, testing is delightful. You test behavior, not state.

### 1. Unit Testing Aggregates (The "Given-When-Then" Pattern)
You don't need a database to test business logic.

*   **Given:** A list of past events (History).
*   **When:** A command is executed.
*   **Then:** Expect a list of new events (Output).

```csharp
[Fact]
public void Should_Complete_Task()
{
    // Given
    var history = new[] { new TaskCreated { Title = "Test" } };
    var sut = new TaskAggregate(history);

    // When
    var events = sut.CompleteTask();

    // Then
    Assert.Single(events);
    Assert.IsType<TaskCompleted>(events[0]);
}
```

### 2. Integration Testing (The "Black Box")
Spin up the Engine in-memory (or with TestContainers).

1.  Send HTTP POST (Command)
2.  Wait for Eventual Consistency (Poller)
3.  Send HTTP GET (Query)
4.  Assert Write Model match Read Model.

### 3. Plugin Testing
Plugins are pure functions.
*   Test input JSON -> WASM -> Output JSON.
*   Mock the "Host Functions" (DB access) to verify the plugin tries to save what it should.

### 4. Load Testing (K6)
Important because Event Sourcing can have bottlenecks at the "Append" stage.
*   Script: Create 1000 entities in parallel.
*   Metric: Time to Consistency (t2c) - duration between `200 OK` on write and `Data visible` on read.
