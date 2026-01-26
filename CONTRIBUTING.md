# Contributing to Divergent Engine 🤝

Thank you for your interest in contributing to Divergent Engine! We're building the next generation of productivity infrastructure, and we welcome contributions from backend engineers, architects, and domain experts.

## 📋 Table of Contents
- [Code of Conduct](#code-of-conduct)
- [How to Contribute](#how-to-contribute)
- [Bounty Stacking System](#bounty-stacking-system)
- [Contributor License Agreement (CLA)](#contributor-license-agreement-cla)
- [Development Workflow](#development-workflow)
- [Coding Standards](#coding-standards)
- [Security Guidelines](#security-guidelines)

## Code of Conduct

We are committed to providing a welcoming and inclusive environment. All contributors are expected to:
- Be respectful and professional in all interactions
- Focus on constructive feedback and solutions
- Respect differing viewpoints and experiences
- Accept responsibility for mistakes and learn from them

## How to Contribute

### Finding Work
1. Browse our [Issues](https://github.com/divergent-flow/divergent-engine/issues) page
2. Look for issues tagged with `bounty:tier-1`, `bounty:tier-2`, `bounty:tier-3`, or `bounty:premium`
3. Check if the issue is already assigned - unassigned bounties are up for grabs
4. Comment on the issue expressing your interest

### Types of Contributions
- **Bug Fixes**: Help us identify and fix issues in the codebase
- **Feature Development**: Build new capabilities for the UEE
- **Documentation**: Improve our docs, add examples, or clarify concepts
- **Architecture**: Propose and implement architectural improvements
- **Testing**: Add unit tests, integration tests, or improve test coverage

## Bounty Stacking System

### What is Bounty Stacking?
Divergent Engine operates on a **Bounty Stacking** model. This means:

1. **Issues are Tagged with Bounty Values**: Specific GitHub issues are tagged with monetary values (e.g., `bounty:tier-1` = $50, `bounty:tier-2` = $100, `bounty:tier-3` = $250, `bounty:premium` = $500+)
2. **Bounties Stack (Accumulate)**: When you complete a bounty-tagged issue, the bounty amount is added to your cumulative total
3. **Revenue-Based Payout**: **Bounties are cumulative (stacked) and will be payable once the company reaches a predefined monthly revenue threshold**

### Payment Terms
**Important**: All bounties are contingent on company revenue milestones. Specifically:
- **Threshold**: Bounties become payable when Divergent Flow reaches **$10,000 in Monthly Recurring Revenue (MRR)**
- **Tracking**: Your accumulated bounties are tracked in our internal contributor ledger
- **Payout Schedule**: Once the threshold is met, payouts occur within 30 days via your preferred method (PayPal, Bank Transfer, or Cryptocurrency)
- **Transparency**: We commit to publishing quarterly revenue updates to keep contributors informed of progress toward the threshold

### Bounty Tiers
| Tier | Value Range | Typical Scope |
|------|-------------|---------------|
| `bounty:tier-1` | $50 - $100 | Small bug fixes, documentation improvements, minor refactoring |
| `bounty:tier-2` | $100 - $250 | Medium features, architectural improvements, integration work |
| `bounty:tier-3` | $250 - $500 | Major features, complex refactoring, performance optimization |
| `bounty:premium` | $500+ | Large-scale features, critical infrastructure, security hardening |

### How to Claim a Bounty
1. Find an open bounty issue that interests you
2. Comment on the issue: "I'd like to work on this bounty"
3. Wait for assignment confirmation from a maintainer
4. Complete the work according to our [Development Workflow](#development-workflow)
5. Submit a PR referencing the bounty issue
6. Upon PR merge, the bounty is added to your contributor account

## Contributor License Agreement (CLA)

**All contributors must sign our Contributor License Agreement (CLA) before their first contribution can be merged.**

### Why a CLA?
The CLA ensures:
- You have the right to contribute the code
- The project can be distributed under the MIT license
- Protection for both contributors and the project

### Signing the CLA
We use **CLA Assistant** for CLA management:

1. When you open your first Pull Request, the CLA Assistant bot will comment on your PR
2. Click the link provided by the bot to review the CLA
3. Sign electronically via the CLA Assistant interface
4. Once signed, the bot will update your PR status

**Note**: You only need to sign once. All future contributions are covered.

## Development Workflow

### Branching Strategy
We follow a **Feature Branch** workflow:

```
main (protected)
  ↑
  └── feature/your-feature-name
  └── bugfix/issue-description
  └── docs/documentation-update
```

#### Branch Naming Conventions
- **Features**: `feature/short-description` (e.g., `feature/add-entity-validation`)
- **Bug Fixes**: `bugfix/issue-number-description` (e.g., `bugfix/123-fix-null-reference`)
- **Documentation**: `docs/description` (e.g., `docs/update-contributing-guide`)
- **Refactoring**: `refactor/description` (e.g., `refactor/extract-repository-interface`)

### Workflow Steps
1. **Fork the Repository** (if you're not a core contributor)
2. **Create a Branch** from `main`
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Make Your Changes**
   - Write clean, well-documented code
   - Follow our [Coding Standards](#coding-standards)
   - Add tests for new functionality
4. **Commit Your Changes**
   ```bash
   git commit -m "feat: add entity validation for EntityType"
   ```
   Use [Conventional Commits](https://www.conventionalcommits.org/) format
5. **Push to Your Fork**
   ```bash
   git push origin feature/your-feature-name
   ```
6. **Open a Pull Request**
   - Use our [PR Template](.github/PULL_REQUEST_TEMPLATE.md)
   - Reference the bounty issue number
   - Fill out the Definition of Done checklist

### Commit Message Format
We use **Conventional Commits**:
```
<type>(<scope>): <description>

[optional body]

[optional footer]
```

**Types**:
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

**Examples**:
```
feat(entities): add validation for EntityType attributes
fix(core): resolve null reference in Entity.Relationships
docs(readme): update UEE architecture section
refactor(core): extract IEntityRepository interface
```

## Coding Standards

### General Principles
1. **Clean Architecture**: Respect layer boundaries - Core should have minimal dependencies
2. **SOLID Principles**: Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion
3. **Interface Extraction**: Abstract external dependencies behind interfaces
4. **Testability**: Write code that's easy to test without infrastructure

### .NET Guidelines
- Follow [Microsoft's C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use **nullable reference types** (`#nullable enable`)
- Prefer `required` properties over nullable properties where appropriate
- Use **XML documentation comments** for public APIs
- Prefer `readonly` and `const` where applicable

### Code Style
- **Indentation**: 4 spaces (no tabs)
- **Line Length**: Max 120 characters
- **Naming**:
  - Classes: `PascalCase`
  - Interfaces: `IPascalCase`
  - Methods: `PascalCase`
  - Private fields: `_camelCase`
  - Parameters: `camelCase`
  - Constants: `UPPER_SNAKE_CASE`

### Testing Requirements
- **Unit Tests**: Required for all new business logic
- **Integration Tests**: Recommended for data access and infrastructure
- **Test Naming**: `MethodName_Scenario_ExpectedBehavior`
  ```csharp
  Entity_WithNullId_ThrowsValidationException()
  ```

## Security Guidelines

Security is paramount in Divergent Engine. All contributions must adhere to these standards:

### Security Checklist
Before submitting a PR, ensure:
- [ ] **No Hardcoded Secrets**: No API keys, passwords, or tokens in code
- [ ] **Input Validation**: All user inputs are validated and sanitized
- [ ] **SQL/NoSQL Injection**: Use parameterized queries (MongoDB driver handles this)
- [ ] **Authentication**: Respect tenant boundaries - all queries filter by `TenantId`
- [ ] **Authorization**: Verify user permissions before data access
- [ ] **Secure Defaults**: Use secure configurations by default
- [ ] **Dependency Scanning**: No known vulnerabilities in added dependencies
- [ ] **Sensitive Data**: PII and sensitive data are encrypted at rest

### Reporting Security Vulnerabilities
**Do NOT open public issues for security vulnerabilities.**

Instead:
1. Email: security@getdivergentflow.com
2. Include: Description, steps to reproduce, impact assessment
3. We'll respond within 48 hours with next steps

### AppSec Standards
We follow OWASP Top 10 guidelines. Key areas:
- **A01: Broken Access Control**: Always validate tenant/user permissions
- **A02: Cryptographic Failures**: Use strong encryption for sensitive data
- **A03: Injection**: Sanitize all inputs, use parameterized queries
- **A05: Security Misconfiguration**: Secure defaults, minimal attack surface
- **A07: Identification and Authentication Failures**: Proper session management

## Questions?

If you have questions or need clarification:
- **General Questions**: Open a [Discussion](https://github.com/divergent-flow/divergent-engine/discussions)
- **Bug Reports**: Open an [Issue](https://github.com/divergent-flow/divergent-engine/issues) with the `bug` label
- **Feature Requests**: Open an [Issue](https://github.com/divergent-flow/divergent-engine/issues) with the `enhancement` label

---

**Thank you for contributing to Divergent Engine!** 🚀

Together, we're building the future of productivity infrastructure.
