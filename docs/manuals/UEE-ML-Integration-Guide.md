# UEE ML Integration Guide

## 🧠 Making the Engine Smart

UEE is designed to be the "Feature Store" for your AI models.

### 1. Data Collection (The Event Stream)
Data Scientists love event logs because they capture **behavior**, not just state.
*   Instead of `Status: Churned`, they see `Login`, `TicketCreated`, `UsageDropped`, `CancelClicked`.
*   **Pipeline:** Export EventStore -> Parquet/Iceberg (Data Lake) for training.

### 2. Feature Extraction (Real-Time)
You can write a **Projection** that calculates features in real-time.
*   `Projector: UserActivityScore`
*   Listens to every interaction.
*   Updates a Redis key `feature:user:123:activity_7d` with a decay function.

### 3. Inference (The Loop)
How to use the model in the app?

**Pattern A: The "Advisor" Plugin**
1.  User creates `DraftPost`.
2.  Plugin `OnCreated` triggers.
3.  Plugin calls external ML Service (`POST /predict { text: ... }`).
4.  ML Service returns `Sentiment: Toxic`.
5.  Plugin flags the post.

**Pattern B: The Vector Search**
1.  All entities are embedded into vectors on save (via `VectorProjector`).
2.  User asks "Find similar cases".
3.  UEE queries Qdrant/Weaviate.
