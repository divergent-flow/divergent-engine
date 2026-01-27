## 📝 Description
<!-- Provide a clear and concise description of your changes -->


## 🔗 Related Issue(s)
<!-- Link to the issue(s) this PR addresses -->
Closes #
Relates to #

## 🎯 Type of Change
<!-- Check all that apply -->
- [ ] Bug fix (non-breaking change that fixes an issue)
- [ ] New feature (non-breaking change that adds functionality)
- [ ] Breaking change (fix or feature that would cause existing functionality to not work as expected)
- [ ] Refactoring (code improvements without changing functionality)
- [ ] Documentation update
- [ ] Performance improvement
- [ ] Security fix
- [ ] Other: ___________

## 🧪 Testing
<!-- Describe the tests you ran and how to reproduce them -->

### Test Coverage
- [ ] Unit tests added/updated
- [ ] Integration tests added/updated
- [ ] All tests passing locally
- [ ] No test coverage regression

### Manual Testing Steps
1. 
2. 
3. 

### Test Results
```
Paste test output here
```

## 📸 Screenshots (if applicable)
<!-- Add screenshots for UI changes or visual verification -->


## ✅ Definition of Done Checklist

### Code Quality
- [ ] Code follows project coding standards (see [CONTRIBUTING.md](../CONTRIBUTING.md))
- [ ] Self-review of code completed
- [ ] Code is well-commented, particularly in complex areas
- [ ] XML documentation added for public APIs
- [ ] No compiler warnings introduced
- [ ] No commented-out code or debug statements

### Architecture & Design
- [ ] **Interface extraction compliance**: Core domain layer maintains minimal dependencies
- [ ] Changes respect Clean Architecture layer boundaries
- [ ] SOLID principles followed
- [ ] No circular dependencies introduced
- [ ] Repository pattern used for data access (if applicable)

### Testing & Quality
- [ ] **Unit tests passing**: All new and existing unit tests pass
- [ ] Test coverage maintained or improved
- [ ] Edge cases tested
- [ ] Error handling tested
- [ ] Integration tests passing (if applicable)

### Security
- [ ] **No hardcoded secrets**: No API keys, passwords, or tokens in code
- [ ] Environment variables used for configuration
- [ ] Input validation implemented where needed
- [ ] Tenant isolation verified (queries filter by `TenantId`)
- [ ] No SQL/NoSQL injection vulnerabilities
- [ ] Authentication/Authorization checked (if applicable)
- [ ] Dependencies scanned for vulnerabilities
- [ ] Sensitive data encrypted appropriately
- [ ] Security checklist reviewed (see [AppSec Standards](../CONTRIBUTING.md#appsec-standards))

### Documentation
- [ ] **Documentation updates**: README, API docs, or other documentation updated to reflect changes
- [ ] Breaking changes documented (if applicable)
- [ ] Migration guide provided (if applicable)
- [ ] ADR (Architecture Decision Record) created for significant architectural changes
- [ ] Code comments explain "why" not just "what"

### Git & CI/CD
- [ ] Commit messages follow [Conventional Commits](https://www.conventionalcommits.org/) format
- [ ] PR title is clear and descriptive
- [ ] Branch is up to date with `main`
- [ ] All CI/CD checks passing
- [ ] No merge conflicts

## 🛡️ Security Review
<!-- Required for all PRs -->

### Security Impact Assessment
- [ ] This PR does NOT introduce security risks
- [ ] This PR has been reviewed for common vulnerabilities (OWASP Top 10)
- [ ] Dependencies are up-to-date and free of known vulnerabilities
- [ ] Secrets management follows best practices

### Specific Security Checks
- [ ] Input sanitization implemented
- [ ] Output encoding applied
- [ ] Authentication verified
- [ ] Authorization enforced
- [ ] Rate limiting considered (if applicable)
- [ ] Audit logging added (if applicable)

**Security Notes**:
<!-- Describe any security considerations or mitigations -->


## 📊 Performance Impact
<!-- Does this PR impact performance? -->
- [ ] No performance impact
- [ ] Performance improved
- [ ] Performance impact assessed and acceptable
- [ ] Performance benchmarks included

**Performance Notes**:
<!-- Describe any performance considerations -->


## 🔄 Breaking Changes
<!-- Does this PR introduce breaking changes? -->
- [ ] No breaking changes
- [ ] Breaking changes documented below

**Breaking Changes**:
<!-- List and explain any breaking changes -->


## 🎯 Bounty Information (if applicable)
<!-- If this PR is for a bounty issue, provide details -->
- **Bounty Issue**: #
- **Bounty Tier**: [Tier 1 / Tier 2 / Tier 3 / Premium]
- **Estimated Bounty Amount**: $XXX
- [ ] I have signed the CLA via CLA Assistant
- [ ] I acknowledge bounty payment terms (see [CONTRIBUTING.md](../CONTRIBUTING.md#bounty-stacking-system))

## 📎 Additional Context
<!-- Any other information that reviewers should know -->


## ✍️ Reviewer Checklist
<!-- For maintainers/reviewers -->
- [ ] Code review completed
- [ ] Architecture review completed (if applicable)
- [ ] Security review completed
- [ ] Tests verified
- [ ] Documentation verified
- [ ] Breaking changes reviewed (if applicable)
- [ ] Bounty amount verified (if applicable)
- [ ] Ready to merge

---

**By submitting this PR, I confirm that**:
- [ ] I have read and followed the [Contributing Guidelines](../CONTRIBUTING.md)
- [ ] I have signed the Contributor License Agreement (CLA) via CLA Assistant
- [ ] My code follows the project's coding standards
- [ ] I have completed all applicable items in the Definition of Done checklist
