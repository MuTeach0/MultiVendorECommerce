# Product Requirements Document (PRD)

## Product: MarketPlace | Multi-Vendor E-Commerce System
**Version:** 1.0  
**Date:** February 4, 2026  
**Status:** Final Draft  
**Document Owner:** Product Management Team  
**Stakeholders:** Business Operations, Engineering, Shop Management

---

## 1. Product Overview
The **MarketPlace** system is a high-performance multi-vendor e-commerce platform designed around the **"Master Catalog"** concept. It centralizes product data while allowing multiple sellers to compete through distinct **"Offers"**. The system features an advanced hybrid pricing engine, a robust loyalty rewards program, and a structured vendor request center to ensure data integrity and operational governance.

---

## 2. Problem Statement
Existing e-commerce solutions often suffer from:
* **Data Fragmentation:** Duplicate listings for the same product leading to poor SEO and a confusing user experience.
* **Pricing Inflexibility:** Inability to handle B2B (bulk) and B2C (retail) pricing logic simultaneously.
* **Governance Gaps:** Lack of control over brand intellectual property and product content quality.
* **Financial Complexity:** Difficulty in tracking multi-party settlements, commissions, and loyalty-point liabilities.

---

## 3. Goals & Objectives
* **Unified Experience:** Implement a "Buy Box" algorithm to feature the best seller for a single product.
* **Operational Automation:** Automate commission deductions, wallet updates, and payout cycles.
* **Customer Retention:** Drive repeat purchases through a mathematically sound Loyalty Points system.
* **Content Quality:** Enforce a strict Approval Workflow for brands and new product entries via the Request Center.
* **Financial Accuracy:** Maintain a source of truth for every cent moved via a Ledger-based transaction system.

---

## 4. User Roles & Permissions

| Role | Permissions |
| :--- | :--- |
| **Super Admin** | Full catalog control, brand/request approvals, financial payouts, commission configuration, and dispute resolution. |
| **Vendor (Seller)** | Offer management, stock updates, brand/campaign requests, wallet withdrawal requests, and sales analytics. |
| **Customer** | Product discovery, purchase execution, loyalty point redemption, wallet management, and order tracking. |

---

## 5. Functional Requirements

### 5.1 Catalog & Brand Management
* **5.1.1 Master Product Repository:** Products are created as templates (`MasterSku`) shared by all sellers to prevent duplicates.
* **5.1.2 Brand Registration Workflow:** Sellers must submit a `Brand Request` with legal documentation (Trademarks/Invoices) before listing branded products.
* **5.1.3 Category-Level Configuration:** Admins define which pricing models (Fixed, Attribute, Quantity) are enabled per category.

### 5.2 Advanced Pricing Engine
* **5.2.1 Fixed Pricing:** Support for standard fixed retail prices.
* **5.2.2 Attribute-Based Pricing:** Price adjustments based on JSON attributes (e.g., Size: XL adds +$5 to the base price).
* **5.2.3 Quantity-Based (Tiered) Pricing:** Support for B2B bulk discounts (e.g., 10% off for orders of 50+ units).
* **5.2.4 Hybrid Pricing Logic:** A complex engine capable of merging attribute adjustments and quantity tiers in a single calculation.

### 5.3 Offer & Buy Box Logic
* **5.3.1 Seller Offers:** Independent pricing and inventory management per seller for the same Master Product.
* **5.3.2 Buy Box Algorithm:** Automated selection of the "Featured Offer" based on a weighted score of Price, Seller Rating, Shipping Speed, and Fulfillment Type.
* **5.3.3 Price Guard:** Real-time validation to prevent abnormal price fluctuations (e.g., preventing hikes above 50% without approval).

### 5.4 Loyalty Points & Wallet System
* **5.4.1 Earning Logic:** Points are granted as cashback after the return window expires (Post-Delivered status).
* **5.4.2 Redemption Logic:** Customers can pay partially or fully using points (`1 Point = 0.10 EGP` or as configured).
* **5.4.3 Refund Handling:** Pro-rata refund of points and cash in case of partial order returns to prevent system gaming.

### 5.5 Vendor Request Center (Workflows)
* **5.5.1 Campaign Management:** Structured requests for participating in platform-wide events (e.g., White Friday).
* **5.5.2 Withdrawal System:** Multi-step verification for transferring `WithdrawableBalance` to bank accounts or e-wallets.
* **5.5.3 Content Edit Workflow:** Secure requests to modify shared Master Product data (Images/Descriptions).

---

## 6. Non-Functional Requirements

### 6.1 Performance
* **6.1.1 Response Time:** Buy Box calculation and pricing APIs must respond in **< 200ms**.
* **6.1.2 Concurrency:** Support for high-volume traffic during flash sales using optimistic locking on inventory.

### 6.2 Security & Data Integrity
* **6.2.1 Audit Logging:** Mandatory logging of every price change and status transition in `PriceAuditLogs`.
* **6.2.2 Data Encryption:** Sensitive KYC documents (IDs, Commercial Registries) must be encrypted at rest.

### 6.3 Reliability
* **6.3.1 Transactional Integrity:** All financial movements (Order -> Wallet -> Points) must be atomic.
* **6.3.2 Availability:** 99.9% uptime during business hours (6 AM - 8 PM).

---

## 7. User Stories

### 7.1 Epic: Brand Protection
* **As a Vendor,** I want to submit my trademark documents via the Brand Request Center **so that** I can exclusively list my private label products and prevent others from using my brand name.

### 7.2 Epic: Wholesale Pricing
* **As a Bulk Buyer,** I want to see a tiered pricing table on the product page **so that** I can see how much I save by purchasing 100 units instead of 10.

### 7.3 Epic: Loyalty Redemption
* **As a Customer,** I want to apply my earned points at the checkout page **so that** I can use my previous shopping rewards to reduce the total cash required for my current order.

---

## 8. Out of Scope
* **Phase 1:** Native Mobile Applications (Focus on Responsive Web).
* **Phase 1:** Integration with 3rd party logistics (Initial release uses internal shipping logic).
* **Phase 1:** Multi-currency support (Launch currency: EGP).

---

## 9. Success Metrics
* **GMV Growth:** Monthly increase of 20% in Gross Merchandise Value.
* **SLA Compliance:** 100% of Brand/Withdrawal requests processed within 48 business hours.
* **Buy Box Accuracy:** 100% algorithmic selection with zero manual intervention.

---

## 10. Assumptions & Dependencies
* **Assumptions:** Sellers provide accurate stock data; users have modern web browsers.
* **Dependencies:** Integration with a local Payment Gateway (e.g., Paymob) and a reliable SMS Gateway for OTP.

---

## 11. Constraints
* **Legal:** Must comply with local Consumer Protection Laws regarding returns and VAT (14%).
* **Technical:** Must strictly adhere to the provided **ERD Schema** to ensure relational integrity between Users, Offers, and Transactions.

---

## 12. Acceptance Criteria Summary

### Must Have (P0)
* [ ] Multi-vendor Wallet & Ledger System
* [ ] Hybrid Pricing Engine (Fixed, Attribute, Tiered)
* [ ] Buy Box Algorithm & Selection logic
* [ ] Vendor Request Center (Basic Requests)

### Should Have (P1)
* [ ] Loyalty Points Earning & Redemption
* [ ] Brand Creation & Verification Workflow
* [ ] Campaign Participation System

---

## 13. Glossary
| Term | Definition |
| :--- | :--- |
| **Buy Box** | The primary call-to-action area on a product page featuring the top-performing seller. |
| **Master SKU** | The unique identifier for the base product template shared by all sellers. |
| **Offer** | A specific seller's instance of a product, including their specific price and stock. |
| **FBN** | Fulfilled By Network (Storage and shipping managed by the platform). |

---

**Document Version:** 1.0  
**Last Updated:** February 4, 2026  
**Owner:** Product Management Team