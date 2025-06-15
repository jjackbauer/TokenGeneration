# Base62 Token Generators – From Naive to Cryptographically Secure
This repository demonstrates multiple approaches to generating 6-digit base62 tokens, ranging from insecure methods to cryptographically secure implementations.

It’s a practical guide for developers interested in learning the trade-offs between simplicity, predictability, and true randomness in the context of MFA tokens, authentication codes, or session identifiers.

## ✨ Included Implementations
🔸 Digit-by-digit generator using System.Random (not secure)

🔸 Large random number + base62 reencoding (also not secure)

🔸 Manual Linear Congruential Generator (GLC) to illustrate PRNG internals

✅ Cryptographically secure RNG using System.Security.Cryptography.RandomNumberGenerator

✅ Secure HMAC-SHA256-based generator (hash-based token generation)

Each implementation outputs 6-character base62 tokens (using digits, uppercase, and lowercase letters).

## 📚 Use Cases
Educational reference for token generation

Understanding why common patterns are insecure

Templates for secure token creation in .NET applications

## 🚧 Disclaimer
The insecure implementations are included for educational purposes only. They should never be used in production environments where security is critical.

## 📦 Getting Started
Clone the repo and run the sample console app or unit tests to see each generator in action.

```bash
git clone git@github.com:jjackbauer/TokenGeneration.git
cd base62-token-generators
dotnet run
```
## 🏷️ Tags
#CSharp #Security #MFA #Base62 #TokenGeneration #Cryptography #HMAC #RandomNumberGenerator #GLC #SoftwareSecurity