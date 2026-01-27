# GitHub Templates and Labels

This directory contains GitHub-specific configuration files for issue tracking, pull requests, and project management.

## 📂 Contents

### Issue Templates (`ISSUE_TEMPLATE/`)

- **`bounty-issue.md`**: Template for submitting bounty-eligible issues with tier classification
- **`bug-report.md`**: Template for reporting bugs and unexpected behavior
- **`feature-request.md`**: Template for proposing new features or enhancements
- **`config.yml`**: Configuration for issue template behavior

### Pull Request Template

- **`PULL_REQUEST_TEMPLATE.md`**: Comprehensive PR template with Definition of Done checklist

### Labels

- **`labels.json`**: Label definitions for the project, including bounty tiers

## 🏷️ Label Schema

### Bounty Labels

The bounty tier system is designed to incentivize contributions:

| Label | Value Range | Color | Use Case |
|-------|-------------|-------|----------|
| `bounty:tier-1` | $50-$100 | Green | Small bug fixes, documentation, minor refactoring |
| `bounty:tier-2` | $100-$250 | Blue | Medium features, architectural improvements |
| `bounty:tier-3` | $250-$500 | Purple | Major features, complex refactoring, performance work |
| `bounty:premium` | $500+ | Red | Large-scale features, critical infrastructure, security |

### Bounty Status Labels

- `bounty:claimed`: Issue has been claimed by a contributor
- `bounty:in-review`: PR is under review
- `bounty:paid`: Bounty has been paid out

### Standard Labels

- `bug`: Something isn't working
- `enhancement`: New feature or request
- `documentation`: Documentation improvements
- `security`: Security-related issue
- `performance`: Performance optimization
- `architecture`: Architectural improvement
- `needs-triage`: Needs initial assessment
- `good-first-issue`: Good for newcomers
- `help-wanted`: Extra attention needed

## 🚀 Applying Labels (for Maintainers)

### For Contributors

When creating a new issue:

1. Click "New Issue" in the repository
2. Select the appropriate template:
   - **Bounty Issue**: For work you want bounty-tagged
   - **Bug Report**: To report a problem
   - **Feature Request**: To propose a new feature
3. Fill out all required sections
4. Submit and wait for maintainer triage

### For Maintainers

When triaging issues:

1. Review the issue for completeness
2. Apply appropriate labels (bounty tier, type, priority)
3. Assign if a contributor has claimed it
4. Add to project board if applicable
5. Remove `needs triage` label once processed

## 🔄 PR Template Usage

### For Contributors

When creating a pull request:

1. The PR template will auto-populate
2. Fill out all sections, especially:
   - **Definition of Done Checklist**: Complete all applicable items
   - **Security Checklist**: Verify all security requirements
   - **Testing**: Describe your test coverage
3. Link to the related issue(s)
4. Request review from maintainers

### For Maintainers

When reviewing PRs:

1. Verify Definition of Done checklist is complete
2. Review code quality and architecture
3. Verify security checklist
4. Run tests locally if needed
5. Complete the Reviewer Checklist
6. Approve and merge, or request changes

## 🔒 Security

For security vulnerabilities:

- **DO NOT** use public issue templates
- **Email**: <security@getdivergentflow.com>
- See [CONTRIBUTING.md](../CONTRIBUTING.md#security-guidelines) for details

## 📚 Resources

- [CONTRIBUTING.md](../CONTRIBUTING.md): Full contribution guidelines
- [README.md](../README.md): Project overview and architecture
- [Bounty Stacking System](../CONTRIBUTING.md#bounty-stacking-system): Payment terms and process
